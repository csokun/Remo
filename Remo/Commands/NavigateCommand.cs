using System;

namespace Remo.Commands
{
	public class NavigateCommand : AbstractCommand
	{
		public override void Execute()
		{
			base.Execute();
			Driver.Navigate().GoToUrl(new Uri(TestStep.Value));
		}

		public NavigateCommand(TestStep testStep) : base(testStep)
		{
		}
	}
}
