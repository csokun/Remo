using OpenQA.Selenium;

namespace Remo
{
	public abstract class AbstractCommand : ICommand
	{
		protected StepDescriptor step;
		protected IWebDriver driver;

		protected AbstractCommand(StepDescriptor step, IWebDriver driver)
		{
			this.step = step;
			this.driver = driver;
		}
		
		public abstract void Execute();
	}
}
