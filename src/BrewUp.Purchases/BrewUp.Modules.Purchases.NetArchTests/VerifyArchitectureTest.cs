using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using BrewUp.Modules.Purchases.Domain;
using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Modules.Purchases.ReadModel;
using BrewUp.Modules.Purchases.SharedKernel;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NetArchTest.Rules;

namespace BrewUp.Modules.Purchases.NetArchTests;

[ExcludeFromCodeCoverage]
public class VerifyArchitectureTest
{
	[Fact]
	public void Should_Architecture_BeCompliant()
	{
		var types = Types.InAssembly(typeof(Program).Assembly);

		var forbiddenAssemblies = new List<string>
		{
			"BrewUp.Modules.Purchases.Domain",
			"BrewUp.Modules.Purchases.Messages",
			"BrewUp.Modules.Purchases.ReadModel",
			"BrewUp.Modules.Purchases.SharedKernel",
			"BrewUp.Modules.Warehouses.Domain",
			"BrewUp.Modules.Warehouses.ReadModel"
		};

		var result = types
			.ShouldNot()
			.HaveDependencyOnAny(forbiddenAssemblies.ToArray())
			.GetResult()
			.IsSuccessful;

		Assert.True(result);
	}

	[Fact]
	public void Should_Presentation_HasDependency_Only_With_Facade()
	{
		var types = Types.InAssembly(typeof(Program).Assembly)
			.That()
			.ArePublic()
			.And()
			.AreClasses()
			.And()
			.AreNotAbstract()
			.And()
			.ResideInNamespaceStartingWith("BrewUp.Modules");

		var authorizedAssemblies = new List<string>
		{
			"BrewUp.Modules.Purchases",
			"BrewUp.Modules.Warehouses",
			"BrewUp.Modules.Sagas"
		}.ToArray();

		var result = types
			.Should()
			.HaveDependencyOnAny(authorizedAssemblies)
			.GetResult()
			.IsSuccessful;

		Assert.True(result);
	}

	[Fact]
	// Classes in the Domain should not directly reference ReadModel
	public void Domain_ShouldNot_HavingReferenceTo_Facade_And_ReadModel()
	{
		var types = Types.InAssembly(typeof(PurchasesDomainHelper).Assembly)
			.That()
			.ResideInNamespace("BrewUp.Modules.Purchases.Domain");

		var result = types
			.ShouldNot()
			.HaveDependencyOn("BrewUp.Modules.Purchases")
			.And()
			.HaveDependencyOn("BrewUp.Modules.Purchases.ReadModel")
			.GetResult()
			.IsSuccessful;

		Assert.True(result);
	}

	[Fact]
	// Classes in the module Purchases should not directly reference Sagas
	public void Purchases_ShouldNot_HavingReferenceTo_Sagas()
	{
		var types = Types.InAssembly(typeof(PurchasesDomainHelper).Assembly)
			.That()
			.ResideInNamespaceEndingWith("BrewUp.Modules.Purchases");

		var result = types
			.ShouldNot()
			.HaveDependencyOn("BrewUp.Modules.Sagas")
			.GetResult()
			.IsSuccessful;

		Assert.True(result);
	}

	[Fact]
	// Classes in the module Purchases should not directly reference Warehouses
	public void Purchases_ShouldNot_HavingReferenceTo_Warehouses()
	{
		var types = Types.InAssembly(typeof(PurchasesHelper).Assembly)
			.That()
			.ResideInNamespaceEndingWith("BrewUp.Modules.Purchases");

		var result = types
			.ShouldNot()
			.HaveDependencyOn("BrewUp.Modules.Warehouses")
			.And()
			.HaveDependencyOn("BrewUp.Modules.Warehouses.Domain")
			.And()
			.HaveDependencyOn("BrewUp.Modules.Warehouses.ReadModel")
			.GetResult()
			.IsSuccessful;

		Assert.True(result);
	}

	[Fact]
	// Classes in the module Purchases should have namespace starting with BrewUp.Modules.Purchases
	public void PurchasesProjects_Should_Having_Namespace_StartingWith_BrewUp_Modules_Purchases()
	{
		var purchaseModulePath = Path.Combine(VisualStudioProvider.TryGetSolutionDirectoryInfo().FullName, "BrewUp.Purchases");
		var subFolders = Directory.GetDirectories(purchaseModulePath);

		var netVersion = Environment.Version;

		var purchasesAssemblies = (from folder in subFolders
			let binFolder = Path.Join(folder, "bin", "Debug", $"net{netVersion.Major}.{netVersion.Minor}")
			let files = Directory.GetFiles(binFolder)
			let folderArray = folder.Split(Path.DirectorySeparatorChar)
			select files.FirstOrDefault(f => f.EndsWith($"{folderArray[folderArray!.Length - 1]}.dll"))
			into assemblyFilename
			where !assemblyFilename!.Contains("Test")
			select Assembly.LoadFile(assemblyFilename!)).ToList();

		var purchasesTypes = Types.InAssemblies(purchasesAssemblies);
		var purchasesResult = purchasesTypes
			.Should()
			.ResideInNamespaceStartingWith("BrewUp.Modules.Purchases")
			.GetResult();

		Assert.True(purchasesResult.IsSuccessful);
	}

	private static class VisualStudioProvider
	{
		public static DirectoryInfo TryGetSolutionDirectoryInfo(string? currentPath = null)
		{
			var directory = new DirectoryInfo(
				currentPath ?? Directory.GetCurrentDirectory());
			while (directory != null && !directory.GetFiles("*.sln").Any())
			{
				directory = directory.Parent;
			}
			return directory;
		}
	}
}