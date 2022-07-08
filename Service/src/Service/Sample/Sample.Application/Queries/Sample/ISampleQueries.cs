using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Queries.Sample
{
    public interface ISampleQueries
    {
        Task<IEnumerable<SampleViewModel>> GetSampleAsync();
    }
}
