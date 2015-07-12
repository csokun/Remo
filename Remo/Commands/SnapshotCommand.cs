﻿using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium.Support.Extensions;

namespace Remo.Commands
{
	public class SnapshotCommand : AbstractCommand
	{
		public override void Execute()
		{
			var directory = Directory.GetCurrentDirectory();
			
			Driver.Manage().Window.Maximize();

			var screenshot = Driver.TakeScreenshot();
			// save to current path
			screenshot.SaveAsFile(Path.Combine(directory, TestStep.Value), ImageFormat.Png);
		}

		public SnapshotCommand(TestStep testStep) : base(testStep)
		{
		}
	}
}
