namespace GakuGym.Server;

using GakuGym.Common;

internal partial class Endpoints
{
    public void MapEndpoints(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("CreateDomain", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<CreateDomainRequest>(body);

            var result = await GakuGymAPI.CreateDomain(request.name, request.description);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("UpdateDomain", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<UpdateDomainRequest>(body);

            await GakuGymAPI.UpdateDomain(request.domain);

            context.Response.StatusCode = 200;
        });
        routeBuilder.MapPost("GetDomains", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }

            var result = await GakuGymAPI.GetDomains();

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetDomain", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetDomainRequest>(body);

            var result = await GakuGymAPI.GetDomain(request.id);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetCategoriesByDomain", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetCategoriesByDomainRequest>(body);

            var result = await GakuGymAPI.GetCategoriesByDomain(request.domainId);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetCategory", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetCategoryRequest>(body);

            var result = await GakuGymAPI.GetCategory(request.categoryId);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetAllCategories", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }

            var result = await GakuGymAPI.GetAllCategories();

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetChallenge", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetChallengeRequest>(body);

            var result = await GakuGymAPI.GetChallenge(request.id);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetChallengesByCategory", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetChallengesByCategoryRequest>(body);

            var result = await GakuGymAPI.GetChallengesByCategory(request.categoryId);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("CreateCategory", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<CreateCategoryRequest>(body);

            var result = await GakuGymAPI.CreateCategory(request.domainId, request.name, request.description, request.fields);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("UpdateCategory", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<UpdateCategoryRequest>(body);

            await GakuGymAPI.UpdateCategory(request.category);

            context.Response.StatusCode = 200;
        });
        routeBuilder.MapPost("SearchFacts", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<SearchFactsRequest>(body);

            var result = await GakuGymAPI.SearchFacts(request.query);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("AddFact", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<AddFactRequest>(body);

            var result = await GakuGymAPI.AddFact(request.categoryId, request.values);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("UpdateFact", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<UpdateFactRequest>(body);

            await GakuGymAPI.UpdateFact(request.fact);

            context.Response.StatusCode = 200;
        });
        routeBuilder.MapPost("GetFact", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetFactRequest>(body);

            var result = await GakuGymAPI.GetFact(request.factId);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("SaveChallenge", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<SaveChallengeRequest>(body);

            var result = await GakuGymAPI.SaveChallenge(request.challenge);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("SaveFactChallengeData", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<SaveFactChallengeDataRequest>(body);

            var result = await GakuGymAPI.SaveFactChallengeData(request.factChallengeData);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("SaveStudy", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<SaveStudyRequest>(body);

            var result = await GakuGymAPI.SaveStudy(request.study);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetStudies", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }

            var result = await GakuGymAPI.GetStudies();

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetStudy", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetStudyRequest>(body);

            var result = await GakuGymAPI.GetStudy(request.studyId);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetStudySessionNewChallenges", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetStudySessionNewChallengesRequest>(body);

            var result = await GakuGymAPI.GetStudySessionNewChallenges(request.categoryId, request.lastNewChallengeDateTime);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("GetStudySessionReviewChallenges", async context => 
        {
            if(!Security.AuthorizeRequest(context))
            {
                context.Response.StatusCode = 401;
                return;
            }           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<GetStudySessionReviewChallengesRequest>(body);

            var result = await GakuGymAPI.GetStudySessionReviewChallenges(request.categoryId);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
        routeBuilder.MapPost("Authenticate", async context => 
        {           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();
            var request = JSON.Deserialize<AuthenticateRequest>(body);

            var result = await GakuGymAPI.Authenticate(request.password);

            var json = JSON.Serialize(result);

            context.Response.ContentType = "text/json";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));
        });
    } 
}