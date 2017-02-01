using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Linq;
using AthleteAddaProject.Data;
using AthleteAddaProject.Models;

namespace AthleteAddaProject.Service
{
    public class NewsFeedService
    {
        public List<NewsfeedModel> GetAllNewsFeeds()
        {
            List<NewsfeedModel> newsFeedList = new List<NewsfeedModel>();
            using (AthleteAddaTestEntities db = new AthleteAddaTestEntities())
            {
                var newsFeeds = db.Newsfeeds.ToList();
                foreach (var news in newsFeeds)
                {
                    NewsfeedModel newsModel = new NewsfeedModel();
                    newsModel.Content = news.Content;
                    newsModel.NewsFeedId = news.NewsFeed_Id;
                    newsModel.DateTime = Convert.ToDateTime(news.Datetime);
                    newsModel.PublisherId = Convert.ToInt32(news.Publisher_Id);
                    newsModel.ImagePath = news.Image_Path;
                    newsModel.IsPublished = Convert.ToBoolean(news.IsPublished);
                    newsModel.IsDeleted = Convert.ToBoolean(news.IsDeleted);
                    newsModel.IsVarified = Convert.ToBoolean(news.IsVerified);
                    newsModel.CommentByReviewer = news.Comment_by_Reviewer;
                    newsFeedList.Add(newsModel);
                }   
            }
            return newsFeedList;
        }

        public List<NewsfeedModel> GetAllNewsFeeds(DateTime searchDateTime, string searchStr, int sortBy, int newsfeedCountFrom, int getTotalNewsfeeds, bool isDateIncluded)
        {
            List<NewsfeedModel> newsFeedList = new List<NewsfeedModel>();
            using (AthleteAddaTestEntities db = new AthleteAddaTestEntities())
            {
                if (searchStr == null)
                    searchStr = "";

                var newsFeeds = db.GetNewfeeds(searchDateTime, searchStr, sortBy, newsfeedCountFrom, getTotalNewsfeeds, isDateIncluded).ToList();
                if (newsFeeds.Any())
                {
                    foreach (var news in newsFeeds)
                    {
                        NewsfeedModel newsModel = new NewsfeedModel();
                        newsModel.Content = news.Content;
                        newsModel.NewsFeedId = news.NewsFeed_Id;
                        newsModel.DateTime = Convert.ToDateTime(news.Datetime);
                        newsModel.PublisherId = Convert.ToInt32(news.Publisher_Id);
                        newsModel.ImagePath = news.Image_Path;
                        newsModel.IsPublished = Convert.ToBoolean(news.IsPublished);
                        newsModel.IsDeleted = Convert.ToBoolean(news.IsDeleted);
                        newsModel.IsVarified = Convert.ToBoolean(news.IsVerified);
                        newsModel.CommentByReviewer = news.Comment_by_Reviewer;
                        newsModel.PublisherDisplayName = news.Display_Name;
                        newsModel.Title = news.Title;
                        newsModel.NewsfeedCountFrom = newsfeedCountFrom;
                        newsFeedList.Add(newsModel);
                    }
                }
   
            }
            return newsFeedList;
        }
    }
}