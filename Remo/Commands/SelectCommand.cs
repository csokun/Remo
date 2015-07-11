using OpenQA.Selenium.Support.UI;

namespace Remo.Commands
{
	public class SelectCommand: AbstractCommand
	{
		public override void Execute()
		{
			base.Execute();
			new SelectElement(Driver.FindElement(TestStep.Property.Current())).SelectByText(TestStep.Value);
		}

		public SelectCommand(TestStep testStep) : base(testStep)
		{
		}
	}
}
