
using System;

namespace FACCID
{
    public class PatienceModel
    {
        
        public int Id { get; set; }
        public string NAME { get; set; }
        public string SEX { get; set; }
        public string ADDRESS { get; set; }
        public string HEALTH_INFORMATION { get; set; }


    }
    public class connections
    {
        public static string connectionStrings()
        {
            string connect = "Data Source=HEALTH.db; Version=3";
            return connect;
        }
    }
    public class StaffModel
    {
        public int Id { get; set; }
        public string NAME { get; set; }
        public string CATEGORY { get; set; }
        public string DATE { get; set; }
        public string TIME { get; set; }
        
    }
    public class StaffModel2
    {
        public int Id { get; set; }
        public string NAME { get; set; }
        public string ADDRESS { get; set; }
        public string CATEGORY { get; set; }
        
        public string SEX { get; set; }

    }
    public class NoticeModel
    {
        public int Id { get; set; }
        public string TITLE { get; set; }
        public DateTime DATE { get; set; }
        public string INFORMATION { get; set; }
    }
}
