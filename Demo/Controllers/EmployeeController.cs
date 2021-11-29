using AutoMapper;
using Demo.BL.Helper;
using Demo.BL.Interfaces;
using Demo.BL.Models;
using Demo.DAL.Entity;
using Demo.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{

    //[Authorize(Roles = "Admin , Customer")]
    public class EmployeeController : Controller
    {



        #region Fields

        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;
        private readonly ICountryRep country;
        private readonly ICityRep city;
        private readonly IDistrictRep district;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResource> localizer;

        #endregion

        #region Ctor

        public EmployeeController(IEmployeeRep _employee , IDepartmentRep _department , ICountryRep _country, ICityRep _city , IDistrictRep _district , IMapper _mapper , IStringLocalizer<SharedResource> localizer)
        {
            employee = _employee;
            department = _department;
            country = _country;
            city = _city;
            district = _district;
            mapper = _mapper;
            this.localizer = localizer;
        }

        #endregion

        #region Actions

        public IActionResult Index(string SearchValue = "")
        {
            if (SearchValue == "" || SearchValue == null)
            {
                //var result = department.Get();
                var data = mapper.Map<IEnumerable<EmployeeVM>>(employee.Get());

                ViewBag.Msg = localizer["Success"];

                return View(data);
            }
            else
            {
                var data = mapper.Map<IEnumerable<EmployeeVM>>(employee.SearchByName(SearchValue));
                return View(data);
            }

        }


        public IActionResult Details(int id)
        {
            var data = mapper.Map<EmployeeVM>(employee.GetById(id));
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "DepartmentName",data.DepartmentId);

            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.DepartmentList = new SelectList(department.Get(),"Id","DepartmentName");
            ViewBag.CountryList = new SelectList(country.Get(), "Id", "CountryName");

            return View();
        }


        [HttpPost]
        public IActionResult Create(EmployeeVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {


                    var PhotoName = FileUploader.UploadFile("/Files/Photos/",model.PhotoUrl);
                    var CvName = FileUploader.UploadFile("/Files/Docs/", model.CvUrl);

                    var data = mapper.Map<Employee>(model);

                    data.Photo = PhotoName;
                    data.Cv = CvName;

                    employee.Create(data);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {

                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "DepartmentName");
                ViewBag.CountryList = new SelectList(country.Get(), "Id", "CountryName");

                return View(model);
            }

        }


        public IActionResult Edit(int id)
        {

            var data = mapper.Map<EmployeeVM>(employee.GetById(id));
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "DepartmentName",data.DepartmentId);

            return View(data);
        }


        [HttpPost]
        public IActionResult Edit(EmployeeVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var data = mapper.Map<Employee>(model);
                    employee.Update(data);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {

                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "DepartmentName", model.DepartmentId);
                return View(model);
            }

        }


        public IActionResult Delete(int id)
        {
            var data = mapper.Map<EmployeeVM>(employee.GetById(id));
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "DepartmentName", data.DepartmentId);

            return View(data);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {

            try
            {
                var oldData = employee.GetById(id);

                FileUploader.RemoveFile("/Files/Photos/", oldData.Photo);
                FileUploader.RemoveFile("/Files/Docs/", oldData.Cv);


                employee.Delete(oldData);


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                var data = mapper.Map<DepartmentVM>(department.GetById(id));
                return View(data);
            }

        }

        #endregion

        #region Ajax Call



        // Get All City Data By Country ID


        [HttpPost]
        public JsonResult GetCityByCntryID(int CtryID)
        {
            var data = city.Get().Where(x => x.CountryId == CtryID);
            return Json(data);
        }




        // Fet All District Data By City ID


        [HttpPost]
        public JsonResult GetDistrictByCity(int CtyID)
        {
            var data = district.Get().Where(x => x.CityId == CtyID);
            return Json(data);
        }


        #endregion


    }
}
