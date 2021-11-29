using AutoMapper;
using Demo.BL.Interfaces;
using Demo.BL.Models;
using Demo.BL.Repository;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{

    public class DepartmentController : Controller
    {



        #region Fields

        private readonly IDepartmentRep department;
        private readonly IMapper mapper;

        #endregion

        #region Ctor

        public DepartmentController(IDepartmentRep _department, IMapper _mapper)
        {
            department = _department;
            mapper = _mapper;
        }

        #endregion

        #region Actions

        public IActionResult Index(string SearchValue = "")
        {
            if(SearchValue == "" || SearchValue == null)
            {
                //var result = department.Get();
                var data = mapper.Map<IEnumerable<DepartmentVM>>(department.Get());
                return View(data);
            }
            else
            {
                var data = mapper.Map<IEnumerable<DepartmentVM>>(department.SearchByName(SearchValue));
                return View(data);
            }

        }


        public IActionResult Details(int id)
        {
            var data = mapper.Map<DepartmentVM>(department.GetById(id));
            return View(data);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(DepartmentVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);
                    department.Create(data);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }


        public IActionResult Edit(int id)
        {
            var data = mapper.Map<DepartmentVM>(department.GetById(id));
            return View(data);
        }


        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var data = mapper.Map<Department>(model);
                    department.Update(data);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }


        public IActionResult Delete(int id)
        {
            var data = mapper.Map<DepartmentVM>(department.GetById(id));
            return View(data);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {

            try
            {
                var oldData = department.GetById(id);
                department.Delete(oldData);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                var data = mapper.Map<DepartmentVM>(department.GetById(id));
                return View(data);
            }

        }

        #endregion



    }
}
