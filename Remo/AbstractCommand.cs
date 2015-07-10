using System;
using OpenQA.Selenium;

namespace Remo
{
	public abstract class AbstractCommand : IWebCommand
	{
		protected TestStep TestStep { get; private set; }
		protected IWebDriver Driver { get; private set; }

		protected AbstractCommand(TestStep testStep)
		{
			this.TestStep = testStep;
		}

		public IWebCommand SetDriver(IWebDriver driver)
		{
			this.Driver = driver;
			return this;
		}

		public virtual void Execute()
		{
			if (Driver == null)
				throw new NullReferenceException(
				"WebDriver is missing make sure you call SetDriver(IWebDriver) method before invoking execute() method");
		}
	}
}
