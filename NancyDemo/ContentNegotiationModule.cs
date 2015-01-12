using Nancy;

namespace NancyDemo
{
	public class ContentNegotiationModule : NancyModule
	{
		public ContentNegotiationModule()
		{
			Get["/person/"] = parameters =>
			{
				return new Person()
				{
					Name = "Martin",
					Age = 33,
				};
			};
		}
	}

	public class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }
	}
}
