using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Application.Contracts.Services;
using Design.Application.Services;

namespace DesignSetup.Application.Serilogs
{
    interface ISerilogAppService: IDedsiApplicationService
    {

    }
    public class SerilogAppService: DesignApplicationService,ISerilogAppService
    {
    }
}
