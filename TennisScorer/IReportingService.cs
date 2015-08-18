using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Logic
{
    public interface IReportingService
    {
        Boolean SendScoreWasCalled();
        void SendScore();
    }
}
