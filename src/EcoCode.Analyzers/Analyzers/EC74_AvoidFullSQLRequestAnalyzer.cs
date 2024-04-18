using System.Text.RegularExpressions;

namespace EcoCode.Analyzers;

/// <summary>Analyzer for don't concatenate strings in loops.</summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class AvoidFullSQLRequestAnalyzer : DiagnosticAnalyzer
{
    private static readonly ImmutableArray<SyntaxKind> SyntaxKinds = [
        SyntaxKind.StringLiteralExpression];

    /// <summary>The diagnostic descriptor.</summary>
    public static DiagnosticDescriptor Descriptor { get; } = new(
        Rule.Ids.EC74_AvoidFullSQLRequest,
        title: "Don't use the query SELECT * FROM",
        messageFormat: "Don't use the query SELECT * FROM",
        Rule.Categories.Performance,
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: null,
        helpLinkUri: Rule.GetHelpUri(Rule.Ids.EC74_AvoidFullSQLRequest));

    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => [Descriptor];

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(static context => AnalyzeStringLitteralExpression(context), SyntaxKinds);
    }

    private static void AnalyzeStringLitteralExpression(SyntaxNodeAnalysisContext context)
    {
        if (Regex.Match(context.Node.ToString(), @"select\s*\*\s*from").Success)
            context.ReportDiagnostic(Diagnostic.Create(Descriptor, context.Node.GetLocation()));
    }
}
