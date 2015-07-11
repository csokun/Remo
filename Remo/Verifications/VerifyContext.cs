namespace Remo.Verifications
{
	public class VerifyContext
	{
		private IVerifyStrategy _strategy;

		public VerifyContext(IVerifyStrategy strategy)
		{
			_strategy = strategy;
		}

		public bool Contains(string str)
		{
			return false;
		}
	}
}
