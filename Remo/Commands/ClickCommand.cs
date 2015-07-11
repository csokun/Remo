namespace Remo.Commands
{
	public class ClickCommand : AbstractCommand
	{
		public override void Execute()
		{
			base.Execute();
			Driver.FindElement(TestStep.Property.Current()).Click();
		}

		public ClickCommand(TestStep testStep) : base(testStep)
		{
		}
	}
}
