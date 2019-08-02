using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using NGOWorld.Common;
using NGOWorld.Data.Entities;
using NGOWorld.Service.DoctorService;

namespace NGOWorld.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KendoRead([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                if (!request.Sorts.Any())
                {
                    request.Sorts.Add(new SortDescriptor("DoctorName", ListSortDirection.Ascending));
                }

                List<tblDoctor> list = _service.GetAll().ToList();

                return Json(list.ToDataSourceResult(request));

            }
            catch (Exception ex)
            {
                return Json(ex);
            }

        }

        public IActionResult KendoSave([DataSourceRequest] DataSourceRequest request, tblDoctor model)
        {

            if (model == null || !ModelState.IsValid)
            {
                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            }

            string message = string.Empty;

            try
            {
                if (model.Id > 0)
                {
                    _service.Update(model);
                }
                else
                {
                    _service.Insert(model);
                }
            }
            catch (Exception ex)
            {
                message = CommonHelper.GetErrorMessage(ex);
            }


            ModelState.Clear();
            if (!string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError("Name", message);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public IActionResult KendoDestroy([DataSourceRequest] DataSourceRequest request, tblDoctor model)
        {
            string deleteMessage = string.Empty;

            try
            {
                _service.Delete(model.Id);
            }
            catch (Exception ex)
            {
                deleteMessage = CommonHelper.GetErrorMessage(ex);
            }

            ModelState.Clear();
            if (!string.IsNullOrEmpty(deleteMessage))
            {
                ModelState.AddModelError(deleteMessage, deleteMessage);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}