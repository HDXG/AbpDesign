using Design.Application.Contracts.Extensions;
using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Application.Serilogs.Dtos;
using DesignSetup.Application.Serilogs.InPut;
using DesignSetup.Domain.Serilogs;

namespace DesignSetup.Application.Serilogs
{
    public interface ISerilogAppService: IDesignApplicationService
    {
        /// <summary>
        /// 返回分页内容
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<PagedResultOutPut<SerilogDto>> GetSerilogList(SerilogInPut t);

        /// <summary>
        /// 查询单个api日志内容
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<SerilogGetDto> GetSerilog(GetIntDto t);

    }
    public class SerilogAppService(ISerilogRepository serilogRepository) : DesignApplicationService, ISerilogAppService
    {
        public async Task<PagedResultOutPut<SerilogDto>> GetSerilogList(SerilogInPut t)
        {
           var data= await  serilogRepository.GetPagedListAsync(x =>x.Url.Contains(t.url),x=>x.TimeStamp, true, t.PageIndex, t.PageSize);
            return new PagedResultOutPut<SerilogDto>(data.Item1,ObjectMapper.Map<List<Serilog>,List<SerilogDto>>(data.Item2));

        }

        public async Task<SerilogGetDto> GetSerilog(GetIntDto t)
        {
            return ObjectMapper.Map<Serilog, SerilogGetDto>(await serilogRepository.GetAsync(t.Id));
        }
    }
}
