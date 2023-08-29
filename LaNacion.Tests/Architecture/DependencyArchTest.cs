using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using LaNacion.Data.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using LaNacion.Data.Persistence.Repositories;
using LaNacion.API.Controllers;
using Xunit;
using Xunit.Abstractions;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace LaNacion.Test.Architecture
{
    public class DependencyArchTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public DependencyArchTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        //Defining the Architecture
        private static readonly ArchUnitNET.Domain.Architecture Architecture =
            new ArchLoader().LoadAssemblies(
                    typeof(ContactRepository).Assembly)
                .Build();

        //Defining the layers
        private readonly IObjectProvider<IType> _persistenceLayer =
            Types().That().ResideInNamespace("LaNacion.Data", true).As("Persistence Layer");

        private readonly IObjectProvider<IType> _areaControllers = Types().That()
            .ResideInNamespace("LaNacion.API", true)
            .And().AreAssignableTo(typeof(Controller));

        //Defining the facts to be checked
        [Fact]
        public void ControllerLayerShouldNotAccessPersistenceLayer()
        {
            IArchRule rule = Classes().That().Are(_areaControllers).Should().NotDependOnAny(_persistenceLayer);
            rule.Check(Architecture);
        }
    }
}
