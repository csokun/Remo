using Remo.Descriptor;
using Xunit;

namespace Remo.Test
{
	public class ElementTest
	{
		[Fact]
		public void Get_element_by_id()
		{
			var el = new Element("id = sokun");
			Assert.NotNull(el.Select());
		}

		[Fact]
		public void Get_element_by_name()
		{
			Assert.NotNull(new Element("name =sokun").Select());
		}
	}
}
