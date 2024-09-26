using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Application.CodeGenerations.Dtos;
using DesignSetup.Domain.codeGenerations;

namespace DesignSetup.Application.CodeGenerations
{
    public interface ICodeGenerationAppService : IDesignApplicationService
    {
        /// <summary>
        /// 获得表描述 等信息
        /// </summary>
        /// <returns></returns>
        Task<PagedResultOutPut<CodeGenerationDto>> GetTableSchemasDescribe(PagingBase t);
    }

    public class CodeGenerationAppService(ICodeGenerationRepository codeGeneration) : DesignApplicationService, ICodeGenerationAppService
    {
        public async Task<PagedResultOutPut<CodeGenerationDto>> GetTableSchemasDescribe(PagingBase t)
        {
            var list=await  codeGeneration.GetTableSchemasDescribe<CodeGenerationDto>();
            return new PagedResultOutPut<CodeGenerationDto>(list.Count, list
                .Skip((t.PageIndex - 1) * t.PageSize).Take(t.PageSize).ToList());
        }
    }
}
