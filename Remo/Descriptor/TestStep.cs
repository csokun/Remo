using Remo.Descriptor;

namespace Remo
{
	public class TestStep
	{	
		public string Action { get; set; }
		
		public string Target { get; set; }
		
		public string Value { get; set; }

		public Element Property { get; set; }

		// Identify Excel sheet
		public string Sheet { get; set; }

		// Excel row
		public int Row { get; set; }
	}
}
