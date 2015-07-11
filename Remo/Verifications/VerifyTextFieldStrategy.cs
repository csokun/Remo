using OpenQA.Selenium;

namespace Remo.Verifications
{
	/// <summary>
	/// Action = "Verify:Equals (Text)"
	/// </summary>
	public class VerifyTextFieldStrategy : IVerifyStrategy
	{
		public bool Contains(IWebElement element, string text)
		{
			return element.Text.Contains(text);
		}

		public bool Equal(IWebElement element, string text)
		{
			return text.Equals(element.Text);
		}

		public bool Exists(IWebElement element)
		{
			return element.Displayed;
		}
	}
}
