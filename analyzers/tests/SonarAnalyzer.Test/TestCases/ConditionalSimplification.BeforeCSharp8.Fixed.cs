﻿using System.Collections.Generic;

namespace Tests.TestCases
{
    class ConditionalSimplification
    {
        void NullCoalesceAssignment(object a, object b)
        {
            //??= can be used from C# 8 only
            a = a ?? b;                 // Compliant, this time
            a = a ?? b;    // Fixed
            a = a ?? b;    // Fixed

            a = a ?? b;

            bool? value = null;
            value = value ?? false;

        }
    }

    // https://github.com/SonarSource/sonar-dotnet/issues/4962
    class FPRepro_4962
    {
        public static string TestFunction(string key1, string key2)
        {
            var dictionary1 = new Dictionary<string, string>();
            var dictionary2 = new Dictionary<string, string>();

            string value;
            if (string.IsNullOrEmpty(key1)) dictionary2.TryGetValue(key2, out value);
            else dictionary1.TryGetValue(key1, out value);

            return value;
        }
    }
}
