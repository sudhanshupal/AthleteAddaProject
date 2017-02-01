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

        public IHttpActionResult Get(string datetimeStr, string searchStr, int newsfeedCountFrom)
        {
            bool isDateIncluded = false;
            //newsfeedCountFrom = 6;
            DateTime datetime = DateTime.Today;
            if (datetimeStr != null)
            {
                isDateIncluded = true;
                datetime = DateTime.Parse(datetimeStr);
            }

            int sortBy = 0;
            int getTotalNewsfeeds = 3;
            NewsFeedService newsFeedService = new NewsFeedService();
            List<NewsfeedModel> newsfeeds = newsFeedService.GetAllNewsFeeds(datetime, searchStr, sortBy, newsfeedCountFrom, getTotalNewsfeeds, isDateIncluded);
            return Ok(newsfeeds);
        }

        [HttpPost]
        [Route("api/Newsfeed/PostNewsFeed")]
        //todo:if antiforgerytoken are not working comment it. AntiForgeryToken is compulsary for the POST.
        [AthleteAddaProject.Common.ValidateJsonAntiForgeryTokenAttribute]
        public IHttpActionResult PostNewsFeed(NewsfeedModel model)
        {
            try
            {
                if(true)
                {
                    //...
                    //todo:add data using service here
                    return Created("api/Newsfeed/Get", model);//if create response not working then try OK() just like Get() above.
                }
                else
                {
                    return BadRequest("Invalid attempt to save news. Please try again later.");
                }

            }
            catch (Exception ex)
            {
                //todo:log
                return InternalServerError(ex);
            }
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