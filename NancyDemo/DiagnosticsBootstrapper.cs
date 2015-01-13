using System;
using Nancy;
using Nancy.Diagnostics;
using Nancy.TinyIoc;
using Nest;

namespace NancyDemo
{
	public class DiagnosticsBootstrapper : DefaultNancyBootstrapper
	{
		protected override DiagnosticsConfiguration DiagnosticsConfiguration
		{
			get { return new DiagnosticsConfiguration { Password = @"12345" }; }
		}

		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			base.ConfigureApplicationContainer(container);
			container.Register<IElasticClient>((c, p) =>
			{
				var url = new Uri("http://testesearch200.prod.local:9200");
				return new ElasticClient(new ConnectionSettings(url).SetDefaultIndex("nancyrequestlogging"));
			});
		}
	}
}