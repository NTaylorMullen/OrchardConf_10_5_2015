using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace TagHelperDemo
{
    public class ShapeishViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string name, int age)
        {
            dynamic model = new ExpandoObject();

            model.Name = name;
            model.Age = age;

            return View("/Views/Shapeish", model);
        }
    }
}
