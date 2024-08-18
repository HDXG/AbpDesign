using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DesignAspNetCore.Filter
{
    public class HttpResponseExceptionFilter : IActionFilter
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public HttpResponseExceptionFilter(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        private const int ErrorStatusCode = 500;
        private readonly Stopwatch watch = new Stopwatch();


        /// <summary>
        /// 先执行
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //计时开始
            watch.Start();
        }
        /// <summary>
        /// 后执行
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            watch.Stop();//计时结束
            if (context.Exception != null)
            {
                //string DefaultErrorText = webHostEnvironment.IsDevelopment() ? context.Exception.Message : "在您的请求期间发生了一个内部错误，请稍后重试。";
                string DefaultErrorText = context.Exception.Message;
                context.HttpContext.Response.StatusCode = ErrorStatusCode;
                context.Result = new ObjectResult(new HttpResponseError(ErrorStatusCode, DefaultErrorText, DateTime.Now, watch.ElapsedMilliseconds))
                {
                    StatusCode = ErrorStatusCode
                };
                context.ExceptionHandled = true;
            }

        }


    }
    /// <summary>
    /// 异常：返回数据格式
    /// </summary>
    /// <param name="Code"></param>
    /// <param name="Message"></param>
    /// <param name="ServiceTime"></param>
    public record HttpResponseError(int Code, string Message, DateTime ServiceTime, long TimeOut);
}
