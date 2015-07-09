using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Remo.Commands
{
	public class SelectCommand: AbstractCommand
	{
		public SelectCommand(StepDescriptor step, IWebDriver driver) : base(step, driver)
		{
		}

		public override void Execute()
		{
			new SelectElement(driver.FindElement(step.Property.Select())).SelectByText(step.Value);
		}
	}
}
