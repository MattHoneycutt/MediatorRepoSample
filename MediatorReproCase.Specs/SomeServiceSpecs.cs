using System;
using MediatR;
using NUnit.Framework;
using Should;
using SpecsFor;
using StructureMap;

namespace MediatorReproCase.Specs
{
	public class SomeServiceSpecs
	{
		public class when_calling_a_method_that_throws_an_exception_with_the_real_mediator : SpecsFor<SomeService>
		{
			protected override void ConfigureContainer(IContainer container)
			{
				container.Configure(cfg =>
				{
					cfg.AddRegistry<MediatorRegistry>();
					cfg.For<IMediator>().Use<Mediator>();
				});
			}

			[Test]
			public void then_it_throws_an_exception_that_includes_the_actual_source_of_the_error()
			{
				Assert.Throws<AggregateException>(() => SUT.ThrowAnError().Wait())
					.ToString().ShouldContain(typeof(GetBooleanHandler).Name);
			}
		}
		
		public class when_calling_a_method_that_throws_an_exception_with_the_local_copy_of_mediator : SpecsFor<SomeService>
		{
			protected override void ConfigureContainer(IContainer container)
			{
				container.Configure(cfg =>
				{
					cfg.AddRegistry<MediatorRegistry>();
					cfg.For<IMediator>().Use<MyMediator>();
				});
			}

			[Test]
			public void then_it_throws_an_exception_that_includes_the_actual_source_of_the_error()
			{
				Assert.Throws<AggregateException>(() => SUT.ThrowAnError().Wait())
					.ToString().ShouldContain(typeof(GetBooleanHandler).Name);
			}
		}
	}
}