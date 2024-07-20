using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_service
{
    public class RegisterReq
    {
        /// <summary>
        /// 用戶名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 暱稱
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 驗證碼key
        /// </summary>
        public string ValidateKey { get; set; }
        /// <summary>
        /// 驗證碼code
        /// </summary>
        public string ValidateCode { get; set; }
    }
}
