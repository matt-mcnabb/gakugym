namespace GakuGym.Server;

using GakuGym.Common;

internal static class DAL
{
    public static async Task<Domain> CreateDomain(string name, string description)
    {
        var created = DateTimeOffset.UtcNow;
        var guid    = Guid.NewGuid();

        await DB.ExecNonQuery(new SafeSQL
        (@$"
            insert into Domain (guid, name, description, created)
                values 
                (
                    {guid},
                    {name}, 
                    {description}, 
                    {created}
                )
        "));

        return new Domain
        {
            guid        = guid,
            name        = name,
            description = description,
            created     = created
        };
    }

    public static async Task UpdateDomain(Domain domain)
    {
        await DB.ExecNonQuery(new SafeSQL
        ($@"
            update Domain set
                name        = {domain.name},
                description = {domain.description}
            where
                guid = {domain.guid}'
        "));
    }

    public static async Task<List<Domain>> GetDomains()
    {
        var results = await DB.ExecQuery(new SafeSQL
        (@$"
            select
                guid, 
                name,
                description,
                created
            from
                Domain
            order by
                name asc
        "));

        return results.GetRows().Select(x => new Domain
        {
            guid        = x.GetGuid("guid"),
            name        = x.Get<string>("name"),
            description = x.Get<string>("description"),
            created     = x.GetDateTime("created")
        }).ToList();
    }

    public static async Task<Domain> GetDomain(Guid id)
    {
        var result = await DB.ExecQuerySingle(new SafeSQL
        (@$"
            select
                guid, 
                name,
                description,
                created
            from
                Domain
            where
                guid = {id}
        "));

        return new Domain
        {
            guid        = result.GetGuid("guid"),
            name        = result.Get<string>("name"),
            description = result.Get<string>("description"),
            created     = result.GetDateTime("created"),
            categories  = await GetCategoriesByDomain(id) 
        };
    }

    public static async Task<List<Category>> GetCategoriesByDomain(Guid domainId)
    {
        var results = await DB.ExecQuery(new SafeSQL
        (@$"
            select 
                guid,
                domainId,
                name,
                description,
                created,
                fields
            from 
                Category
            where
                domainId = {domainId} 
        "));

        return results.GetRows().Select(x => new Category
        {
            guid        = x.GetGuid("guid"),
            domainId    = x.GetGuid("domainId"),
            name        = x.Get<string>("name"),
            description = x.Get<string>("description"),
            fields      = x.GetFromJSON<List<Field>>("fields")
        }).ToList();
    }

    public static async Task<Category> GetCategory(Guid categoryId)
    {
        var results = await DB.ExecQuery(new SafeSQL
        (@$"
            select 
                guid,
                domainId,
                name,
                description,
                created,
                fields
            from 
                Category
            where
                guid = {categoryId} 
        "));

        return results.GetRows().Select(x => new Category
        {
            guid        = x.GetGuid("guid"),
            domainId    = x.GetGuid("domainId"),
            name        = x.Get<string>("name"),
            description = x.Get<string>("description"),
            fields      = x.GetFromJSON<List<Field>>("fields")
        }).First();
    }

    public static async Task<List<Category>> GetAllCategories()
    {
        var results = await DB.ExecQuery(new SafeSQL
        (@$"
            select 
                guid,
                domainId,
                name,
                description,
                created,
                fields
            from 
                Category
        "));

        return results.GetRows().Select(x => new Category
        {
            guid        = x.GetGuid("guid"),
            domainId    = x.GetGuid("domainId"),
            name        = x.Get<string>("name"),
            description = x.Get<string>("description"),
            fields      = x.GetFromJSON<List<Field>>("fields")
        }).ToList();
    }

    public static async Task<Challenge> GetChallenge(Guid id)
    {
        var result = await DB.ExecQuerySingle(new SafeSQL
        ($@"
            select
                guid,
                categoryId,
                challengeData
            from
                Challenge
            where
                guid = {id}
        "));

        return result.GetFromJSON<Challenge>("challengeData");
    }

    public static async Task<List<Challenge>> GetChallengesByCategory(Guid categoryId)
    {
        var results = await DB.ExecQuery(new SafeSQL
        ($@"
            select
                guid,
                categoryId,
                challengeData
            from
                Challenge
            where
                categoryId = {categoryId}
        "));

        return results.GetRows().Select(x => x.GetFromJSON<Challenge>("challengeData")).ToList();
    }

    public static async Task<Category> CreateCategory(Guid domainId, string name, string description, List<(string name, string description, FieldType type)> fields)
    {
        var created = DateTimeOffset.UtcNow;

        var fieldsWithId = fields.Select(x => new Field
        {
            guid        = Guid.NewGuid(),
            name        = x.name,
            description = x.description,
            type        = x.type
        }).ToList();

        var guid = Guid.NewGuid();

        await DB.ExecNonQuery(new SafeSQL
        (@$"
            insert into Category (guid, domainId, name, description, created, fields)
                values
                (
                    {guid},
                    {domainId},
                    {name},
                    {description},
                    {created},
                    {JSON.Serialize(fieldsWithId)}
                )
        "));

        return new Category
        {
            guid        = guid,
            domainId    = domainId,
            name        = name,
            description = description,
            fields      = fieldsWithId
        };
    }

    public static async Task UpdateCategory(Category category) 
    {
        await DB.ExecNonQuery(new SafeSQL
        ($@"
            update Category set
                name        = {category.name},
                description = {category.description},
                fields      = {JSON.Serialize(category.fields)}
            where
                guid = {category.guid}
        "));
    }

    public static async Task<SearchResults> SearchFacts(SearchQuery query)
    {
        var results = await DB.ExecRawQuery(query.ToSql());

        return new SearchResults
        {
            facts = results.GetRows().Select(x => new Fact
            {
                fieldData  = x.GetFromJSON<Dictionary<Guid, string>>("fieldData"),
                categoryId = x.GetGuid("categoryId"),
                guid       = x.GetGuid("guid")
            }).ToList()
        };
    }

    public static async Task<Fact> AddFact(Guid categoryId, Dictionary<Guid, string> values)
    {
        var now  = DateTimeOffset.UtcNow;
        var guid = Guid.NewGuid();

        await DB.ExecNonQuery(new SafeSQL
        ($@"
            insert into Fact (guid, categoryId, created, fieldData)
                select
                    {guid},
                    {categoryId},
                    {now},
                    {JSON.Serialize(values)}
        "));

        return new Fact
        {
            guid       = guid,
            categoryId = categoryId,
            created    = now,
            fieldData  = values,
        };
    }

    public static async Task UpdateFact(Fact fact) 
    {
        await DB.ExecNonQuery(new SafeSQL
        ($@"
            update Fact set
                fieldData = {JSON.Serialize(fact.fieldData)}
            where
                guid = {fact.guid}
        "));
    }
        
    public static async Task<Fact> GetFact(Guid factId)
    {
        var result = await DB.ExecQuerySingle(new SafeSQL
        ($@"
            select
                guid,
                categoryId,
                created,
                fieldData
            from
                Fact
            where
                guid = {factId}
        "));

        return new Fact
        {
            guid       = factId,
            categoryId = result.GetGuid("categoryId"),
            created    = result.GetDateTime("created"),
            fieldData  = result.GetFromJSON<Dictionary<Guid, string>>("fieldData")
        };
    }

    public static async Task<Challenge> SaveChallenge(Challenge challenge) 
    {
        if(challenge.id == null)
        {
            challenge.id = Guid.NewGuid();

            await DB.ExecNonQuery(new SafeSQL
            ($@"
                insert into Challenge (guid, categoryId, challengeData)
                    select
                        {challenge.id.Value},
                        {challenge.categoryId},
                        {JSON.Serialize(challenge)}
            ")); 
        }
        else
        {
            await DB.ExecNonQuery(new SafeSQL
            ($@"
                update Challenge set
                    challengeData = {JSON.Serialize(challenge)}
                where
                    guid = {challenge.id.Value}
            "));
        }

        return challenge;
    }

    public static async Task<FactChallengeData> SaveFactChallengeData(FactChallengeData factChallengeData)
    {
        if(factChallengeData.guid == null)
        {
            factChallengeData.guid = Guid.NewGuid();

            await DB.ExecNonQuery(new SafeSQL
            ($@"
                insert into FactChallengeData (guid, factId, categoryId, status)
                    select
                        {factChallengeData.guid.Value},
                        {factChallengeData.factId},
                        {factChallengeData.challengeId},
                        {factChallengeData.status}
            "));
        }
        else
        {
            await DB.ExecNonQuery(new SafeSQL
            ($@"
                update FactChallengeData set
                    status = {factChallengeData.status}
                where
                    guid = {factChallengeData.guid.Value}
            "));
        }

        return factChallengeData;
    }

    public static async Task<Study> SaveStudy(Study study) 
    {
        if(study.id == null)
        {
            study.id = Guid.NewGuid();

            await DB.ExecNonQuery(new SafeSQL
            ($@"
                insert into Study (guid, studyData)
                    select 
                        {study.id.Value},
                        {JSON.Serialize(study)}
            "));
        }
        else
        {
            await DB.ExecNonQuery(new SafeSQL
            ($@"
                update Study set
                    studyData = {JSON.Serialize(study)}
                where
                    guid = {study.id.Value}
            "));
        }

        return study;
    }

    public static async Task<List<Study>> GetStudies()
    {
        var results = await DB.ExecQuery(new SafeSQL
        (@$"
            select 
                guid, 
                studyData 
            from 
                Study
        "));

        return results.GetRows().Select(x => x.GetFromJSON<Study>("studyData")).ToList();
    }

    public static async Task<Study> GetStudy(Guid studyId)
    {
        var result = await DB.ExecQuerySingle(new SafeSQL
        ($@"
            select 
                guid, 
                studyData 
            from 
                Study 
            where 
                guid = {studyId}
        "));

        return result.GetFromJSON<Study>("studyData");
    }

    public static async Task<List<FactChallengeData>> GetStudySessionNewChallenges(Guid categoryId, DateTimeOffset lastNewChallengeDateTime)
    {
        var results = await DB.ExecQuery(new SafeSQL
        ($@"
            select
                Challenge.guid as challengeId,
                Fact.guid as factId,
                status
            from
                Fact
                inner join
                Challenge on Fact.categoryId = Challenge.categoryId
                left join
                FactChallengeData on FactChallengeData.factId = Fact.guid and FactChallengeData.challengeId = Challenge.guid
            where
                Fact.categoryId = {categoryId}
                and
                (
                    FactChallengeData.status is null 
                    or 
                    FactChallengeData.status = 'Learning'
                    or
                    FactChallengeData.learnedDateTime > {lastNewChallengeDateTime}
                )
        "));

        return results.GetRows().Select(x => new FactChallengeData
        {
            challengeId = x.GetGuid("challengeId"),
            factId      = x.GetGuid("factId"),
            status      = x.Get<string>("status")
        }).ToList();
    }

    public static async Task<List<FactChallengeData>> GetStudySessionReviewChallenges(Guid categoryId)
    {
        var results = await DB.ExecQuery(new SafeSQL
        ($@"
            select
                Challenge.guid as challengeId,
                Fact.guid as factId,
                status
            from
                Fact
                inner join
                Challenge on Fact.categoryId = Challenge.categoryId
                left join
                FactChallengeData on FactChallengeData.factId = Fact.guid and FactChallengeData.challengeId = Challenge.guid
            where
                Fact.categoryId = {categoryId}
                and
                (
                    FactChallengeData.nextReviewAvailableDateTime < {DateTimeOffset.Now}
                )
        "));

        return results.GetRows().Select(x => new FactChallengeData
        {
            challengeId = x.GetGuid("challengeId"),
            factId      = x.GetGuid("factId"),
            status      = x.Get<string>("status")
        }).ToList();
    }
}

