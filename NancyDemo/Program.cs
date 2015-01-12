using Topshelf;

namespace NancyDemo
{
	class Program
	{
		static void Main()
		{
			HostFactory.Run(x => x.Service<NancyTopshelfHost>(s =>
			{
				s.ConstructUsing(name => new NancyTopshelfHost());
				s.WhenStarted(bi => bi.Start());
				s.WhenStopped(bi => bi.Stop());
			}));
		}
	}
}
