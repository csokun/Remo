using System;
using System.IO;
using OpenQA.Selenium.Chrome;
using Remo.Datasources;
using Xunit;

namespace Remo.Test.Datasources
{
	public class ExcelSourceTest
	{
		[Fact]
		public void Throw_Exception_When_File_Not_Exists()
		{
			IOException ioExption = Assert.Throws<IOException>(() => new ExcelSource("file.xlsx"));

			Assert.Contains("file.xlsx does not exist.", ioExption.Message);
		}

		[Fact]
		public void Throw_Exception_NotSupportFileFormat()
		{
			Assert.Throws<FileFormatException>(() =>
				new ExcelSource(PathHelper.Artifacts("temp.txt")));
		}

		[Fact]
		public void Can_extract_unit_test_from_valid_SheetName()
		{
			// arrange
			var xls = new ExcelSource(Path.Combine(PathHelper.Artifacts("TEST_TEMPLATE.xlsx")));

			// act
			TestCase ut = xls.Get("TestCase-1");

			// assert
			Assert.NotNull(ut);
			Assert.True(ut.Steps > 0);
		}

		[Fact]
		public void Can_Execute_TestCase()
		{
			// arrange
			CommandFactory.Register();

			var xls = new ExcelSource(Path.Combine(PathHelper.Artifacts("TEST_TEMPLATE.xlsx")));
			TestCase ut = xls.Get("TestCase-1");

			// act
			using (var driver = new ChromeDriver())
			{
				ut.Run(driver);
			}

			Assert.Equal(TestResult.Passed, ut.Result);
		}

		[Fact]
		public void Can_verify_test_result()
		{
			// arrange
			CommandFactory.Register();

			var xls = new ExcelSource(Path.Combine(PathHelper.Artifacts("TEST_TEMPLATE.xlsx")));
			TestCase ut = xls.Get("TestCase-2");

			// act
			using (var driver = new ChromeDriver())
			{
				ut.Run(driver);
			}

			Assert.Equal(TestResult.Passed, ut.Result);
		}
	}
}