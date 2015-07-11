using OpenQA.Selenium;

namespace Remo.Verifications
{
	public interface IVerifyStrategy
	{
		/// <summary>
		/// Verify that element contain specific string
		/// </summary>
		/// <param name="element"></param>
		/// <param name="text"></param>
		/// <returns></returns>
		bool Contains(IWebElement element, string text);

		/// <summary>
		/// Compare element value
		/// </summary>
		/// <param name="element"></param>
		/// <param name="text"></param>
		/// <returns></returns>
		bool Equal(IWebElement element, string text);

		/// <summary>
		/// Verify that a specific element exist / visible
		/// </summary>
		/// <returns></returns>
		bool Exists(IWebElement element);
	}
}
