using System.Reflection;
using BrewUp.Modules.Warehouses.Domain;
using BrewUp.Modules.Warehouses.Domain.CommandHandlers;
using NetArchTest.Rules;
using Xunit;

namespace BrewUp.Modules.Warehouses.NetArchTests;

public class VerifyArchitectureTest
{
	[Fact]
	public void Should_Architecture_BeCompliant()
	{
		var types = Types.InAssembly(typeof(IWarehousesFacade).Assembly)
			.That()
			.ResideInNamespace("BrewUp.Modules.Warehouses");
		
		var result = types
			.ShouldNot()
			.HaveDependencyOn("BrewUp.Modules.Purchases")
			.GetResult()
			.IsSuccessful;

		Assert.True(result);
	}

	[Fact]
	public void ShouldNot_Domain_HavingReferenceToReadModel()
	{
		var types = Types.InAssembly(typeof(WarehousesDomainHelper).Assembly)
			.That()
			.ResideInNamespace("BrewUp.Modules.Warehouses.Domain");
		
		var result = types
			.ShouldNot()
			.HaveDependencyOn("BrewUp.Modules.Warehouses.ReadModel")
			.GetResult()
			.IsSuccessful;

		Assert.True(result);
	}

	[Fact]
	public void CommandHandler_ShouldBeSealed()
	{
		var types = Types.InAssembly(typeof(CreateBeerCommandHandler).Assembly)
			.That()
			.ResideInNamespace("BrewUp.Modules.Warehouses.Domain.CommandHandlers");

		var result = types
			.Should()
			.BeSealed()
			.GetResult()
			.IsSuccessful;

		Assert.True(result);
	}
	
	[Fact]
	// Classes in the module Warehouses should have namespace starting with BrewUp.Modules.Warehouses
	public void WarehousesProjects_Should_Having_Namespace_StartingWith_BrewUp_Modules_Warehouses()
	{
		var purchaseModulePath = Path.Combine(VisualStudioProvider.TryGetSolutionDirectoryInfo().FullName, "BrewUp.Warehouses");
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

		var warehousesTypes = Types.InAssemblies(purchasesAssemblies);
		var warehousesResult = warehousesTypes
			.Should()
			.ResideInNamespaceStartingWith("BrewUp.Modules.Warehouses")
			.GetResult();

		Assert.True(warehousesResult.IsSuccessful);
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