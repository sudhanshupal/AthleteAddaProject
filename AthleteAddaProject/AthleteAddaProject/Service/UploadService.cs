using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AthleteAddaProject.Service
{
    public class UploadService
    {
        #region public methods
        /// <summary>
        /// Create folder if not exists
        /// </summary>
        /// <param name="path">Full folder path</param>
        public void CreateFolderIfNotExists(string path)
        {
            //create folder if not exists
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Upload file in given folder
        /// </summary>
        /// <param name="file">file to be uploaded</param>
        /// <param name="saveAsPath">full path of folder</param>
        /// <param name="allowedFileExtensions">valid file extentions</param>
        /// <param name="maxFileSizeInMB">max size allowed in MB</param>
        /// <returns></returns>
        public void UploadFile(HttpPostedFileBase file, string saveAsPath, string[] allowedFileExtensions, int maxFileSizeInMB)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                if (file == null)
                    throw new ApplicationException("Please upload your file.");
                else if (file.ContentLength > 0)
                {
                    int maxContentLengthInBytes = 1024 * 1024 * maxFileSizeInMB;
                    if (!allowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                        throw new ApplicationException("Please select file of type(s): " + string.Join(", ", allowedFileExtensions));
                    else if (file.ContentLength > maxContentLengthInBytes)
                        throw new ApplicationException("Your file is too large, maximum allowed size is: " + maxFileSizeInMB + " MB");
                    else
                        file.SaveAs(saveAsPath);
                }
                else
                    throw new ApplicationException("File size must be greater that 0 bytes.");
            }
            else
                throw new ApplicationException("Please upload your file.");
        }

        #endregion
    }
}