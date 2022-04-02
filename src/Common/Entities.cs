namespace GakuGym.Common;

public record Domain
{
    public Guid            guid        { get; set; }
    public string?         name        { get; set; }
    public string?         description { get; set; }
    public DateTimeOffset  created     { get; set; }
    public List<Category>? categories  { get; set; }
}

public record Category
{
    public Guid         guid        { get; set; }
    public string?      name        { get; set; }
    public string?      description { get; set; }
    public Guid         domainId    { get; set; }
    public List<Field>? fields      { get; set; }
}

public record Field
{
    public Guid       guid        { get; set; }
    public string?    name        { get; set; }
    public string?    description { get; set; }
    public FieldType  type        { get; set; }
}

public enum FieldType
{
    Text,
    Html
}

public record Fact
{
    public Guid                      guid       { get; set; }
    public Guid                      categoryId { get; set; }
    public DateTimeOffset            created    { get; set; }
    public Dictionary<Guid, string>? fieldData  { get; set; }
}

public record FactChallengeData
{
    public Guid?          guid                { get; set; }
    public Guid           challengeId         { get; set; }
    public Guid           factId              { get; set; }
    public DateTimeOffset learned             { get; set; }
    public DateTimeOffset lastChallenged      { get; set; }
    public string?        status              { get; set; }
    public DateTimeOffset reviewAvailableDate { get; set; }
}

public record Challenge
{
    public Guid?   id            { get; set; }
    public Guid    categoryId    { get; set; }
    public string? name          { get; set; }
    public string? frontTemplate { get; set; }
    public string? backTemplate  { get; set; }
}

public record Study
{
    public Guid?                 id                       { get; set; }
    public string?               name                     { get; set; }
    public int                   sessionIntervalMinutes   { get; set; }
    public DateTimeOffset        lastNewChallengeDateTime { get; set; }
    public List<StudyFactGroup>? factGroups               { get; set; }
}                                                        

public record StudyFactGroup
{
    public Guid        categoryId { get; set; }
    public List<Guid>? challenges { get; set; }
}

public class SearchQuery
{
    public Guid categoryId;

    public string ToSql()
    {
        return $"select guid, categoryId, created, fieldData from Fact where categoryId = X'{BitConverter.ToString(((Guid)categoryId).ToByteArray()).Replace("-", "")}'";
    }
}

public record SearchResults
{
    public List<Fact>? facts { get; set; }
}

public record AuthResult
{
    public bool    success  { get; set; }
    public string? jwtToken { get; set; }
}
