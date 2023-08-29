using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using LaNacion.Data.Abstract.Repositories;
using System.Reflection;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace LaNacion.Test.Architecture
{
    public class RepositoriesArchTest
    {
        private static readonly Assembly Assembly = typeof(IContactRepository).Assembly;

        private static readonly ArchUnitNET.Domain.Architecture Architecture =
            new ArchLoader().LoadAssembly(Assembly).Build();

        [Fact]
        public void AllInterfacesStartWithI()
        {
            Assert.True(Architecture.Interfaces.All(i => i.Name.StartsWith("I")));
        }

        [Fact]
        public void AllInterfacesNamesShouldContainRepository()
        {
            IArchRule rule = Types().That().ResideInNamespace("LaNacion.Data.Abstract.Repositories").Should()
                .HaveFullNameContaining("Repository");

            rule.Check(Architecture);
        }

        [Fact]
        public void AllClassesNamesShouldContainRepository()
        {
            IArchRule rule = Types().That().ResideInNamespace("LaNacion.Data.Persistence.Repositories").Should()
                .HaveFullNameContaining("Repository");

            rule.Check(Architecture);
        }
    }
}
