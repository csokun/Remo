using System;
using OpenQA.Selenium.Chrome;
using Remo.Commands;
using Xunit;

namespace Remo.Test
{
	public class NavigateCommandTest
	{
		[Fact]
		public void Can_Navigate()
		{
			using (var driver = new ChromeDriver())
			{
				var step = new TestStep {Value = "http://play.joljet.net"};
				var navigate = new NavigateCommand(step);
				navigate.SetDriver(driver);
				navigate.Execute();
			}
		}

		[Fact]
		public void Navigate_bad_url()
		{
			using (var driver = new ChromeDriver())
			{
				var step = new TestStep {Value = "testing something"};
				var navigate = new NavigateCommand(step);
				navigate.SetDriver(driver);

				Exception ex = Assert.Throws<UriFormatException>(() => navigate.Execute());
			}
		}
	}
}