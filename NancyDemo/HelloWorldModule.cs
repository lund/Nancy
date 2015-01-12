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

		}
	}
}
