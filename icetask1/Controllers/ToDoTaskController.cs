﻿using icetask1.Data;
using icetask1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace icetask1.Controllers
{
    public class ToDoTasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToDoTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ToDoTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tasks.ToListAsync());
        }

        // GET: ToDoTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoTask = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoTask == null)
            {
                return NotFound();
            }

            return View(toDoTask);
        }

        // GET: ToDoTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DueDate,IsCompleted")] ToDoTask toDoTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDoTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoTask);
        }

        // GET: ToDoTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoTask = await _context.Tasks.FindAsync(id);
            if (toDoTask == null)
            {
                return NotFound();
            }
            return View(toDoTask);
        }

        // POST: ToDoTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DueDate,IsCompleted")] ToDoTask toDoTask)
        {
            if (id != toDoTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoTaskExists(toDoTask.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(toDoTask);
        }

        // GET: ToDoTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoTask = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoTask == null)
            {
                return NotFound();
            }

            return View(toDoTask);
        }

        // POST: ToDoTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDoTask = await _context.Tasks.FindAsync(id);
            if (toDoTask != null)
            {
                _context.Tasks.Remove(toDoTask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
