namespace Remo.Datasources
{
	public interface IDatasource
	{
		/// <summary>
		/// Retreiving unit test from data source
		/// </summary>
		/// <param name="testId"></param>
		/// <returns></returns>
		TestCase Get(string testId);

		/// <summary>
		/// Update data source if needed
		/// </summary>
		/// <param name="unit"></param>
		void Report(TestCase unit);
	}
}
