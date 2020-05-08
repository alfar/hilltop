using Xunit;
using NSubstitute;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Hilltop.Core.Web.Controllers;
using Hilltop.Core.Web.Controllers.Interfaces;
using Hilltop.Core.Web.Controllers.Helpers;
using System.Collections.Generic;

namespace Hilltop.Core.Web.Test.Controllers
{
    public class HilltopControllerBaseTest
    {
        [Fact]
        public void TestName()
        {
            //Given
            var myOutput = new { prop1 = "Property 1", prop2 = "Property 2" };

            var modifications = Substitute.For<IModificationsRegistry>();
            var modifier = Substitute.For<IModifier>();

            modifications.GetModifiers(myOutput).Returns(new List<IModifier>() { modifier });
            modifier
                .When(m =>
                    {
                        m.Modify(Arg.Any<Actionable>());
                    })
                .Do(c =>
                    {
                        c.ArgAt<IModifiable>(0).AddValue("prop3", "Added Value");
                    });

            var sut = new HilltopControllerBase(modifications);

            //When
            var result = sut.Ok(myOutput);

            //Then
            var output = result.Should().BeOfType<OkObjectResult>().Which.Value as Actionable;
            output.Should().NotBeNull();
            output.Value.Value<string>("prop1").Should().Be("Property 1");
            output.Value.Value<string>("prop2").Should().Be("Property 2");
            output.Value.Value<string>("prop3").Should().Be("Added Value");

            modifications.Received().GetModifiers(myOutput);
        }
    }
}