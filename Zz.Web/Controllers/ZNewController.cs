using Abp.Auditing;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zz.DTOS;
using Zz.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Zz.Web.Controllers
{
    [Audited]
    public class ZNewController : ZzControllerBase
    {
        private readonly IPeopleSerivice _PeopleSerivice;


        public ZNewController(IPeopleSerivice PeopleSerivice)
        {
            //  abp 自己去注册的组件
            _PeopleSerivice = PeopleSerivice;

            Logger = NullLogger.Instance;
        }
        // GET: ZNew
        public ActionResult Index()
        {
            var query = _PeopleSerivice.GetAllPeople();
            Logger.Info(" 2017年3月2日09:22:03 测试写日志");
            return View(query);
            // return View();
        }

        public ActionResult Update(int id = 1)
        {
            return View(_PeopleSerivice.GetOnePeople(id));
        }

        // GET: Test/Create
        [HttpGet]
        public ActionResult Create()
        {
            Logger.Info(" 测试写日志");

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


        /// <summary>
        ///  回忆下 委托
        /// </summary>
        /// <returns></returns>
        public ActionResult Asy()
        {
            TestAsy asy = new TestAsy();
            // 下面两种写法都是委托的写法
            Func<string, string> fun = (a) => {   return a + "你是个大傻逼"; };
            Func<string, string> fun1 = new Func<string, string>(asy.Method);

            Action<int> action = (b) => { b++; };

            // net 4.5 以后才能用的
            //  创建线程是好资源的事，task 是去线程池里面调用一个空闲的线程执行方法
            var dayName = Task.Run<string>(() => { return fun1.Invoke("ddd"); });

            dayName.ContinueWith((a)=> { fun.Invoke("abc"); });
            dayName.Wait();

            // Thread tt = new Thread(new ThreadStart());

            return Content(Thread.CurrentThread.ManagedThreadId+"_"+dayName.Result);

            //  return View();
        }
        static async Task Test()
        {
            // 方法打上async关键字，就可以用await调用同样打上async的方法
            // await 后面的方法将在另外一个线程中执行
            await GetName();
        }

        static async Task GetName()
        {
            // Delay 方法来自于.net 4.5
            await Task.Delay(1000);  // 返回值前面加 async 之后，方法里面就可以用await了
            Console.WriteLine("Current Thread Id :{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("In antoher thread.....");
        }
    }
}