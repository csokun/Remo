using OpenQA.Selenium;

namespace Remo.Commands
{
	public class TypeCommand: AbstractCommand
	{
		public override void Execute()
		{
			Driver.FindElement(TestStep.Property.Select()).SendKeys(TestStep.Value);
		}

		public TypeCommand(TestStep testStep) : base(testStep)
		{
		}
	}
}
