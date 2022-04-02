namespace GakuGym.SourceGeneration;

using Microsoft.CodeAnalysis;

public record GakuGymAPIMethodData
(
    string methodName,
    string? returnType,
    List<(string type, string name)> parameters,
    bool hasNoAuthAttribute
)
{
    public GakuGymAPIMethodData(IMethodSymbol methodSymbol) : this
    (
        methodName         : methodSymbol.Name,
        returnType         : methodSymbol.ReturnType.ToDisplayString() == "System.Threading.Tasks.Task" ? null : methodSymbol.ReturnType.ToDisplayString(),
        parameters         : methodSymbol.Parameters.Select(y => (y.Type.ToDisplayString(), y.Name)).ToList(),
        hasNoAuthAttribute : methodSymbol.GetAttributes().Any(x => x.AttributeClass?.Name == "NoAuthAttribute")
    ){}
}
