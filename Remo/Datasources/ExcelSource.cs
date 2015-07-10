using System;
using System.IO;
using OfficeOpenXml;
using Remo.Descriptor;

namespace Remo.Datasources
{
	public class ExcelSource : IDatasource, IDisposable
	{
		private const int TestStepStartAt = 2;

		private ExcelPackage excelPackage;

		public ExcelSource(string filename)
		{
			var file = new FileInfo(filename);
			if (!file.Exists)
				throw new IOException(filename + " does not exist.");

			excelPackage = new ExcelPackage(file);
		}

		public TestCase Get(string testId)
		{
			var ws = excelPackage.Workbook.Worksheets[testId];
			try
			{
				TestCase ut = new TestCase();
				
				int row = TestStepStartAt;
				while (!string.IsNullOrWhiteSpace(ws.Cells["B" + row].GetValue<string>()))
				{
					var step = GetStepAt(row, ws);
					ut.Add(step);
					row ++;
				}

				return ut;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public void Report(TestCase unit)
		{
			throw new NotImplementedException();
		}

		#region Dispose Pattern https://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing) return;
			if (excelPackage != null) excelPackage.Dispose();
		}

		#endregion

		private TestStep GetStepAt(int row, ExcelWorksheet sheet)
		{
			var testStep = new TestStep
			{
				Action = sheet.Cells["B" + row].GetValue<string>(),
				Property = new Element(sheet.Cells["E" + row].GetValue<string>()),
				Value = sheet.Cells["D" + row].GetValue<string>(),
				Target = sheet.Cells["C" + row].GetValue<string>()
			};

			return testStep;
		}
	}
}
