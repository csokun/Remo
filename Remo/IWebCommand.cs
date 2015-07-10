using OpenQA.Selenium;

namespace Remo
{
	public interface IWebCommand
	{
		IWebCommand SetDriver(IWebDriver driver);

		void Execute();
	}
}
