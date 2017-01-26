using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AthleteAddaProject.Service;
using AthleteAddaProject.Models;

namespace AthleteAddaProject.Controllers
{
    public class NewsfeedController : ApiController
    {
        //[HttpPost]
        //public List<NewsfeedModel> GetNews(string datetimeStr)//, string searchStr, int newsfeedCountFrom
        //{
        //    int newsfeedCountFrom = 0;
        //    string searchStr = "";
        //    DateTime datetime = DateTime.Now;
        //    int sortBy = 0;
        //    int getTotalNewsfeeds = 3;
        //    NewsFeedService newsFeedService = new NewsFeedService();
        //    List<NewsfeedModel> newsfeeds = newsFeedService.GetAllNewsFeeds(datetime, searchStr, sortBy, newsfeedCountFrom, getTotalNewsfeeds);
        //    return newsfeeds;
        //}
        public IHttpActionResult Get(string datetimeStr, string searchStr, int newsfeedCountFrom)
        {
            //newsfeedCountFrom = 6;
            DateTime datetime = DateTime.Parse(datetimeStr);
            int sortBy = 0;
            int getTotalNewsfeeds = 3;
            NewsFeedService newsFeedService = new NewsFeedService();
            List<NewsfeedModel> newsfeeds = newsFeedService.GetAllNewsFeeds(datetime, searchStr, sortBy, newsfeedCountFrom, getTotalNewsfeeds);
            return Ok(newsfeeds);
        }
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}