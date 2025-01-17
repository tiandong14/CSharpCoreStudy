﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [Route("/Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessagebox = "抱歉，访问的路径不存在";

                    logger.LogError($"发生了一个404错误. 路径 = {statusCodeResult.OriginalPath}" +
                        $"路径{statusCodeResult.OriginalQueryString}");
                    break;
            }
            return View("NotFound");
        }
        [Route("/Error")]
        public IActionResult Error()
        {
            var dateTime = DateTime.Now;
            var formattedTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            ViewBag.ErrorDate = formattedTime;
            //获取异常细节
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            logger.LogError($"路径 {exceptionHandlerPathFeature.Path} " +
           $"产生了一个错误{exceptionHandlerPathFeature.Error}");
            return View("Error");
        }

    }
}
