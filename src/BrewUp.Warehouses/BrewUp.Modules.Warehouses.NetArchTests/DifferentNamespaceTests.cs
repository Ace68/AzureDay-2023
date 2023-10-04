using BrewUp.Modules.Warehouses;
using NetArchTest.Rules;
using Xunit;

namespace Faking.Example.Tests;

public class DifferentNamespaceTests
{
    [Fact]
    public void Should_Architecture_BeCompliant()
    {
        var types = Types.InCurrentDomain()
            .That()
            .ResideInNamespace("BrewUp.Modules.Warehouses");

        var domain = AppDomain.CurrentDomain;
		
        var result = types
            .ShouldNot()
            .HaveDependencyOn("BrewUp.Modules.Purchases")
            .GetResult()
            .IsSuccessful;

        Assert.True(result);
    }
}