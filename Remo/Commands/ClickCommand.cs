using OpenQA.Selenium;
using Remo.Descriptor;

namespace Remo.Commands
{
	public class ClickCommand : AbstractCommand
	{
		public ClickCommand(StepDescriptor step, IWebDriver driver) : base(step, driver)
		{
		}

		public override void Execute()
		{
			driver.FindElement(step.Property.Select()).Click();
		}
	}
}
