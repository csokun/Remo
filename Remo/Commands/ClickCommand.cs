namespace Remo.Commands
{
	public class ClickCommand : AbstractCommand
	{
		public override void Execute()
		{
			base.Execute();
			Driver.FindElement(TestStep.Property.Select()).Click();
		}

		public ClickCommand(TestStep testStep) : base(testStep)
		{
		}
	}
}
