﻿using AutoMapper;
using Demo.BL.Models;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BL.Mapper
{
    public class DomainProfile : Profile
    {


        public DomainProfile()
        {
            CreateMap<Department,DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();

            CreateMap<City, CityVM>();
            CreateMap<CityVM, City>();

            CreateMap<District, DistrictVM>();
            CreateMap<DistrictVM, District>();

            CreateMap<RegistrationVM, IdentityUser>();
            CreateMap<IdentityUser, RegistrationVM>();

        }


    }
}
