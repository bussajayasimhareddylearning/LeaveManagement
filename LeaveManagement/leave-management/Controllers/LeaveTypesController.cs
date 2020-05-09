using AutoMapper;
using leave_management.Contracts;
using leave_management.Data;
using leave_management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leave_management.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly IRepositoryLeaveType _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(IRepositoryLeaveType repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: LeaveTypes
        public ActionResult Index()
        {
            List<LeaveType> leaveTypes = _repo.FindAll().ToList();
            List<DetailLeaveTypeVM> DeatilsOfLeaveTypes_VM = _mapper.Map<List<LeaveType>, List<DetailLeaveTypeVM>>(leaveTypes);
            return View(DeatilsOfLeaveTypes_VM);
        }

        // GET: LeaveTypes/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExists(id)) return NotFound();
            LeaveType leaveType = _repo.FindById(id);
            DetailLeaveTypeVM detailLeaveTypeVM = _mapper.Map<DetailLeaveTypeVM>(leaveType);
            return View(detailLeaveTypeVM);
        }

        // GET: LeaveTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetailLeaveTypeVM leaveTypeVM)
        {
            try
            {
                if (!ModelState.IsValid) return View(leaveTypeVM);
                LeaveType leaveType = _mapper.Map<LeaveType>(leaveTypeVM);
                leaveType.DateCreated = DateTime.Now;
                bool Success = _repo.Create(leaveType);
                if (Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Something went Wrong...");
                    return View(leaveTypeVM);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(leaveTypeVM);
            }
        }

        // GET: LeaveTypes/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExists(id)) return NotFound();
            LeaveType leaveType = _repo.FindById(id);
            DetailLeaveTypeVM detailLeaveTypeVM = _mapper.Map<DetailLeaveTypeVM>(leaveType);
            return View(detailLeaveTypeVM);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetailLeaveTypeVM detailLeaveTypeVM)
        {
            try
            {
                if (!ModelState.IsValid) return View(detailLeaveTypeVM);
                LeaveType leaveType = _mapper.Map<LeaveType>(detailLeaveTypeVM);
                bool success = _repo.Update(leaveType);
                if (!success)
                {
                    ModelState.AddModelError("", "something went wrong...");
                    return View(detailLeaveTypeVM);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "something went wrong...");
                return View(detailLeaveTypeVM);
            }
        }

        // GET: LeaveTypes/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                LeaveType leaveType = _repo.FindById(id);
                bool success = _repo.Delete(leaveType);
                if (!success)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DetailLeaveTypeVM detailLeaveTypeVM)
        {
            try
            {
                LeaveType leaveType = _repo.FindById(id);
                bool success = _repo.Delete(leaveType);
                if (!success)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}