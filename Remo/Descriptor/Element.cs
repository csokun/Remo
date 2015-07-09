using OpenQA.Selenium;

namespace Remo.Descriptor
{
	/// <summary>
	/// Wrap Selenium element selector
	/// Limited, number of selectors that can be use
	/// </summary>
	public class Element
	{
		private By element = null;

		public Element(string element)
		{
			if (string.IsNullOrEmpty(element))
				return;

			var token = element.Split('=');
			if (token.Length != 2)
				return;

			var key = token[0].Trim().ToLower();
			var value = token[1].Trim();

			if ("id".Equals(key))
			{
				this.element = By.Id(value);
			}
			else if ("name".Equals(key))
			{
				this.element = By.Name(value);
			}
			else if ("link".Equals(key))
			{
				this.element = By.LinkText(value);
			}

		}

		public By Select()
		{
			return this.element;
		}
	}
}
