using Xunit;
using NSubstitute;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Hilltop.Core.Web.Controllers;
using Hilltop.Core.Web.Controllers.Interfaces;
using Hilltop.Core.Web.Controllers.Helpers;
using System.Collections.Generic;
using System.Dynamic;

namespace Hilltop.Core.Web.Test.Controllers
{
    public class HilltopControllerBaseTest
    {
        public interface ITest
        {
            string Prop1 { get; set; }
            string Prop2 { get; set; }
        }

        public class TestEntity : ITest
        {
            public string Prop1 { get; set; }
            public string Prop2 { get; set; }
        }

        [Fact]
        public void TestName()
        {
            //Given
            var myOutput = new TestEntity() { Prop1 = "Property 1", Prop2 = "Property 2" };

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
            dynamic output = result.Should().BeOfType<OkObjectResult>().Which.Value as ExpandoObject;
            ((object)output).Should().NotBeNull();
            ((string)output.prop1).Should().Be("Property 1");
            ((string)output.prop2).Should().Be("Property 2");
            ((string)output.prop3).Should().Be("Added Value");

            modifications.Received().GetModifiers(myOutput);
        }
    }
}