namespace GakuGym.Server;

using GakuGym.Common;

public static partial class Endpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("CreateDomain", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<CreateDomainRequest>(body);

            var result = await gakuGymAPI.CreateDomain(request.name, request.description);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("UpdateDomain", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<UpdateDomainRequest>(body);

            await gakuGymAPI.UpdateDomain(request.domain);

            context.Response.StatusCode = 200;
        });
        routeBuilder.MapPost("GetDomains", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }

            var result = await gakuGymAPI.GetDomains();

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetDomain", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetDomainRequest>(body);

            var result = await gakuGymAPI.GetDomain(request.id);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetCategoriesByDomain", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetCategoriesByDomainRequest>(body);

            var result = await gakuGymAPI.GetCategoriesByDomain(request.domainId);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetCategory", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetCategoryRequest>(body);

            var result = await gakuGymAPI.GetCategory(request.categoryId);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetAllCategories", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }

            var result = await gakuGymAPI.GetAllCategories();

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetChallenge", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetChallengeRequest>(body);

            var result = await gakuGymAPI.GetChallenge(request.id);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetChallengesByCategory", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetChallengesByCategoryRequest>(body);

            var result = await gakuGymAPI.GetChallengesByCategory(request.categoryId);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("CreateCategory", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<CreateCategoryRequest>(body);

            var result = await gakuGymAPI.CreateCategory(request.domainId, request.name, request.description, request.fields);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("UpdateCategory", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<UpdateCategoryRequest>(body);

            await gakuGymAPI.UpdateCategory(request.category);

            context.Response.StatusCode = 200;
        });
        routeBuilder.MapPost("SearchFacts", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<SearchFactsRequest>(body);

            var result = await gakuGymAPI.SearchFacts(request.query);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("AddFact", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<AddFactRequest>(body);

            var result = await gakuGymAPI.AddFact(request.categoryId, request.values);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("UpdateFact", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<UpdateFactRequest>(body);

            await gakuGymAPI.UpdateFact(request.fact);

            context.Response.StatusCode = 200;
        });
        routeBuilder.MapPost("GetFact", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetFactRequest>(body);

            var result = await gakuGymAPI.GetFact(request.factId);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("SaveChallenge", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<SaveChallengeRequest>(body);

            var result = await gakuGymAPI.SaveChallenge(request.challenge);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("SaveFactChallengeData", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<SaveFactChallengeDataRequest>(body);

            var result = await gakuGymAPI.SaveFactChallengeData(request.factChallengeData);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("SaveStudy", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<SaveStudyRequest>(body);

            var result = await gakuGymAPI.SaveStudy(request.study);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetStudies", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }

            var result = await gakuGymAPI.GetStudies();

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetStudy", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetStudyRequest>(body);

            var result = await gakuGymAPI.GetStudy(request.studyId);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetStudySessionNewChallenges", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetStudySessionNewChallengesRequest>(body);

            var result = await gakuGymAPI.GetStudySessionNewChallenges(request.categoryId, request.lastNewChallengeDateTime);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetStudySessionReviewChallenges", async context => 
        {
            if(!Security.VerifyToken(context.Request.Headers["Authorization"]))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetStudySessionReviewChallengesRequest>(body);

            var result = await gakuGymAPI.GetStudySessionReviewChallenges(request.categoryId);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("Authenticate", async context => 
        {           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<AuthenticateRequest>(body);

            var result = await gakuGymAPI.Authenticate(request.password);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
    } 
}