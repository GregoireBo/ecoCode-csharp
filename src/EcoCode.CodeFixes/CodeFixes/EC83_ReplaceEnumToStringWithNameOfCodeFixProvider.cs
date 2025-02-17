﻿using Microsoft.CodeAnalysis.Operations;

namespace EcoCode.CodeFixes;

/// <summary>The code fix provider for replace enum ToString with nameof.</summary>
[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ReplaceEnumToStringWithNameOfCodeFixProvider)), Shared]
public sealed class ReplaceEnumToStringWithNameOfCodeFixProvider : CodeFixProvider
{
    /// <inheritdoc/>
    public override ImmutableArray<string> FixableDiagnosticIds => [ReplaceEnumToStringWithNameOfAnalyzer.Descriptor.Id];

    /// <inheritdoc/>
    public override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

    /// <inheritdoc/>
    public override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        if (context.Diagnostics.Length == 0) return;

        var document = context.Document;
        var root = await document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
        if (root is null) return;

        var nodeToFix = root.FindNode(context.Span, getInnermostNodeForTie: true);
        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Use nameof",
                createChangedDocument: token => RefactorAsync(document, nodeToFix, token),
                equivalenceKey: "Use nameof"),
            context.Diagnostics);
    }

    private static async Task<Document> RefactorAsync(Document document, SyntaxNode node, CancellationToken token)
    {
        var editor = await DocumentEditor.CreateAsync(document, token).ConfigureAwait(false);

        var newNode = editor.SemanticModel.GetOperation(node, token) switch
        {
            IInvocationOperation { Instance: { } } invocation => editor.Generator.NameOfExpression(invocation.Instance.Syntax),
            IInterpolationOperation interpolation => SyntaxFactory.Interpolation((ExpressionSyntax)editor.Generator.NameOfExpression(interpolation.Expression.Syntax)),
            _ => null,
        };

        if (newNode is null) return document;

        editor.ReplaceNode(node, newNode);
        return editor.GetChangedDocument();
    }
}
