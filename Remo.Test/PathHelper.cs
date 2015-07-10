using System;
using System.IO;
using System.Linq;

namespace Remo.Test
{
	public static class PathHelper
	{
		/// <summary>
		///   Traverse back to top folder from bin\debug or bin\release
		/// </summary>
		/// <returns></returns>
		public static string GetTestProjectPath()
		{
			var startupPath = AppDomain.CurrentDomain.BaseDirectory;
			var pathItems = startupPath.Split(Path.DirectorySeparatorChar);
			return string.Join(Path.DirectorySeparatorChar.ToString(), pathItems.Take(pathItems.Length - 2));
		}

		public static string Artifacts(string filename)
		{
			return Path.Combine(PathHelper.GetTestProjectPath(), "Artifacts", filename);
		}
	}
}