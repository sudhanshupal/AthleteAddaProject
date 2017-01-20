using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AthleteAddaProject.Models
{
    public class GetNewfeeds
    {
        public int NewsFeed_Id { get; set; }
        public Nullable<System.DateTime> Datetime { get; set; }
        public Nullable<int> Publisher_Id { get; set; }
        public string Content { get; set; }
        public string Image_Path { get; set; }
        public Nullable<bool> IsPublished { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsVerified { get; set; }
        public string Comment_by_Reviewer { get; set; }
        public int Publisher_Id1 { get; set; }
        public string Publisher_Name { get; set; }
        public string Email_Id { get; set; }
        public string Mobile_No { get; set; }
        public string Display_Name { get; set; }
        public string Display_Picture { get; set; }
    }
}