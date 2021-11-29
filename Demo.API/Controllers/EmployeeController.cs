using AutoMapper;
using Demo.BL.Helper;
using Demo.BL.Interfaces;
using Demo.BL.Models;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        #region Fields

        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;
        private readonly ICountryRep country;
        private readonly ICityRep city;
        private readonly IDistrictRep district;
        private readonly IMapper mapper;

        #endregion

        #region Ctor

        public EmployeeController(IEmployeeRep _employee, IDepartmentRep _department, ICountryRep _country, ICityRep _city, IDistrictRep _district, IMapper _mapper)
        {
            employee = _employee;
            department = _department;
            country = _country;
            city = _city;
            district = _district;
            mapper = _mapper;
        }

        #endregion

        #region Actions


        [HttpGet]
        [Route("~/api/GetEmployee")]
        public IActionResult GetEmployee()
        {
            try
            {
                var data = mapper.Map<IEnumerable<EmployeeVM>>(employee.Get());

                var result = new ApiResponse<EmployeeVM> 
                { 
                  Response = new Response("200","Succeed","Done"),
                  Records = data
                };

                return Ok(result);
            }
            catch (Exception ex)
            {

                var result = new ApiResponse<EmployeeVM>
                {
                    Response = new Response("400", "Faild", ex.Message),
                };

                return NotFound(result);
            }
        }


        [HttpGet]
        [Route("~/api/GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var data = mapper.Map<EmployeeVM>(employee.GetById(id));

                var result = new ApiResponse<EmployeeVM>
                {
                    Response = new Response("200", "Succeed", "Done"),
                    Record = data
                };

                return Ok(result);
            }
            catch (Exception ex)
            {

                var result = new ApiResponse<EmployeeVM>
                {
                    Response = new Response("400", "Faild", ex.Message),
                };

                return NotFound(result);
            }
        }


        [HttpPost]
        [Route("~/api/SearchByName/{name}")]
        public IActionResult SearchByName(string name)
        {
            try
            {
                var data = mapper.Map<IEnumerable<EmployeeVM>>(employee.SearchByName(name));

                var result = new ApiResponse<EmployeeVM>
                {
                    Response = new Response("200", "Succeed", "Done"),
                    Records = data
                };

                return Ok(result);
            }
            catch (Exception ex)
            {

                var result = new ApiResponse<EmployeeVM>
                {
                    Response = new Response("400", "Faild", ex.Message),
                };

                return NotFound(result);
            }
        }


        [HttpGet]
        [Route("~/api/GetPaging/{index}/{Psize}")]
        public IActionResult GetPaging(int index, int Psize)
        {
            try
            {
                var data = mapper.Map<IEnumerable<EmployeeVM>>(employee.Paging(index,Psize));

                var result = new ApiResponse<EmployeeVM>
                {
                    Response = new Response("200", "Succeed", "Done"),
                    Records = data
                };

                return Ok(result);
            }
            catch (Exception ex)
            {

                var result = new ApiResponse<EmployeeVM>
                {
                    Response = new Response("400", "Faild", ex.Message),
                };

                return NotFound(result);
            }
        }


        [HttpPost]
        [Route("~/api/CreateEmployee")]
        public IActionResult CreateEmployee(EmployeeVM obj)
        {
            try
            {

                var data = mapper.Map<Employee>(obj);
                
                var model = employee.Create(data);

                var result = new ApiResponse<Employee>
                {
                    Response = new Response("200", "Succeed", "Done"),
                    Record = model
                };

                return Ok(result);
            }
            catch (Exception ex)
            {

                var result = new ApiResponse<EmployeeVM>
                {
                    Response = new Response("400", "Faild", ex.Message),
                };

                return NotFound(result);
            }
        }


        [HttpPut]
        [Route("~/api/PutEmployee")]
        public IActionResult PutEmployee(EmployeeVM obj)
        {
            try
            {

                var data = mapper.Map<Employee>(obj);

                var model = employee.Update(data);

                var result = new ApiResponse<Employee>
                {
                    Response = new Response("200", "Succeed", "Done"),
                    Record = model
                };

                return Ok(result);
            }
            catch (Exception ex)
            {

                var result = new ApiResponse<EmployeeVM>
                {
                    Response = new Response("400", "Faild", ex.Message),
                };

                return NotFound(result);
            }
        }



        [HttpDelete]
        [Route("~/api/DeleteEmployee")]
        public IActionResult DeleteEmployee(EmployeeVM obj)
        {
            try
            {

                var data = mapper.Map<Employee>(obj);

                var model = employee.Delete(data);

                var result = new ApiResponse<Employee>
                {
                    Response = new Response("200", "Succeed", "Done"),
                    Record = model
                };

                return Ok(result);
            }
            catch (Exception ex)
            {

                var result = new ApiResponse<EmployeeVM>
                {
                    Response = new Response("400", "Faild", ex.Message),
                };

                return NotFound(result);
            }
        }


        #endregion


    }
}
