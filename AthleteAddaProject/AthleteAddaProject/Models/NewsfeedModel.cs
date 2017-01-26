using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AthleteAddaProject.Models
{
    public class NewsfeedModel
    {
        public int NewsFeedId { get; set; }
        public DateTime DateTime { get; set; }
        public int PublisherId { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsVarified { get; set; }
        public string CommentByReviewer { get; set; }
        public string PublisherDisplayName { get; set; }
        public string Title { get; set; }
        public int NewsfeedCountFrom { get; set; }
    }
}