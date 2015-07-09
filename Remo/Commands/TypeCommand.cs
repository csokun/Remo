using OpenQA.Selenium;

namespace Remo.Commands
{
	public class TypeCommand: AbstractCommand
	{
		public TypeCommand(StepDescriptor step, IWebDriver driver) : base(step, driver)
		{
		}

		public override void Execute()
		{
			driver.FindElement(step.Property.Select()).SendKeys(step.Value);
		}
	}
}
