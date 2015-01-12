using System;
using Nancy.Hosting.Self;

namespace NancyDemo
{
	public class NancyTopshelfHost
	{
		private NancyHost _nancyHost;

		public void Start()
		{
			_nancyHost = new NancyHost(new HostConfiguration
			{
				UrlReservations = new UrlReservations
				{
					CreateAutomatically = true,
				},
			},
			new Uri("http://localhost:8888/"));
			_nancyHost.Start();
		}

		public void Stop()
		{
			_nancyHost.Stop();
		}
	}
}
