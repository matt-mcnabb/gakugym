namespace GakuGym.SourceGeneration;

using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

[Generator]
public class RequestObjectGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var apiMethodValues = context.SyntaxProvider.CreateSyntaxProvider
        (
            predicate: (node, _) => node is InterfaceDeclarationSyntax c && c.Identifier.ValueText == "IGakuGymAPI",
            transform: (context, _) =>
            {
                var interfaceDeclarationSyntax = (InterfaceDeclarationSyntax)context.Node;

                var interfaceSymbol = context.SemanticModel.GetDeclaredSymbol(interfaceDeclarationSyntax) as ITypeSymbol;

                if (interfaceSymbol == null)
                    throw new InvalidOperationException("Unable to obtain symbol for interface declaration!");

                return interfaceSymbol.GetMembers().OfType<IMethodSymbol>().Select(x => new GakuGymAPIMethodData(x));
            }
        )
        .SelectMany((x, _) => x)
        .Collect();

        context.RegisterSourceOutput(apiMethodValues, static (ctx, apiMethods) =>
        {
            if(apiMethods.Any(x=>x.parameters.Any()))
                ctx.AddSource("RequestObjects.g.cs", SourceText.From(GenerateSource(apiMethods), Encoding.UTF8));
        });
    }

    public static string GenerateSource(IEnumerable<GakuGymAPIMethodData> apiMethods)
    {
        var sb = new StringBuilder();

        sb.Append
        (
@"namespace GakuGym.Common;
"
        );

        foreach (var apiMethod in apiMethods.Where(x=>x.parameters.Any()))
        {
            sb.Append
            (
$@"
public class {apiMethod.methodName}Request
{{"
            );
            
            foreach(var parameter in apiMethod.parameters)
            {
                sb.Append
                (
$@"
    public {parameter.type} {parameter.name};"
                );
            }

            sb.Append
            (
@"
}"
            );
        }

        return sb.ToString();
    }
}
