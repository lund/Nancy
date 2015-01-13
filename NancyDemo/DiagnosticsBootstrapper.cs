using System;
using Nancy;
using Nancy.Diagnostics;
using Nancy.TinyIoc;
using Nest;

namespace NancyDemo
{
	public class DiagnosticsBootstrapper : DefaultNancyBootstrapper
	{
		private const string _logKey = "RequestLog";

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

		private Response StartRequestLog(NancyContext context)
		{
			var requestLog = new RequestLog(context.Request.Path)
			{
				Method = context.Request.Method,
			};

			context.Items[_logKey] = requestLog;
			return null;
		}

		private Response LogEndRequest(TinyIoCContainer container, NancyContext context, Exception exception)
		{
			if (context != null && context.Items.ContainsKey(_logKey))
			{
				var requestLog = (RequestLog)context.Items[_logKey];
				requestLog.Stopwatch.Stop();
				if (exception != null)
				{
					requestLog.ResponseCode = 500;
				}
				else
				{
					requestLog.ResponseCode = (int)context.Response.StatusCode;
				}

				if (context.NegotiationContext != null)
				{
					requestLog.Module = context.NegotiationContext.ModuleName;
				}

				var analyticsClient = container.Resolve<IElasticClient>();
				analyticsClient.Index(requestLog);
			}
			return null;
		}
	}
}