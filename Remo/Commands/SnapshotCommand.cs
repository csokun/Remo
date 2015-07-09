using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Remo.Commands
{
	public class SnapshotCommand : AbstractCommand
	{
		public SnapshotCommand(StepDescriptor step, IWebDriver driver) : base(step, driver)
		{
		}

		public override void Execute()
		{
			var directory = Directory.GetCurrentDirectory();
			var screenshot = driver.TakeScreenshot();

			screenshot.SaveAsFile(Path.Combine(directory, step.Value), ImageFormat.Png);
		}
	}
}
