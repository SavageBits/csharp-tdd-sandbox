using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Logic
{
    public class DummyReportingService: IReportingService
    {
        private bool _sendScoreWasCalled;

        public bool SendScoreWasCalled()
        {
            return _sendScoreWasCalled;
        }

        public void SendScore()
        {
            _sendScoreWasCalled = true;
        }
    }
}
