using Chat.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Helpers.ExceptionHandlers
{
    public class AppError : Exception
    {
        private ErrorCodeEnum errors { get; set; }

        public AppError(ErrorCodeEnum _errors, string message) : base(message)
        {
            errors = _errors;
        }

        public static AppError BadAuth => new AppError(ErrorCodeEnum.BadLoginOrPassword, "Не верный логин или пароль");
    }
}
