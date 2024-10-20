using DemoIdentity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoIdentity.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
        public readonly ApplicationDbContext _context;

        public HouseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HouseController
        public ActionResult Index()
        {
            try
            {
                var list = _context.House.ToList();
                return View(list);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: HouseController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var house = _context.House.Include(h => h.Owner).FirstOrDefault(p => p.id == id);
                return View(house);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: HouseController/Create
        public ActionResult Create()
        {
            var userlist = _context.Users.ToList();
            ViewBag.OwnerId = new SelectList(userlist, "Id", "FirstName");
            return View();
        }

        // POST: HouseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(House house)
        {
            try
            {
                _context.Add(house);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(house);
            }
        }

        // GET: HouseController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var house = _context.House.Include(h => h.Owner).FirstOrDefault(p => p.id == id);
                var userlist = _context.Users.ToList();
                ViewBag.OwnerId = new SelectList(userlist, "Id", "FirstName");
                return View(house);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: HouseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, House house)
        {
            try
            {
                _context.Update(house);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HouseController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var house = _context.House.Include(h => h.Owner).FirstOrDefault(p => p.id == id);
                return View(house);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: HouseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Delete(int id, House house)
        {
            try
            {
                var p = _context.House.Find(house.id);
                if(p == null)
                {
                    return View();
                }
                _context.House.Remove(p);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
