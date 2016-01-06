using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp
{
    internal interface IEndpoint<Model, Parameters>
    {
        IEnumerable<Model> Get(Parameters parameters);
        Task<IEnumerable<Model>> GetAsync(Parameters parameters);
    }
}
