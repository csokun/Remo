using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;
using Remo.Descriptor;

namespace Remo
{
	public class CommandLocator
	{
		/// <summary>
		/// Action & Class Name
		/// </summary>
		private Dictionary<string, string> _commands;
		private static CommandLocator _locator;

		private CommandLocator()
		{
			this._commands = new Dictionary<string, string>();
		}

		public static CommandLocator Instance()
		{
			return _locator ?? (_locator = new CommandLocator());
		}

		public void Register()
		{
			this._commands.Clear();

			// scan for all AbstractCommand sub-classes
			var type = typeof (ICommand);
			var commands = (from t in type.Assembly.GetTypes()
				where t.IsClass && t.GetInterfaces().Any(x => x == type && !t.IsAbstract) && t.Namespace.EndsWith("Commands")
				select new {Action = t.Name.Replace("Command", ""), Type = t.FullName}).ToDictionary(k => k.Action, v => v.Type);

			this._commands = commands;
		}

		public bool Contains(string commandName)
		{
			return _commands.ContainsKey(commandName);
		}

		/// <summary>
		/// Create an instance of ICommand object and ready to be execute
		/// </summary>
		/// <param name="step"></param>
		/// <param name="driver"></param>
		/// <returns></returns>
		public ICommand Create(StepDescriptor step, IWebDriver driver)
		{
			if (string.IsNullOrWhiteSpace(step.Action)) return null;

			var key = step.Action.Trim().ToLower();

			if (!this._commands.ContainsKey(key)) return null;
			Assembly assembly = Assembly.GetExecutingAssembly();
			var className = this._commands[key];

			return (ICommand) Activator.CreateInstance(assembly.GetType(className), step, driver);
		}
	}
}
