using System;
using OpenQA.Selenium;

namespace Remo.Commands
{
	public class NavigateCommand : AbstractCommand
	{
		public NavigateCommand(StepDescriptor step, IWebDriver driver) : base(step, driver)
		{
		}

		public override void Execute()
		{
			driver.Navigate().GoToUrl(new Uri(step.Value));
		}
	}
}
