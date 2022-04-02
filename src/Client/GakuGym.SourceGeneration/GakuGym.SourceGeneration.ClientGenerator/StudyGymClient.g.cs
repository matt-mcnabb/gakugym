namespace GakuGym.Client;

using GakuGym.Common;

public partial class GakuGymClient : IGakuGymAPI
{
    public async System.Threading.Tasks.Task<GakuGym.Common.Domain> CreateDomain(string name, string description)
    {
        var request = new CreateDomainRequest
        {
            name = name,
            description = description,
        };
        return await PostRequest<CreateDomainRequest, GakuGym.Common.Domain>("CreateDomain", request);
    }
    public async Task UpdateDomain(GakuGym.Common.Domain domain)
    {
        var request = new UpdateDomainRequest
        {
            domain = domain,
        };
        await PostRequestVoid("UpdateDomain", request);
    }
    public async System.Threading.Tasks.Task<System.Collections.Generic.List<GakuGym.Common.Domain>> GetDomains()
    {return await PostRequest<System.Collections.Generic.List<GakuGym.Common.Domain>>("GetDomains");
    }
    public async System.Threading.Tasks.Task<GakuGym.Common.Domain> GetDomain(System.Guid id)
    {
        var request = new GetDomainRequest
        {
            id = id,
        };
        return await PostRequest<GetDomainRequest, GakuGym.Common.Domain>("GetDomain", request);
    }
    public async System.Threading.Tasks.Task<System.Collections.Generic.List<GakuGym.Common.Category>> GetCategoriesByDomain(System.Guid domainId)
    {
        var request = new GetCategoriesByDomainRequest
        {
            domainId = domainId,
        };
        return await PostRequest<GetCategoriesByDomainRequest, System.Collections.Generic.List<GakuGym.Common.Category>>("GetCategoriesByDomain", request);
    }
    public async System.Threading.Tasks.Task<GakuGym.Common.Category> GetCategory(System.Guid categoryId)
    {
        var request = new GetCategoryRequest
        {
            categoryId = categoryId,
        };
        return await PostRequest<GetCategoryRequest, GakuGym.Common.Category>("GetCategory", request);
    }
    public async System.Threading.Tasks.Task<System.Collections.Generic.List<GakuGym.Common.Category>> GetAllCategories()
    {return await PostRequest<System.Collections.Generic.List<GakuGym.Common.Category>>("GetAllCategories");
    }
    public async System.Threading.Tasks.Task<GakuGym.Common.Challenge> GetChallenge(System.Guid id)
    {
        var request = new GetChallengeRequest
        {
            id = id,
        };
        return await PostRequest<GetChallengeRequest, GakuGym.Common.Challenge>("GetChallenge", request);
    }
    public async System.Threading.Tasks.Task<System.Collections.Generic.List<GakuGym.Common.Challenge>> GetChallengesByCategory(System.Guid categoryId)
    {
        var request = new GetChallengesByCategoryRequest
        {
            categoryId = categoryId,
        };
        return await PostRequest<GetChallengesByCategoryRequest, System.Collections.Generic.List<GakuGym.Common.Challenge>>("GetChallengesByCategory", request);
    }
    public async System.Threading.Tasks.Task<GakuGym.Common.Category> CreateCategory(System.Guid domainId, string name, string description, System.Collections.Generic.List<(string name, string description, GakuGym.Common.FieldType type)> fields)
    {
        var request = new CreateCategoryRequest
        {
            domainId = domainId,
            name = name,
            description = description,
            fields = fields,
        };
        return await PostRequest<CreateCategoryRequest, GakuGym.Common.Category>("CreateCategory", request);
    }
    public async Task UpdateCategory(GakuGym.Common.Category category)
    {
        var request = new UpdateCategoryRequest
        {
            category = category,
        };
        await PostRequestVoid("UpdateCategory", request);
    }
    public async System.Threading.Tasks.Task<GakuGym.Common.SearchResults> SearchFacts(GakuGym.Common.SearchQuery query)
    {
        var request = new SearchFactsRequest
        {
            query = query,
        };
        return await PostRequest<SearchFactsRequest, GakuGym.Common.SearchResults>("SearchFacts", request);
    }
    public async System.Threading.Tasks.Task<GakuGym.Common.Fact> AddFact(System.Guid categoryId, System.Collections.Generic.Dictionary<System.Guid, string> values)
    {
        var request = new AddFactRequest
        {
            categoryId = categoryId,
            values = values,
        };
        return await PostRequest<AddFactRequest, GakuGym.Common.Fact>("AddFact", request);
    }
    public async Task UpdateFact(GakuGym.Common.Fact fact)
    {
        var request = new UpdateFactRequest
        {
            fact = fact,
        };
        await PostRequestVoid("UpdateFact", request);
    }
    public async System.Threading.Tasks.Task<GakuGym.Common.Fact> GetFact(System.Guid factId)
    {
        var request = new GetFactRequest
        {
            factId = factId,
        };
        return await PostRequest<GetFactRequest, GakuGym.Common.Fact>("GetFact", request);
    }
    public async System.Threading.Tasks.Task<GakuGym.Common.Challenge> SaveChallenge(GakuGym.Common.Challenge challenge)
    {
        var request = new SaveChallengeRequest
        {
            challenge = challenge,
        };
        return await PostRequest<SaveChallengeRequest, GakuGym.Common.Challenge>("SaveChallenge", request);
    }
    public async System.Threading.Tasks.Task<GakuGym.Common.FactChallengeData> SaveFactChallengeData(GakuGym.Common.FactChallengeData factChallengeData)
    {
        var request = new SaveFactChallengeDataRequest
        {
            factChallengeData = factChallengeData,
        };
        return await PostRequest<SaveFactChallengeDataRequest, GakuGym.Common.FactChallengeData>("SaveFactChallengeData", request);
    }
    public async System.Threading.Tasks.Task<GakuGym.Common.Study> SaveStudy(GakuGym.Common.Study study)
    {
        var request = new SaveStudyRequest
        {
            study = study,
        };
        return await PostRequest<SaveStudyRequest, GakuGym.Common.Study>("SaveStudy", request);
    }
    public async System.Threading.Tasks.Task<System.Collections.Generic.List<GakuGym.Common.Study>> GetStudies()
    {return await PostRequest<System.Collections.Generic.List<GakuGym.Common.Study>>("GetStudies");
    }
    public async System.Threading.Tasks.Task<GakuGym.Common.Study> GetStudy(System.Guid studyId)
    {
        var request = new GetStudyRequest
        {
            studyId = studyId,
        };
        return await PostRequest<GetStudyRequest, GakuGym.Common.Study>("GetStudy", request);
    }
    public async System.Threading.Tasks.Task<System.Collections.Generic.List<GakuGym.Common.FactChallengeData>> GetStudySessionNewChallenges(System.Guid categoryId, System.DateTimeOffset lastNewChallengeDateTime)
    {
        var request = new GetStudySessionNewChallengesRequest
        {
            categoryId = categoryId,
            lastNewChallengeDateTime = lastNewChallengeDateTime,
        };
        return await PostRequest<GetStudySessionNewChallengesRequest, System.Collections.Generic.List<GakuGym.Common.FactChallengeData>>("GetStudySessionNewChallenges", request);
    }
    public async System.Threading.Tasks.Task<System.Collections.Generic.List<GakuGym.Common.FactChallengeData>> GetStudySessionReviewChallenges(System.Guid categoryId)
    {
        var request = new GetStudySessionReviewChallengesRequest
        {
            categoryId = categoryId,
        };
        return await PostRequest<GetStudySessionReviewChallengesRequest, System.Collections.Generic.List<GakuGym.Common.FactChallengeData>>("GetStudySessionReviewChallenges", request);
    }
    public async System.Threading.Tasks.Task<GakuGym.Common.AuthResult> Authenticate(string password)
    {
        var request = new AuthenticateRequest
        {
            password = password,
        };
        return await PostRequest<AuthenticateRequest, GakuGym.Common.AuthResult>("Authenticate", request);
    }
}