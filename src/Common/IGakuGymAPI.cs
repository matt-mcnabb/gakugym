namespace GakuGym.Common;

public interface IGakuGymAPI
{
    Task<Domain>                  CreateDomain(string name, string description);
    Task                          UpdateDomain(Domain domain);
    Task<List<Domain>>            GetDomains();
    Task<Domain>                  GetDomain(Guid id);
    Task<List<Category>>          GetCategoriesByDomain(Guid domainId);
    Task<Category>                GetCategory(Guid categoryId);
    Task<List<Category>>          GetAllCategories();
    Task<Challenge>               GetChallenge(Guid id);
    Task<List<Challenge>>         GetChallengesByCategory(Guid categoryId);
    Task<Category>                CreateCategory(Guid domainId, string name, string description, List<(string name, string description, FieldType type)> fields);
    Task                          UpdateCategory(Category category);
    Task<SearchResults>           SearchFacts(SearchQuery query);
    Task<Fact>                    AddFact(Guid categoryId, Dictionary<Guid, string> values);
    Task                          UpdateFact(Fact fact);
    Task<Fact>                    GetFact(Guid factId);
    Task<Challenge>               SaveChallenge(Challenge challenge);
    Task<FactChallengeData>       SaveFactChallengeData(FactChallengeData factChallengeData);
    Task<Study>                   SaveStudy(Study study);
    Task<List<Study>>             GetStudies();
    Task<Study>                   GetStudy(Guid studyId);
    Task<List<FactChallengeData>> GetStudySessionNewChallenges(Guid categoryId, DateTimeOffset lastNewChallengeDateTime);
    Task<List<FactChallengeData>> GetStudySessionReviewChallenges(Guid categoryId);

    Task<AuthResult> Authenticate(string password);
}
