using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;

namespace Remo
{
	public class CommandFactory
	{
		/// <summary>
		/// Action & Class Name
		/// </summary>
		private static Dictionary<string, string> _commands;
		private static CommandFactory _factory;

		private CommandFactory()
		{
			_commands = new Dictionary<string, string>();
		}

		/// <summary>
		/// Register all known commands
		/// </summary>
		public static void Register()
		{
			if(_factory == null)
			{
				_factory = new CommandFactory();
			}

			_commands.Clear();
			// scan for all AbstractCommand sub-classes
			var type = typeof (IWebCommand);

			_commands = (from t in type.Assembly.GetTypes()
				where t.IsClass && t.GetInterfaces().Any(x => x == type && !t.IsAbstract) && t.Namespace.EndsWith("Commands")
				select new {Action = t.Name.Replace("Command", "").ToLower(), Type = t.FullName}).ToDictionary(k => k.Action, v => v.Type);
	
		}

		public static bool Contains(string commandName)
		{
			return _commands.ContainsKey(commandName.ToLower());
		}

		/// <summary>
		/// Create an instance of ICommand object and ready to be execute
		/// </summary>
		/// <param name="testStep"></param>
		/// <param name="driver"></param>
		/// <returns></returns>
		public static IWebCommand Activate(TestStep testStep)
		{
			if (string.IsNullOrWhiteSpace(testStep.Action)) 
				throw new Exception(testStep.Action + " is not a valid command.");

			var key = testStep.Action.Trim().ToLower();

			if (!_commands.ContainsKey(key))
				throw new Exception(testStep.Action + " is not a valid command.");

			Assembly assembly = typeof (IWebCommand).Assembly;
			var className = _commands[key];

			return (IWebCommand) Activator.CreateInstance(assembly.GetType(className), testStep);
		}

		public static IWebCommand Activate(TestStep testStep, IWebDriver driver)
		{
			return Activate(testStep).SetDriver(driver);
		}
	}
}
