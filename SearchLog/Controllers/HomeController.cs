using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchLog.Models;

namespace SearchLog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ApplicationModel applicationModel = new ApplicationModel(Server.MapPath("~") + @"Logs\");

            return View(applicationModel);
        }

        public ActionResult GetFilesForDirectory(string directoryPath)
        {
            ApplicationModel applicationModel = new ApplicationModel(directoryPath);
            applicationModel.SelectedDirectory = directoryPath;

            if (!string.IsNullOrEmpty(directoryPath))
            {
                applicationModel.Files = new DirectoryInfo(directoryPath).GetFiles().Select(p => p.Name).ToList();
            }

            return PartialView("_FilesView", applicationModel);
        }

        public ActionResult Results(string directoryPath, string searchText)
        {
            List<SearchModel> searchList = new List<SearchModel>();

            if (!string.IsNullOrEmpty(searchText))
            {
                string line;
                int row = 0;
                DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

                foreach (var file in directoryInfo.GetFiles())
                {
                    StreamReader fileReader = new StreamReader(file.FullName);
                    while ((line = fileReader.ReadLine()) != null)
                    {
                        ++row;
                        if (line.Contains(searchText))
                        {
                            searchList.Add(new SearchModel
                            {
                                name = file.Name,
                                path = file.FullName,
                                col = line.IndexOf(searchText) + 1,
                                row = row
                            });
                        }
                    }
                }
            }

            return PartialView("_ResultsView", searchList);
        }
    }
}