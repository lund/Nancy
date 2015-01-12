using System;
using Nancy.Hosting.Self;

namespace NancyDemo
{
	class Program
	{
		static void Main()
		{
			var nancyHost = new NancyHost(new HostConfiguration
			{
				UrlReservations = new UrlReservations
				{
					CreateAutomatically = true,
				},
			},
			new Uri("http://localhost:8888/"));
			nancyHost.Start();
			Console.ReadLine();
		}
	}
}
