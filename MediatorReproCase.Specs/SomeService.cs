using System.Threading.Tasks;
using MediatR;

namespace MediatorReproCase.Specs
{
	public class SomeService
	{
		private readonly IMediator _mediator;

		public SomeService(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<bool> ThrowAnError()
		{
			var result = await _mediator.SendAsync(new GetBooleanRequest());

			return result;
		}
	}
}