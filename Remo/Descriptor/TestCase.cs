using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenQA.Selenium;

namespace Remo
{
	/// <summary>
	/// Represent single complete test case
	/// </summary>
	public class TestCase
	{
		private IList<TestStep> steps;
		
		public TestCase()
		{
			steps = new List<TestStep>();
		}

		public int Steps
		{
			get { return steps.Count; }
		}

		/// <summary>
		/// Adding test step to form a complete test case
		/// </summary>
		/// <param name="testStep"></param>
		/// <returns></returns>
		public TestCase Add(TestStep testStep)
		{
			this.steps.Add(testStep);
			return this;
		}

		public TestResult Result { get; private set; }

		public void Run(IWebDriver driver)
		{
			Result = TestResult.NoRun;

			for (int i = 0; i < Steps; i++)
			{
				try
				{
					CommandFactory.Activate(this.steps[i]).SetDriver(driver).Execute();
				}
				catch(Exception e)
				{
					Debug.Print(e.Message);
					Result = TestResult.Failed;
					return;
				}
			}

			Result = TestResult.Passed;
		}

	}

	public enum TestResult
	{
		NoRun,
		Failed,
		Passed
	}
}
