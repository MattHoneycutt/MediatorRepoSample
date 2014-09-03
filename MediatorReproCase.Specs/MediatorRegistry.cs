using MediatR;
using Microsoft.Practices.ServiceLocation;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace MediatorReproCase.Specs
{
	public class MediatorRegistry : Registry
	{
		public MediatorRegistry()
		{
			Scan(scanner =>
			{
				scanner.TheCallingAssembly();
				scanner.WithDefaultConventions();
				scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
				scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
				scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
				scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
			});

			For<ServiceLocatorProvider>().Use(ctx => new ServiceLocatorProvider(ctx.GetInstance<StructureMapServiceLocator>));
		}
	}
}