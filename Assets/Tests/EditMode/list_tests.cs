using System.Collections.Generic;
using NUnit.Framework;

namespace N_Tests.N_EditMode
{
	public class list_tests
	{
		// A Test behaves as an ordinary method
		[Test]
		public void string_list_test()
		{
			// Most of the times this is not appropriate checking for test (this is standard
			// .NET comparison for objects). Use 'Assert.AreEquals()' instead.
			// Assert.Equals()

			// Arrange.
			List<string> strings = new List<string>();

			// Act.
			strings.Add("Test string 1");
			strings.Add("Test string 2");
			strings.RemoveAt(0);

			// Assert.
			Assert.AreEqual(1, strings.Count);
		}
	}
}