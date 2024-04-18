namespace EcoCode.Tests;

[TestClass]
public class AvoidFullSQLRequestUnitTests
{
    private static readonly VerifyDlg VerifyAsync = CodeFixVerifier.VerifyAsync<
        AvoidFullSQLRequestAnalyzer,
        AvoidFullSQLRequestFixProvider>;

    [TestMethod]
    public async Task EmptyCodeAsync() => await VerifyAsync("").ConfigureAwait(false);

    [TestMethod]
    public async Task AvoidFullSQLRequestAsync() => await VerifyAsync("""
        public class Test
        {
            public void Run()
            {
                string s = [|"select * from test;"|];
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task AvoidFullSQLRequestPropertyAsync() => await VerifyAsync("""
        public class Test
        {
            public static string s = [|"select * from test;"|];
            public void Run()
            {
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task AvoidFullSQLRequestPropertyEditedAsync() => await VerifyAsync("""
        public class Test
        {
            public static string s;
            public void Run()
            {
                s = [|"select * from test;"|];
            }
        }
        """).ConfigureAwait(false);

    [TestMethod]
    public async Task AvoidFullSQLRequestSelectHeadersAsync() => await VerifyAsync("""
        public class Test
        {
            public void Run()
            {
                string s = "select id from test;";
            }
        }
        """).ConfigureAwait(false);
}
