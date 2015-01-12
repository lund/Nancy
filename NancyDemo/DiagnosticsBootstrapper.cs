using Nancy;
using Nancy.Diagnostics;

namespace NancyDemo
{
	public class DiagnosticsBootstrapper : DefaultNancyBootstrapper
	{
		protected override DiagnosticsConfiguration DiagnosticsConfiguration
		{
			get { return new DiagnosticsConfiguration { Password = @"12345" }; }
		}
	}
}