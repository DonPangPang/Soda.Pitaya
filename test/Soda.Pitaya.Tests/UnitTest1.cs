using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace Soda.Pitaya.Tests;

public class UnitTest1
{
    [Fact]
    public void Demo()
    {
        string code1 = @"
    public class ScriptedClass
    {
        public string HelloWorld { get; set; }
        public ScriptedClass()
        {
            HelloWorld = ""Hello Roslyn!"";
        }
    }";

        var script = CSharpScript.RunAsync(code1).Result;

        var result = script.ContinueWithAsync<string>("new ScriptedClass().HelloWorld").Result;

        Assert.Equal("Hello Roslyn!", result.ReturnValue);
    }
}