namespace Remo.Commands
{
	public class TypeCommand: AbstractCommand
	{
		public override void Execute()
		{
			Driver.FindElement(TestStep.Property.Current()).SendKeys(TestStep.Value);
		}

		public TypeCommand(TestStep testStep) : base(testStep)
		{
		}
	}
}
