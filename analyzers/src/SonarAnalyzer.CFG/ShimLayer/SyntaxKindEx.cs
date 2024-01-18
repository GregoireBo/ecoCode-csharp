﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using Microsoft.CodeAnalysis.CSharp;

    public static class SyntaxKindEx
    {
        public const SyntaxKind DotDotToken = (SyntaxKind)8222;
        public const SyntaxKind QuestionQuestionEqualsToken = (SyntaxKind)8284;
        public const SyntaxKind GreaterThanGreaterThanGreaterThanToken = (SyntaxKind)8286;
        public const SyntaxKind GreaterThanGreaterThanGreaterThanEqualsToken = (SyntaxKind)8287;
        public const SyntaxKind NameOfKeyword = (SyntaxKind)8434;
        public const SyntaxKind InitKeyword = (SyntaxKind)8443;
        public const SyntaxKind ManagedKeyword = (SyntaxKind)8445;
        public const SyntaxKind UnmanagedKeyword = (SyntaxKind)8446;
        public const SyntaxKind FileKeyword = (SyntaxKind)8449;
        public const SyntaxKind NullableKeyword = (SyntaxKind)8486;
        public const SyntaxKind EnableKeyword = (SyntaxKind)8487;
        public const SyntaxKind WarningsKeyword = (SyntaxKind)8488;
        public const SyntaxKind AnnotationsKeyword = (SyntaxKind)8489;
        public const SyntaxKind VarKeyword = (SyntaxKind)8490;
        public const SyntaxKind UnderscoreToken = (SyntaxKind)8491;
        public const SyntaxKind SingleLineRawStringLiteralToken = (SyntaxKind)8518;
        public const SyntaxKind MultiLineRawStringLiteralToken = (SyntaxKind)8519;
        public const SyntaxKind Utf8StringLiteralToken = (SyntaxKind)8520;
        public const SyntaxKind Utf8SingleLineRawStringLiteralToken = (SyntaxKind)8521;
        public const SyntaxKind Utf8MultiLineRawStringLiteralToken = (SyntaxKind)8522;
        public const SyntaxKind PragmaChecksumDirectiveTrivia = (SyntaxKind)8560;
        public const SyntaxKind ConflictMarkerTrivia = (SyntaxKind)8564;
        public const SyntaxKind IsPatternExpression = (SyntaxKind)8657;
        public const SyntaxKind RangeExpression = (SyntaxKind)8658;
        public const SyntaxKind ImplicitObjectCreationExpression = (SyntaxKind)8659;
        public const SyntaxKind UnsignedRightShiftExpression = (SyntaxKind)8692;
        public const SyntaxKind CoalesceAssignmentExpression = (SyntaxKind)8725;
        public const SyntaxKind UnsignedRightShiftAssignmentExpression = (SyntaxKind)8726;
        public const SyntaxKind IndexExpression = (SyntaxKind)8741;
        public const SyntaxKind DefaultLiteralExpression = (SyntaxKind)8755;
        public const SyntaxKind Utf8StringLiteralExpression = (SyntaxKind)8756;
        public const SyntaxKind LocalFunctionStatement = (SyntaxKind)8830;
        public const SyntaxKind GlobalStatement = (SyntaxKind)8841;
        public const SyntaxKind FileScopedNamespaceDeclaration = (SyntaxKind)8845;
        public const SyntaxKind ArrowExpressionClause = (SyntaxKind)8917;
        public const SyntaxKind TupleType = (SyntaxKind)8924;
        public const SyntaxKind TupleElement = (SyntaxKind)8925;
        public const SyntaxKind TupleExpression = (SyntaxKind)8926;
        public const SyntaxKind SingleVariableDesignation = (SyntaxKind)8927;
        public const SyntaxKind ParenthesizedVariableDesignation = (SyntaxKind)8928;
        public const SyntaxKind ForEachVariableStatement = (SyntaxKind)8929;
        public const SyntaxKind DeclarationPattern = (SyntaxKind)9000;
        public const SyntaxKind ConstantPattern = (SyntaxKind)9002;
        public const SyntaxKind CasePatternSwitchLabel = (SyntaxKind)9009;
        public const SyntaxKind WhenClause = (SyntaxKind)9013;
        public const SyntaxKind DiscardDesignation = (SyntaxKind)9014;
        public const SyntaxKind RecursivePattern = (SyntaxKind)9020;
        public const SyntaxKind PropertyPatternClause = (SyntaxKind)9021;
        public const SyntaxKind Subpattern = (SyntaxKind)9022;
        public const SyntaxKind PositionalPatternClause = (SyntaxKind)9023;
        public const SyntaxKind DiscardPattern = (SyntaxKind)9024;
        public const SyntaxKind SwitchExpression = (SyntaxKind)9025;
        public const SyntaxKind SwitchExpressionArm = (SyntaxKind)9026;
        public const SyntaxKind VarPattern = (SyntaxKind)9027;
        public const SyntaxKind ParenthesizedPattern = (SyntaxKind)9028;
        public const SyntaxKind RelationalPattern = (SyntaxKind)9029;
        public const SyntaxKind TypePattern = (SyntaxKind)9030;
        public const SyntaxKind OrPattern = (SyntaxKind)9031;
        public const SyntaxKind AndPattern = (SyntaxKind)9032;
        public const SyntaxKind NotPattern = (SyntaxKind)9033;
        public const SyntaxKind SlicePattern = (SyntaxKind)9034;
        public const SyntaxKind ListPattern = (SyntaxKind)9035;
        public const SyntaxKind DeclarationExpression = (SyntaxKind)9040;
        public const SyntaxKind RefExpression = (SyntaxKind)9050;
        public const SyntaxKind RefType = (SyntaxKind)9051;
        public const SyntaxKind ThrowExpression = (SyntaxKind)9052;
        public const SyntaxKind ImplicitStackAllocArrayCreationExpression = (SyntaxKind)9053;
        public const SyntaxKind SuppressNullableWarningExpression = (SyntaxKind)9054;
        public const SyntaxKind NullableDirectiveTrivia = (SyntaxKind)9055;
        public const SyntaxKind FunctionPointerType = (SyntaxKind)9056;
        public const SyntaxKind FunctionPointerParameter = (SyntaxKind)9057;
        public const SyntaxKind FunctionPointerParameterList = (SyntaxKind)9058;
        public const SyntaxKind FunctionPointerCallingConvention = (SyntaxKind)9059;
        public const SyntaxKind InitAccessorDeclaration = (SyntaxKind)9060;
        public const SyntaxKind WithExpression = (SyntaxKind)9061;
        public const SyntaxKind WithInitializerExpression = (SyntaxKind)9062;
        public const SyntaxKind RecordClassDeclaration = (SyntaxKind)9063;
        public const SyntaxKind PrimaryConstructorBaseType = (SyntaxKind)9065;
        public const SyntaxKind FunctionPointerUnmanagedCallingConventionList = (SyntaxKind)9066;
        public const SyntaxKind FunctionPointerUnmanagedCallingConvention = (SyntaxKind)9067;
        public const SyntaxKind RecordStructDeclaration = (SyntaxKind)9068;
        public const SyntaxKind ExpressionColon = (SyntaxKind)9069;
        public const SyntaxKind InterpolatedSingleLineRawStringStartToken = (SyntaxKind)9072;
        public const SyntaxKind InterpolatedMultiLineRawStringStartToken = (SyntaxKind)9073;
        public const SyntaxKind InterpolatedRawStringEndToken = (SyntaxKind)9074;
        public const SyntaxKind ScopedType = (SyntaxKind)9075;
    }
}
