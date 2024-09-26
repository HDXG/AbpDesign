using Design.Application.Contracts.Services;
using Design.HttpApi.Extensions;
using DesignSetup.Application.CodeGenerations;
using DesignSetup.Application.CodeGenerations.Dtos;
using DesignSetup.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesignSetup.Host.Controllers
{
    [ApiExplorerSettings(GroupName = "setup")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Area(DesignSetupDomainOptions.ApplicationName)]
  
    public class CodeGenerationController(ICodeGenerationAppService codeGeneration) : DesignControllerBase
    {

        [HttpPost]
        public Task<PagedResultOutPut<CodeGenerationDto>> GetTableSchemasDescribe(PagingBase t) => codeGeneration.GetTableSchemasDescribe(t);
    }
}
