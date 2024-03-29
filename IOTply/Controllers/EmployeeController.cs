﻿using IOTply.Data;
using IOTply.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTply.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public class ModelCollection
        {
            public EmployeeReg EmpModel { get; set; }
            public LogDetails LogModel { get; set; }
        }

        public IActionResult Home()
        {
            IEnumerable<LogDetails> _logList = _db.LogDetails;
            return View(_logList);
        }
        
        public IActionResult Statics()
        {
            IEnumerable<LogDetails> _logList = _db.LogDetails;
            return View(_logList);
        }

        public IActionResult ProfileMng()
        {
            IEnumerable<EmployeeReg> _stdList = _db.Employee;
            return View(_stdList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeReg obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employee.Add(obj);
                _db.SaveChanges();
            }

            return RedirectToAction("ProfileMng");
        }

    }
}
