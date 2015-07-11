using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Remo.Verifications
{
	// ref: http://www.helloselenium.com/2014/04/how-to-get-selected-dropdown-value.html
	// TODO: need some more design (user wanted to compare value/text?)
	public class VerifySelectFieldStrategy : IVerifyStrategy
	{
		public bool Contains(IWebElement element, string text)
		{
			throw new System.NotImplementedException();
		}

		public bool Equal(IWebElement element, string text)
		{
			throw new System.NotImplementedException();
		}

		public bool Exists(IWebElement element)
		{
			throw new System.NotImplementedException();
		}

		private string GetSelectText(IWebElement element)
		{
			return new SelectElement(element).SelectedOption.Text;
		}
	}
}
