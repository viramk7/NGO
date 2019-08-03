using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NGOWorld.Common;
using NGOWorld.Entity.CustomModel;
using NGOWorld.Service.DoctorService;

namespace NGOWorld.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(IDoctorService service, ILogger<DoctorController> logger)
        {
            _service = service;
            _logger = logger;
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

                List<DoctorModel> list = _service.GetAll<DoctorModel>().ToList();

                return Json(list.ToDataSourceResult(request));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Json(ex);
            }

        }

        public IActionResult KendoSave([DataSourceRequest] DataSourceRequest request, DoctorModel model)
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
                _logger.LogError(ex.StackTrace);
                message = CommonHelper.GetErrorMessage(ex);
            }


            ModelState.Clear();
            if (!string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError("Name", message);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public IActionResult KendoDestroy([DataSourceRequest] DataSourceRequest request, DoctorModel model)
        {
            string deleteMessage = string.Empty;

            try
            {
                _service.DeleteById(model.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
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