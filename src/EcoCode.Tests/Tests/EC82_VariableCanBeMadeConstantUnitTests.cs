﻿namespace EcoCode.Tests;

[TestClass]
public class VariableCanBeMadeConstantUnitTests
{
    private static readonly VerifyDlg VerifyAsync = CodeFixVerifier.VerifyAsync<
        VariableCanBeMadeConstantAnalyzer,
        VariableCanBeMadeConstantCodeFixProvider>;

    [TestMethod]
    public async Task EmptyCodeAsync() => await VerifyAsync("").ConfigureAwait(false);

    [TestMethod]
    public async Task VariableCanBeConstAsync() => await VerifyAsync("""
        using System;
        public class Program
        {
            public static void Main()
            {
                [|int i = 0;|]
                Console.WriteLine(i);
            }
        }
        """,
        fixedSource: """
        using System;
        public class Program
        {
            public static void Main()
            {
                const int i = 0;
                Console.WriteLine(i);
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task VariableIsReassignedAsync() => await VerifyAsync("""
        using System;
        public class Program
        {
            public static void Main()
            {
                int i = 0;
                Console.WriteLine(i++);
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task VariableIsAlreadyConstAsync() => await VerifyAsync("""
        using System;
        public class Program
        {
            public static void Main()
            {
                const int i = 0;
                Console.WriteLine(i);
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task VariableHasNoInitializerAsync() => await VerifyAsync("""
        using System;
        public class Program
        {
            public static void Main()
            {
                int i;
                i = 0;
                Console.WriteLine(i);
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task VariableCannotBeConstAsync() => await VerifyAsync("""
        using System;
        public class Program
        {
            public static void Main()
            {
                int i = DateTime.Now.DayOfYear;
                Console.WriteLine(i);
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task VariableWithMultipleInitializersCannotBeConstAsync() => await VerifyAsync("""
        using System;
        public class Program
        {
            public static void Main()
            {
                int i = 0, j = DateTime.Now.DayOfYear;
                Console.WriteLine(i);
                Console.WriteLine(j);
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task VariableWithMultipleInitializersCanBeConstAsync() => await VerifyAsync("""
        using System;
        public class Program
        {
            public static void Main()
            {
                [|int i = 0, j = 0;|]
                Console.WriteLine(i);
                Console.WriteLine(j);
            }
        }
        """,
        fixedSource: """
        using System;
        public class Program
        {
            public static void Main()
            {
                const int i = 0, j = 0;
                Console.WriteLine(i);
                Console.WriteLine(j);
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task VariableInitializerIsInvalidAsync() => await VerifyAsync("""
        using System;
        public class Program
        {
            public static void Main()
            {
                int x = {|CS0029:"abc"|};
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task StringObjectCannotBeConstAsync() => await VerifyAsync("""
        using System;
        public class Program
        {
            public static void Main()
            {
                object s = "abc";
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task StringCanBeConstAsync() => await VerifyAsync("""
        using System;
        public class Program
        {
            public static void Main()
            {
                [|string s = "abc";|]
            }
        }
        """,
        fixedSource: """
        using System;
        public class Program
        {
            public static void Main()
            {
                const string s = "abc";
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task VarIntCanBeConstAsync() => await VerifyAsync("""
        using System;
        public class Program
        {
            public static void Main()
            {
                [|var item = 4;|]
            }
        }
        """,
        fixedSource: """
        using System;
        public class Program
        {
            public static void Main()
            {
                const int item = 4;
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task VarStringCanBeConstAsync() => await VerifyAsync("""
        using System;
        public class Program
        {
            public static void Main()
            {
                [|var item = "abc";|]
            }
        }
        """,
        fixedSource: """
        using System;
        public class Program
        {
            public static void Main()
            {
                const string item = "abc";
            }
        }
        """).ConfigureAwait(false);
}
