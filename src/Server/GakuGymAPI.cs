namespace GakuGym.Server;

using GakuGym.Common;

public class GakuGymAPI : IGakuGymAPI
{
    public async Task<Domain> CreateDomain(string name, string description) { return await DAL.CreateDomain(name, description); }

    public async Task UpdateDomain(Domain domain) { await DAL.UpdateDomain(domain); }

    public async Task<List<Domain>> GetDomains() { return await DAL.GetDomains(); }

    public async Task<Domain> GetDomain(Guid id) { return await DAL.GetDomain(id);}

    public async Task<List<Category>> GetCategoriesByDomain(Guid domainId) { return await DAL.GetCategoriesByDomain(domainId); }

    public async Task<Category> GetCategory(Guid categoryId) { return await DAL.GetCategory(categoryId); }

    public async Task<List<Category>> GetAllCategories() { return await DAL.GetAllCategories(); }

    public async Task<Challenge> GetChallenge(Guid id) { return await DAL.GetChallenge(id); }

    public async Task<List<Challenge>> GetChallengesByCategory(Guid categoryId) { return await DAL.GetChallengesByCategory(categoryId); }

    public async Task<Category> CreateCategory(Guid domainId, string name, string description, List<(string name, string description, FieldType type)> fields)
    {
        return await DAL.CreateCategory(domainId, name, description, fields);
    }

    public async Task UpdateCategory(Category category) { await DAL.UpdateCategory(category); }

    public async Task<SearchResults> SearchFacts(SearchQuery query) { return await DAL.SearchFacts(query);}

    public async Task<Fact> AddFact(Guid categoryId, Dictionary<Guid, string> values) { return await DAL.AddFact(categoryId, values); }

    public async Task UpdateFact(Fact fact) { await DAL.UpdateFact(fact); }

    public async Task<Fact> GetFact(Guid factId) { return await DAL.GetFact(factId); }

    public async Task<Challenge> SaveChallenge(Challenge challenge) { return await DAL.SaveChallenge(challenge); }

    public async Task<FactChallengeData> SaveFactChallengeData(FactChallengeData factChallengeData) { return await DAL.SaveFactChallengeData(factChallengeData); }

    public async Task<Study> SaveStudy(Study study) { return await DAL.SaveStudy(study);}

    public async Task<List<Study>> GetStudies() { return await DAL.GetStudies();}

    public async Task<Study> GetStudy(Guid studyId) { return await DAL.GetStudy(studyId); }

    public async Task<List<FactChallengeData>> GetStudySessionNewChallenges(Guid categoryId, DateTimeOffset lastNewChallengeDateTime)
    {
        return await DAL.GetStudySessionNewChallenges(categoryId, lastNewChallengeDateTime);
    }

    public async Task<List<FactChallengeData>> GetStudySessionReviewChallenges(Guid categoryId)
    {
        return await DAL.GetStudySessionReviewChallenges(categoryId);
    }

    [NoAuth]
    public async Task<AuthResult> Authenticate(string password)
    {
        await Task.CompletedTask;

        return Security.Authenticate(password);
    }
}

