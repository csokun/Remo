namespace Remo.Commands
{
	public class VerifyCommand : AbstractCommand
	{
		public VerifyCommand(TestStep testStep) : base(testStep)
		{
		}

		public override void Execute()
		{
			base.Execute();
			var strategyKey = string.Format("{0}{1}", this.TestStep.Action.Split(':')[1], TestStep.Property); 
			var strategy = VerificationStrategyFactory.Get(strategyKey);
			// object type

		}
	}
}
