using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

namespace CtaSharp.EndPoint
{
	public interface IEndpoint<Model, Parameters>
    {
        IEnumerable<Model> Get(Parameters parameters);
        Task<IEnumerable<Model>> GetAsync(Parameters parameters);
    }
}
