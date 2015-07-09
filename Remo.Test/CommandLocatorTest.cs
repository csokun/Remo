using Moq;
using OpenQA.Selenium;
using Remo.Commands;
using Remo.Descriptor;
using Xunit;

namespace Remo.Test
{
	public class CommandLocatorTest
	{
		[Fact]
		public void Can_resolve_and_execute_Click_command()
		{
			// arrange
			var driver = new Mock<IWebDriver>();
			var element = new Mock<IWebElement>();

			element.Setup(e => e.Click()).Verifiable();
			driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(element.Object);

			var cl = CommandLocator.Instance();
			cl.Register();

			// act
			var cmd = cl.Create(new StepDescriptor() {Action = "Click", Property = new Element("id = Sokun")}, driver.Object);
			
			// assert
			Assert.NotNull(cmd);
			Assert.IsType<ClickCommand>(cmd);

			// act
			cmd.Execute();

			// verify
			element.Verify();
		}

		[Fact]
		public void Register_commands()
		{
			var cl = CommandLocator.Instance();
			cl.Register();

			Assert.False(cl.Contains("UnitTest"));
			Assert.True(cl.Contains("Navigate"));
		}
	}
}
