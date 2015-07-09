using System.Collections.Generic;

namespace Remo
{
	/// <summary>
	/// Represent single complete test case
	/// </summary>
	public class UnitTest: ICommand
	{
		private IList<ICommand> commands;

		/// <summary>
		/// Adding test step to form a complete test case
		/// </summary>
		/// <param name="cmd"></param>
		/// <returns></returns>
		public UnitTest Add(ICommand cmd)
		{
			this.commands.Add(cmd);
			return this;
		}
	
		public void Execute()
		{
			foreach (var command in commands)
			{
				command.Execute();
			}
		}

	}
}
