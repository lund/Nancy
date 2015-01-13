using System;
using System.Diagnostics;

namespace NancyDemo
{
	public class RequestLog
	{
		public RequestLog(string url)
		{
			Stopwatch = new Stopwatch();
			Stopwatch.Start();
			Timestamp = DateTime.Now;
			Id = Guid.NewGuid();
			Url = url;
		}

		public Guid Id { get; set; }
		public string Url { get; set; }
		public Stopwatch Stopwatch { get; set; }
		public string Method { get; set; }
		public DateTime Timestamp { get; set; }
		public int ResponseCode { get; set; }
		public string Module { get; set; }
	}
}
