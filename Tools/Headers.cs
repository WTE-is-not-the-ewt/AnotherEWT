namespace AnotherEWT.Tools
{
    public class Headers
    {
        public const string GET_USER_URL =
            "https://gateway.ewt360.com/api/usercenter/user/login/getUser?platform=1";
        public const string DAY_URL =
          "https://gateway.ewt360.com/api/homeworkprod/homework/student/studentHomeworkDistribution";
        public const string HOMEWORK_URL =
          "https://gateway.ewt360.com/api/homeworkprod/homework/student/getStudentHomeworkInfo";
        public const string SCHOOL_URL =
          "https://gateway.ewt360.com/api/eteacherproduct/school/getSchoolUserInfo";
        public const string COURSE_URL =
          "https://gateway.ewt360.com/api/homeworkprod/homework/student/pageHomeworkTasks";
        public const string GET_LESSON_DETAIL_URL =
          "https://gateway.ewt360.com/api/homeworkprod/player/getLessonDetailV2";
        public const string LESSON_HOMEWORK_URL =
          "https://gateway.ewt360.com/api/homeworkprod/player/getPlayerLessonConfig";
        public const string HOMEWORK_DOING_URL =
          "https://web.ewt360.com/mystudy/#/exam/answer/?paperId={%s}&bizCode=204&platform=1";
        public const string COURSE_BATCH_URL = "https://bfe.ewt360.com/monitor/web/collect/batch";
        public const string HMAC_SECRET_ID_URL =
          "http://bfe.ewt360.com/monitor/hmacSecret?userId={%s}";
        public const string HOMEWORK_GET_ANSWER_URL =
          "https://web.ewt360.com/customerApi/api/studyprod/web/answer/webreport?reportId={reportid}&bizCode={bizCode}";
        public const string HOMEWORK_INFO_URL =
          "https://web.ewt360.com/customerApi/api/studyprod/web/answer/report?&platform=1&isRepeat=1&paperId={paperId}&bizCode={bizCode}";
        public const string SUBMIT_ANSWER_URL =
          "https://web.ewt360.com/customerApi/api/studyprod/web/answer/submitanswer";
        public const string MISSION_INFO_URL =
          "https://gateway.ewt360.com/api/homeworkprod/homework/student/studentHomeworkSummaryInfo?sceneId=0&homeworkId={hid}&schoolId={sid}";
    }
}
