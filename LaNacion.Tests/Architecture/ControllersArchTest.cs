using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LaNacion.API.Controllers;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace LaNacion.Test.Architecture
{
    public class ControllersArchTest
    {
        private static readonly ArchUnitNET.Domain.Architecture Architecture =
            new ArchLoader().LoadAssembly(
                    typeof(ContactController).Assembly)
                .Build();

        private readonly IObjectProvider<IType> _areaControllers = Types().That()
                .ResideInNamespace("LaNacion.API", true)
                .And().AreAssignableTo(typeof(Controller));

        [Fact]
        public void AllControllersInAreasShouldHaveAreaAttribute()
        {
            IArchRule rule = Types().That().Are(_areaControllers)
                .Should().HaveAnyAttributes(typeof(AreaAttribute));
            
            rule.Check(Architecture);
        }

        [Fact]
        public void AllControllersInAreasShouldHaveAuthorizeAttribute()
        {
            IArchRule rule = Types().That().Are(_areaControllers)
                .Should().HaveAnyAttributes(typeof(AuthorizeAttribute));
            rule.Check(Architecture);
        }

        [Fact]
        public void AllControllersPublicMethodsShouldHaveHttpMethodAttribute()
        {
            IArchRule rule = MethodMembers().That()
                .AreDeclaredIn(_areaControllers)
                .And().ArePublic()
                .And().AreNoConstructors()
                .Should().HaveAnyAttributes(typeof(HttpPostAttribute), typeof(HttpGetAttribute));

            rule.Check(Architecture);
        }

        [Fact]
        public void AllControllersPostMethodsShouldHaveValidateAntiForgeryToken()
        {
            IArchRule rule = MethodMembers().That()
                .AreDeclaredIn(_areaControllers)
                .And().HaveAnyAttributes(typeof(HttpPostAttribute))
                .Should().HaveAnyAttributes(typeof(ValidateAntiForgeryTokenAttribute));

            rule.Check(Architecture);
        }
    }
}
