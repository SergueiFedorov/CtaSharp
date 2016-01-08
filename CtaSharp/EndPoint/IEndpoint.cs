using System.Collections.Generic;
using System.Threading.Tasks;

namespace CtaSharp.EndPoint
{
    internal interface IEndpoint<Model, Parameters>
    {
        IEnumerable<Model> Get(Parameters parameters);
        Task<IEnumerable<Model>> GetAsync(Parameters parameters);
    }
}
