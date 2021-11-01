using BusinessService.Asp.netCore.AutoFac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core5._0.MVCDemo.Controllers
{
    public class FirstController : Controller
    {
        private readonly IService _service;

        public FirstController(IService service)
        {
            _service = service;

            int value = _service.GetId(1);
        }

        public IActionResult Index()
        {
            ViewBag.UserName = "zxc";
            ViewData["Addres"] = "湖北";
            TempData["Age"] = 18;

            //string model = "model";//string 类型会被认为寻找视图
            object model = "model";

            base.HttpContext.Session.SetString("zxc", "zhangxiancheng");
            //return View(model);

            return RedirectToAction("Test");
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}