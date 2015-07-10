using Moq;
using OpenQA.Selenium;
using Remo.Commands;
using Remo.Descriptor;
using Xunit;

namespace Remo.Test
{
	public class CommandFactoryTest
	{
		public CommandFactoryTest()
		{
			CommandFactory.Register();
		}

		[Fact]
		public void Can_resolve_and_execute_Click_command()
		{
			// arrange
			var driver = new Mock<IWebDriver>();
			var element = new Mock<IWebElement>();

			element.Setup(e => e.Click()).Verifiable();
			driver.Setup(d => d.FindElement(It.IsAny<By>())).Returns(element.Object);

			// act
			var cmd = CommandFactory.Activate(new TestStep {Action = "Click", Property = new Element("id = Sokun")});
			
			// assert
			Assert.NotNull(cmd);
			Assert.IsType<ClickCommand>(cmd);

			// arrange
			cmd.SetDriver(driver.Object);

			// act
			cmd.Execute();

			// verify
			element.Verify();
		}

		[Fact]
		public void Register_commands()
		{
			Assert.False(CommandFactory.Contains("UnitTest"));
			Assert.True(CommandFactory.Contains("Navigate"));
		}
	}
}