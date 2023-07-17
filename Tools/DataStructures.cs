using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherEWT.Tools
{
    public class StudentData
    {
        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string realName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool isLogin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int memberType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string memberName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long now { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool isTemporaryExpire { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool isTemporaryMember { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long temporaryExpireTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long source { get; set; }
    }

    public class FullUserData
    {
        /// <summary>
        /// 
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 操作成功
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public StudentData data { get; set; }
    }

}
