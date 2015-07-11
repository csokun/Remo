using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Remo.Verifications;

namespace Remo
{
	public class VerificationStrategyFactory
	{
		private static Dictionary<string, string> _strategies;
		private static VerificationStrategyFactory _verificationStrategyFactory;

		private VerificationStrategyFactory()
		{
			_strategies = new Dictionary<string, string>();
		}

		public static void Register()
		{
			if (_verificationStrategyFactory == null)
				_verificationStrategyFactory = new VerificationStrategyFactory();

			_strategies.Clear();

			// register all verification strategies
			var type = typeof (IVerifyStrategy);
			_strategies = (from t in type.Assembly.GetTypes()
									 where t.IsClass && t.GetInterfaces().Any(x => x == type && !t.IsAbstract) && t.Namespace.EndsWith("Verfications")
									 select new { Action = t.Name.Replace("Strategy", "").ToLower(), Type = t.FullName }).ToDictionary(k => k.Action, v => v.Type);
		}

		public IVerifyStrategy Get(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
				throw new Exception("Verification key is missing.");
			// normalize key
			var normalizedKey = key.Replace(":", "").ToLower();
			if (!_strategies.ContainsKey(normalizedKey))
				throw new Exception("Can't resolve " + key + " strategy.");

			Assembly assembly = typeof(IVerifyStrategy).Assembly;
			var className = _strategies[key];

			return (IVerifyStrategy)Activator.CreateInstance(assembly.GetType(className));

		}
	}
}
