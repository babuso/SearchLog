using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchLog.Models
{
    public class ApplicationModel
    {
        public ApplicationModel(string directoryPath)
        {
            if (!string.IsNullOrEmpty(directoryPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                this.Directories = directoryInfo.GetDirectories().Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.FullName
                }).ToList();
                this.Files = new List<string>();
            }
            else
            {
                this.Directories = new List<SelectListItem>();
                this.Files = new List<string>();
            }
        }
        public string SelectedDirectory { get; set; }

        public List<SelectListItem> Directories { get; set; }

        public List<string> Files { get; set; }
    }

    public class SearchModel
    {
        public string path { get; set; }
        public string name { get; set; }
        public int row { get; set; }
        public int col { get; set; }
    }
}