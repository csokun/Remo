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
			Assert.NotNull(el.Current());
		}

		[Fact]
		public void Get_element_by_name()
		{
			Assert.NotNull(new Element("name =sokun").Current());
		}

		[Fact]
		public void Get_element_by_xpath()
		{
			var el = new Element("//*[@id='page_content_holder']/form/fieldset/p[4]/input");

			Assert.NotNull(el);
			Assert.Equal("By.XPath: //*[@id='page_content_holder']/form/fieldset/p[4]/input", el.Current().ToString());
		}
	}
}