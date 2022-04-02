namespace GakuGym.Server;

using GakuGym.Common;
using Microsoft.Data.Sqlite;

[System.Runtime.CompilerServices.InterpolatedStringHandler]
public ref struct SqlInterpolatedStringHandler
{
    private StringBuilder sb;

    public SqlInterpolatedStringHandler(int literalLength, int formattedCount) =>
        sb = new StringBuilder(literalLength);

    public void AppendLiteral(string s) =>
        sb.Append(s);

    public void AppendFormatted<T>(T value) =>
        sb.Append(value switch
        {
            Guid guid                     => $"X'{BitConverter.ToString(guid.ToByteArray()).Replace("-", "")}'",
            DateTimeOffset dateTimeOffset => $"'{dateTimeOffset.ToISO8601()}'",
            string s                      => $"'{s.Replace("'","''")}'",
            _                             => value?.ToString()
        });

    public string ToFormattedString() =>
        sb.ToString();
}

public class SafeSQL
{
    private string sql;

    public SafeSQL(SqlInterpolatedStringHandler stringIntperpolation) =>
        sql = stringIntperpolation.ToFormattedString();

    public string ToSQL() =>
        sql;
}

public class ResultSet
{
    public Dictionary<string, int> Indices { get; set; }
    public List<object[]>          Rows    { get; set; }

    public struct Row
    {
        public int       rowIndex;
        public ResultSet resultSet;

        public T              Get<T>(string name)         => (T)resultSet.Rows[rowIndex][resultSet.Indices[name]];
        public Guid           GetGuid(string name)        => new Guid(Get<byte[]>(name));
        public T              GetFromJSON<T>(string name) => JSON.Deserialize<T>(Get<string>(name));
        public DateTimeOffset GetDateTime(string name)    => DateTimeOffsetEx.FromISO8601(Get<string>(name));  
    }

    public IEnumerable<Row> GetRows() => GetEnumerator();

    public IEnumerable<Row> GetEnumerator()
    {
        var row = new Row { rowIndex = 0, resultSet = this };

        for (; row.rowIndex < Rows.Count; row.rowIndex++)
            yield return row;
    }
}

public class DB
{        
    private static string connectionString;

    public static async Task Init(string connectionString)
    {
        DB.connectionString = connectionString;

        ExecNonQuery(new SafeSQL
        (@$"
            create table if not exists Domain
            (
	            guid blob not null primary key,
	            name text not null,
                description text,
                created text not null
            )
        ")).GetAwaiter().GetResult();

        ExecNonQuery(new SafeSQL
        (@$"    
            create table if not exists Category
            (
	            guid blob not null primary key,
	            domainId blob not null, 
                name text not null,
                description text,
                created text not null,
                fields text not null
            )
        ")).GetAwaiter().GetResult();

        ExecNonQuery(new SafeSQL
        (@$"    
            create table if not exists Fact
            (
	            guid blob not null primary key,
	            categoryId blob not null, 
                created text not null,
                fieldData text not null                    
            )
        ")).GetAwaiter().GetResult();

        ExecNonQuery(new SafeSQL
        (@$"    
            create table if not exists Challenge
            (
	            guid blob not null primary key,
                categoryId blob not null,
                challengeData text not null                    
            )
        ")).GetAwaiter().GetResult();

        ExecNonQuery(new SafeSQL
        (@$"    
            create table if not exists Study
            (
	            guid blob not null primary key,
                studyData text not null                    
            )
        ")).GetAwaiter().GetResult();

        ExecNonQuery(new SafeSQL
        (@$"    
            create table if not exists FactChallengeData
            (
	            guid blob not null primary key,
                factId blob not null,
                challengeId blob not null,
                learnedDateTime text,
                nextReviewAvailableDateTime text,
                status text
            )
        ")).GetAwaiter().GetResult();
    }

    public static async Task<ResultSet.Row> ExecQuerySingle(SafeSQL sql)
    {
        return (await DB.ExecQuery(sql)).GetRows().Single();
    }

    public static async Task<ResultSet> ExecQuery(SafeSQL sql)
    {
        return await ExecRawQuery(sql.ToSQL());
    }

    public static async Task<ResultSet> ExecRawQuery(string sql)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            await connection.OpenAsync();

            var cmd = new SqliteCommand(sql, connection);

            var reader = await cmd.ExecuteReaderAsync();

            var resultSet = new ResultSet 
            { 
                Indices = (0..reader.FieldCount).Enumerate().ToDictionary(i => reader.GetName(i)), 
                Rows    = new List<object[]>() 
            };

            while(await reader.ReadAsync())
            {
                var row = new object[reader.FieldCount];

                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var value = reader.GetValue(i);

                    row[i] = value?.GetType() == typeof(System.DBNull) ? null : value;
                }

                resultSet.Rows.Add(row);
            }

            await connection.CloseAsync();

            return resultSet;
        }            
    }

    public static async Task ExecNonQuery(SafeSQL sql)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            await connection.OpenAsync();

            var cmd = new SqliteCommand(sql.ToSQL(), connection);

            await cmd.ExecuteNonQueryAsync();

            await connection .CloseAsync();
        }            
    }
}
