using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zz.DTOS;
using Zz.Services;

namespace Zz.Web.Controllers
{
    public class ZNewController :ZzControllerBase
    {
        private readonly IPeopleSerivice _PeopleSerivice;
    
        public ZNewController(IPeopleSerivice PeopleSerivice)
        {
            //  abp 自己去注册的组件
            _PeopleSerivice = PeopleSerivice;
        }
        // GET: ZNew
        public ActionResult Index()
        {
            var query = _PeopleSerivice.GetAllPeople();

            return View(query);
           // return View();
        }

        public ActionResult Update(int id=1)
        {
            return View(_PeopleSerivice.GetOnePeople(id));
        }

        // GET: Test/Create
            [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create  FormCollection collection
        [HttpPost]
        public ActionResult Create(ZPeopleInput model)
        {
            try
            {
                // TODO: Add insert logic here
                var id = _PeopleSerivice.CreatePerson(model);

              //  var input = new GetTasksInput();
              //  var output = _taskAppService.GetTasks(input);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult List()
        {
           
            return View();
        }
    }
}