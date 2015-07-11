using Moq;
using OpenQA.Selenium;
using Remo.Verifications;
using Xunit;

namespace Remo.Test
{
	public class VerifyEqualsTextStrategyTest
	{
		[Fact]
		public void Verify_contains_and_equals()
		{
			// arrange
			var element = new Mock<IWebElement>();
			element.Setup(t => t.Text).Returns("Melbourne City");
			var strategy = new VerifyTextFieldStrategy();

			// act and assert
			Assert.True(strategy.Contains(element.Object, "City"));
			Assert.True(strategy.Contains(element.Object, "Melbourne City"));

			element.Verify(t => t.Text, Times.Exactly(2));
		}
	}
}
