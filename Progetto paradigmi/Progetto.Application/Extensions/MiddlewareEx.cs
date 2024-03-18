


using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Progetto_paradigmi.Progetto.Application.Options;
using Progetto_paradigmi.Progetto.Application.Services;
using Progetto_paradigmi.Progetto.Application.Interfaces;

namespace Progetto_paradigmi.Progetto.Application.Extensions

{
    public class MiddlewareEx
    {
        private RequestDelegate _next;


        public MiddlewareEx(RequestDelegate next)
        {
            _next = next;
        }   

        public async Task Invoke(HttpContext context, IEmailService emailService, IOptions<EmailOption> emailOption)
        {
            context.RequestServices.GetRequiredService<IEmailService>();
            await _next.Invoke(context);
        }
    }
}
