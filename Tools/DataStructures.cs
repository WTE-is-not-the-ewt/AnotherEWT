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
    public class HomeworkData
    {
        /// <summary>
        /// 
        /// </summary>
        public List<int> homeworkIds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isPlan { get; set; }
        /// <summary>
        /// 2023级新生综合素质提升方案
        /// </summary>
        public string homeworkTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int startDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int endDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int sceneId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string valid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> teachers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isSelfTask { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userOptionTaskId { get; set; }
    }

    public class LessonsData
    {
        /// <summary>
        /// 
        /// </summary>
        public string success { get; set; }
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
        public HomeworkData data { get; set; }
    }

    public class SchoolData
    {
        /// <summary>
        /// 
        /// </summary>
        public int userCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int schoolId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int graduationYear { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string operationVideoUrl { get; set; }
    }

    public class SchoolUserInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string success { get; set; }
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
        public SchoolData data { get; set; }
    }


}
