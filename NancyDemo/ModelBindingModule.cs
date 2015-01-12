using System.Collections.Generic;
using System.Text;
using Nancy;
using Nancy.ModelBinding;

namespace NancyDemo
{
	public class ModelBindingModule : NancyModule
	{
		public ModelBindingModule()
		{
			Get["/modelbinding/"] = _ =>
			{
				var helloModel = this.Bind<HelloModel>();
				return string.Format("Hello {0}, I'm supposed to tell you this: {1}", helloModel.Name, helloModel.Message);
			};

			Post["/modelbindings/"] = _ =>
			{
				var helloModel = this.Bind<List<HelloModel>>();

				var sb = new StringBuilder();
				helloModel.ForEach(model => sb.Append(string.Format("Hello {0}, I'm supposed to tell you this: {1}", model.Name, model.Message)));
				return sb.ToString();
			};
		}
	}

	public class HelloModel
	{
		public string Name { get; set; }
		public string Message { get; set; }
	}
}
