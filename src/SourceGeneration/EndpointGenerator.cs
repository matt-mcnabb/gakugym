namespace GakuGym.SourceGeneration;

using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

[Generator]
public class EndpointGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var apiMethodValues = context.SyntaxProvider.CreateSyntaxProvider
        (
            predicate: (node, _) => node is ClassDeclarationSyntax c && c.Identifier.ValueText == "GakuGymAPI",
            transform: (context, _) =>
            {
                var classDeclarationSyntax = (ClassDeclarationSyntax)context.Node;

                var symbol = context.SemanticModel.GetDeclaredSymbol(classDeclarationSyntax) as ITypeSymbol;

                if (symbol == null)
                    throw new InvalidOperationException("Unable to retreive symbol for class declaration!");

                return symbol.GetMembers().OfType<IMethodSymbol>().Where(x => x.MethodKind == MethodKind.Ordinary).Select(x => new GakuGymAPIMethodData(x));
            }
        )
        .SelectMany((x, _) => x)
        .Collect();

        context.RegisterSourceOutput(apiMethodValues, static (ctx, apiMethods) =>
        {
            if(apiMethods.Any())
               ctx.AddSource("Endpoints.MapEndpoints.g.cs", SourceText.From(GenerateSource(apiMethods), Encoding.UTF8));
        });
    }

    public static string GenerateSource(IEnumerable<GakuGymAPIMethodData> apiMethods)
    {
        var sb = new StringBuilder();

        sb.Append
        (
@"namespace GakuGym.Server;

using GakuGym.Common;

public static partial class Endpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder routeBuilder)
    {"
        );

        foreach(var apiMethod in apiMethods)
        {
            sb.Append
            (
$@"
        routeBuilder.MapPost(""{apiMethod.methodName}"", async context => 
        {{"
            );

            if(!apiMethod.hasNoAuthAttribute)
            {
                sb.Append
                (
$@"
            if(!Security.VerifyToken(context.Request.Headers[""Authorization""]))
            {{
                context.Response.StatusCode = 401;
                return;
            }}"
                );
            }

            if (apiMethod.parameters != null && apiMethod.parameters.Any())
            {
                sb.Append
                (
@"           
            var sr = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var body = await sr.ReadToEndAsync();"
                );

                sb.Append
                (
$@"
            var request = JSON.Deserialize<{apiMethod.methodName}Request>(body);"
                );
            }

            sb.AppendLine();
            sb.Append
            (
@"
            "
            );
            
            if (apiMethod.returnType != null)
                sb.Append("var result = ");

            sb.Append($"await gakuGymAPI.{apiMethod.methodName}(");

            sb.Append(String.Join(", ", apiMethod.parameters.Select(x => "request." + x.name)));

            sb.AppendLine(");");

            if (apiMethod.returnType != null)
            {
                sb.Append
                (
$@"
            var json = JSON.Serialize(result);

            context.Response.ContentType = ""text/json"";

            await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(json));"
                );
            }
            else
            {
                sb.Append
                (
@"
            context.Response.StatusCode = 200;"
                );
            }

            sb.Append
            (
@"
        });"
            );
        }

        sb.Append
        (
@"
    } 
}"
        );

        return sb.ToString();
    }
}
