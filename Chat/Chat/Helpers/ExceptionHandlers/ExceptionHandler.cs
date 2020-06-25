using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chat.Helpers.ExceptionHandlers
{
    public class ExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var message = "Возникла ошибка";
            //To Do Не обработаные ошибки должны присылаться в телеграм
            if (context.Exception is AppError ex)
            {
                message = ex.Message;
            }
            else
            {
                message = context.Exception.Message;
            }

            context.Result = new ContentResult
            {
                Content = message
            };

            context.ExceptionHandled = true;
        }
    }
}
