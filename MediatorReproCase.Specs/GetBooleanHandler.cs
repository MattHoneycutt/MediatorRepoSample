using System.Threading.Tasks;
using MediatR;

namespace MediatorReproCase.Specs
{
	public class GetBooleanRequest : IAsyncRequest<bool>
	{
	}

	public class GetBooleanHandler : IAsyncRequestHandler<GetBooleanRequest, bool>
	{
		public async Task<bool> Handle(GetBooleanRequest message)
		{
			object o = null;

			//This will throw an exception!
			o.GetType();

			return false;
		}
	}
}