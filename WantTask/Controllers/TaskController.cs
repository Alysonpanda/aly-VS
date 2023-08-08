using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using System.Net;
using System.Text.Json;
using WantTask.Models;
using WantTask.ViewModels;

namespace WantTask.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult List(CKeywordViewModel vm)   //首頁+關鍵字
        {
            NewIspanProjectContext db = new NewIspanProjectContext();

            IEnumerable<TaskList> datas = null;

            if (string.IsNullOrEmpty(vm.txtKeyword))
            {
                datas = from t in db.TaskLists 
                        where t.PublishOrNot == "立刻上架"
                        select t;
            }

            else
            {
                datas = db.TaskLists.Where(t => t.TaskTitle.ToUpper().Contains(vm.txtKeyword.ToUpper())
                || t.TaskDetail.ToUpper().Contains(vm.txtKeyword.ToUpper())
                || t.Address.ToUpper().Contains(vm.txtKeyword.ToUpper())              
                );
            }
            return View(datas);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            NewIspanProjectContext db = new NewIspanProjectContext();
            TaskList task = db.TaskLists.FirstOrDefault(p => p.CaseId == id);
            if (task == null)
                return RedirectToAction("List");
            CTaskWrap taskWrap = new CTaskWrap();
            taskWrap.task = task;
            return View(taskWrap);
        }
        [HttpPost]
        public ActionResult Detail(CTaskWrap pIn)
        {
            NewIspanProjectContext db = new NewIspanProjectContext();
            TaskList pDb = db.TaskLists.FirstOrDefault(p => p.CaseId == pIn.FId);
            if (pDb != null)
            {
                pDb.CaseId = pIn.FId;
                pDb.TaskTitle = pIn.FTitle;
                pDb.TaskDetail = pIn.FDetail;
                pDb.PayFrom = pIn.FPayFrom;
                //db.SaveChanges();
            }
            return RedirectToAction("List");
        }



        //public IActionResult Detail(int? id)
        //{
        //    if (id == null)
        //        return RedirectToAction("List");
        //    ViewBag.FId = id;
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Detail(CTaskDetailViewModel vm)
        //{
        //    NewIspanProjectContext db = new NewIspanProjectContext();
        //    TaskList tasklist = db.TaskLists.FirstOrDefault(t => t.CaseId == vm.txtCaseId);
        //    if ( tasklist != null)
        //    {
        //        string json = "";
        //        List<CTaskListDetailItem> taskdetailitem = null;
        //        if (HttpContext.Session.Keys.Contains(CDictionary.SK_TASKDETAIL_LIST))
        //        {
        //            json = HttpContext.Session.GetString(CDictionary.SK_TASKDETAIL_LIST);
        //            taskdetailitem  = JsonSerializer.Deserialize<List<CTaskListDetailItem>>(json);
        //        }
        //        else
        //            taskdetailitem = new List<CTaskListDetailItem>();
        //        CTaskListDetailItem item = new CTaskListDetailItem();
        //        item.CaseId =  tasklist.CaseId;
        //        item.TaskTitle = vm.txtTaskTitle;
        //        item.TaskDetail = vm.txtTaskDetail;
        //        item.task = tasklist;
        //        taskdetailitem.Add(item);
        //        json = JsonSerializer.Serialize(taskdetailitem);
        //        HttpContext.Session.SetString(CDictionary.SK_TASKDETAIL_LIST, json);
        //    }
        //    return RedirectToAction("List");
        //}

        public ActionResult Apply(int id)
        {
            // 根據id執行必要的操作，獲取數據等

            // 返回 apply.cshtml 視圖
            return View("Apply");
        }

    }
}
