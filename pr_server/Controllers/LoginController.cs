using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pr_Model.Models;
using pr_service;
using pr_common;
using pr_model;

namespace pr_server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICustomJWTService _customJWTService;
        private readonly ILogger<LoginController> _logger;
        public LoginController(IUserService userService, ICustomJWTService customJWTService, ILogger<LoginController> logger)
        {
            _userService = userService;
            _customJWTService = customJWTService;
            _logger = logger;
        }

        /// <summary>
        /// 獲取驗證碼
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetValifateCodeImages(string t)
        {
            var validateCodeString = Tools.CreateValidateString();
            MemoryHelper.SetMemory(t, validateCodeString, 5);
            byte[] buffer = Tools.CreateValidateCodeBuffer(validateCodeString);
            return File(buffer, @"image/jpeg");
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult Cheak(UserReq req)
        {
            var currCode = MemoryHelper.GetMemory(req.ValidateKey);
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password) || string.IsNullOrEmpty(req.ValidateKey) || string.IsNullOrEmpty(req.ValidateCode))
            {
                apiResult.Msg = "參數不能為空!";
            }
            else if(currCode == null)
            {
                apiResult.Msg = "驗證碼不存在，請重新刷新驗證碼";
            }
            else if(currCode.ToString() != req.ValidateCode)
            {
                apiResult.Msg = "驗證碼錯誤，請重新刷新驗證碼";
            }
            else
            {
                UserRes user = _userService.GetUsers(req);
                if (string.IsNullOrEmpty(user.UserName))
                {
                    apiResult.Msg = "帳號不存在，用戶名或密碼錯誤!";
                }
                else
                {
                    apiResult.IsSuccess = true;
                    apiResult.Result = _customJWTService.GetToken(user); //user.NickName
                    _logger.LogInformation("我好口愛");
                }
            }
            return apiResult;
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult Register(RegisterReq req)
        {
            var currCode = MemoryHelper.GetMemory(req.ValidateKey);
            ApiResult apiResult = new ApiResult() { IsSuccess = false };

            // 檢查必要參數是否為空
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password) || string.IsNullOrEmpty(req.NickName) || string.IsNullOrEmpty(req.ValidateKey) || string.IsNullOrEmpty(req.ValidateCode))
            {
                apiResult.Msg = "參數不能為空！";
            }
            else if (currCode == null)
            {
                apiResult.Msg = "驗證碼不存在，請重新刷新驗證碼";
            }
            else if (currCode.ToString() != req.ValidateCode)
            {
                apiResult.Msg = "驗證碼錯誤，請重新刷新驗證碼";
            }
            else
            {
                // 嘗試註冊用戶
                string msg = string.Empty;
                var res = _userService.RegisterUser(req, ref msg);
                if (!string.IsNullOrEmpty(msg))
                {
                    apiResult.Msg = msg;
                }
                else
                {
                    apiResult.IsSuccess = true;
                    apiResult.Result = _customJWTService.GetToken(res); //req.NickName
                }
            }

            // 返回結果
            return apiResult;
        }
    }
}
