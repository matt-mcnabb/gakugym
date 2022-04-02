namespace GakuGym.SourceGeneration;

using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

[Generator]
public class ClientGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var apiMethodValues = context.SyntaxProvider.CreateSyntaxProvider
        (
            predicate: (node, _) => node is ClassDeclarationSyntax c && c.Identifier.ValueText == "GakuGymClient",
            transform: (context, _) =>
            {
                var classDeclarationSyntax = (ClassDeclarationSyntax)context.Node;

                var symbol = context.SemanticModel.GetDeclaredSymbol(classDeclarationSyntax) as ITypeSymbol;

                if (symbol == null)
                    throw new InvalidOperationException("Unable to retreive symbol for class declaration!");

                var interfaceSymbol = symbol.AllInterfaces.First();

                return interfaceSymbol.GetMembers().OfType<IMethodSymbol>().Select(x => new GakuGymAPIMethodData(x));
            }
        )
        .SelectMany((x, _) => x)
        .Collect();

        context.RegisterSourceOutput(apiMethodValues, static (ctx, apiMethods) =>
        {
            if(apiMethods.Any())
               ctx.AddSource("StudyGymClient.g.cs", SourceText.From(GenerateSource(apiMethods), Encoding.UTF8));
        });
    }

    private static string ExtractTaskType(string type)
    {
        return type.Substring("System.Threading.Tasks.Task<".Length, type.Length - "System.Threading.Tasks.Task<".Length - 1);
    }

    public static string GenerateSource(IEnumerable<GakuGymAPIMethodData> apiMethods)
    {
        var sb = new StringBuilder();

        sb.Append
        (
@"namespace GakuGym.Client;

using GakuGym.Common;

public partial class GakuGymClient : IGakuGymAPI
{"
        );

        foreach (var apiMethod in apiMethods)
        {
            sb.Append
            (
$@"
    public async {apiMethod.returnType ?? "Task"} {apiMethod.methodName}({String.Join(", ", apiMethod.parameters.Select(x => x.type + " " + x.name))})
    {{"
            );

            if(apiMethod.parameters.Any())
            { 
                sb.Append
                (
$@"
        var request = new {apiMethod.methodName}Request
        {{"
                );

                foreach(var parameter in apiMethod.parameters)
                {
                    sb.Append
                    (
$@"
            {parameter.name} = {parameter.name},"
                    );
                }

                sb.Append
                (
@"
        };"
                );

                sb.Append
                (
@"
        "
                );

                if(apiMethod.returnType != null)
                    sb.Append($@"return await PostRequest<{apiMethod.methodName}Request, {ExtractTaskType(apiMethod.returnType)}>(""{apiMethod.methodName}"", request);");
                else
                    sb.Append($@"await PostRequestVoid(""{apiMethod.methodName}"", request);");
            }
            else
            {
                if (apiMethod.returnType != null)
                    sb.Append($@"return await PostRequest<{ExtractTaskType(apiMethod.returnType)}>(""{apiMethod.methodName}"");");
                else
                    sb.Append($@"await PostRequestVoid(""{apiMethod.methodName}"");");
            }

            sb.Append
            (
@"
    }"
            );
        }

        sb.Append
        (
@"
}"
        );

        return sb.ToString();
    }
}
