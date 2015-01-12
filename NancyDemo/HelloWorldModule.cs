using System.Linq;
using Nancy;

namespace NancyDemo
{
	public class HelloWorldModule : NancyModule
	{
		public HelloWorldModule()
		{
			Get["/hello/"] = parameters =>
			{
				return "world";
			};

			Get["/hello/{name}"] = parameters =>
			{
				return string.Format("Hello {0}", parameters.Name);
			};

			Get["/hello/{name}/{numberOfTimes:int}"] = parameters =>
			{
				return string.Join(", ", Enumerable.Repeat(string.Format("Hello {0}", (string)parameters.Name), parameters.NumberOfTimes));
			};

			Get["/hello/{name}/{date:datetime}"] = parameters =>
			{
				return string.Format("Hello {0}, the time is {1}", parameters.Name, parameters.Date);
			};
		}
	}
}
