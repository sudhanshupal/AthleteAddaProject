using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AthleteAddaProject.Service;
using AthleteAddaProject.Models;
using System.Globalization;
using System.IO;
using System.Configuration;
using System.Web;

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
                DateTime output;
                if (!DateTime.TryParseExact(datetimeStr, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out output))
                {
                    // Uh oh again...
                    return BadRequest("Date is not valid. Please enter valid date format for ex-yyyy/mm/dd.");
                }
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
        //[AthleteAddaProject.Common.ValidateJsonAntiForgeryTokenAttribute]
        public IHttpActionResult PostNewsFeed()
        {
            try
            {
                var postedFile = HttpContext.Current.Request.Files.Count > 0 ?
                                        HttpContext.Current.Request.Files[0] : null;

                if (postedFile != null && postedFile.ContentLength > 0 && postedFile.ContentLength <= 10485760 && HttpContext.Current.Request.Form.Count == 2)
                {
                    HttpPostedFileBase file = new HttpPostedFileWrapper(postedFile);//as HttpPostedFileBase;
                    var newsFeedService = new NewsFeedService();
                    var fileUploadService = new UploadService();

                    var fileName = System.IO.Path.GetFileName(file.FileName);
                    string uploadedFileName = file.FileName;
                    string extension = file.FileName.Substring(uploadedFileName.LastIndexOf("."));
                    string saveAsFileName = file.FileName.Split('.')[0] + "_" + Guid.NewGuid().ToString() + extension;
                    string saveAsPath = System.Web.HttpContext.Current.Server.MapPath("~\\" + ConfigurationSettings.AppSettings["ImageLocation"].ToString() + "\\" + Path.GetFileName(saveAsFileName));
                    string saveToPath = "../" + ConfigurationSettings.AppSettings["ImageLocation"].ToString() + "/" + Path.GetFileName(saveAsFileName);
                    //create folder if not exists
                    fileUploadService.CreateFolderIfNotExists(System.Web.HttpContext.Current.Server.MapPath("~\\" + ConfigurationManager.AppSettings["ImageLocation"].ToString() + "\\"));

                    // Fetching the data that has been sent along with the form. 
                    var title = System.Web.HttpContext.Current.Request.Form["Title"];
                    var content = System.Web.HttpContext.Current.Request.Form["Content"];
                    if (title.ToString() == "" || content.ToString() == "")
                    {
                        return BadRequest("Please enter all fields.");
                    }
                    else if (title.Length > 500)
                    {
                        return BadRequest("Title must be less that 500 characters.");
                    }

                    string[] allowedFileExtentions = new string[] { ".jpeg", ".jpg", ".png", ".gif" };
                    fileUploadService.UploadFile(file, saveAsPath, allowedFileExtentions, Convert.ToInt32(ConfigurationManager.AppSettings["UploadFileSizeForImage"]));
                    newsFeedService.SaveNews(saveToPath, title, content);
                    return Ok();
                }
                else
                {
                    return BadRequest("Invalid attempt to save news. Please try again later.");
                }
            }
            catch (ApplicationException ex)
            {
                //todo:log
                return BadRequest(ex.Message);
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