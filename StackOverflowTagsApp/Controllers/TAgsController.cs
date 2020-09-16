using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackOverflowTagsApp.Interfaces;
using StackOverflowTagsApp.Models;

namespace StackOverflowTagsApp.Controllers
{
    public class TAgsController : Controller
    {
        private readonly ITagsFromSite _tags;

        public TAgsController(
            ITagsFromSite tags)
        {
            _tags = tags;
        }
        public IActionResult TagsTable()
        {
            var model = _tags.GetTagsTOP();
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View("Error");
        }
    }
}