using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventMananger.Data;
using EventMananger.Models;
using Microsoft.AspNetCore.Authorization;

namespace EventMananger.Controllers
{
    [Authorize(Roles = "Admin, Manager, User")]

    public class EventParticipantsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EventParticipantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventParticipants
        public async Task<IActionResult> Index(string? eventNames, string? searchString)
        {
            IQueryable<string> eventNameQuery = from b in _context.EventParticipant
                                                orderby b.EventName
                                                select b.EventName;

            var events = from b in _context.EventParticipant
                         select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s => s.EventName!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(eventNames))
            {
                events = events.Where(x => x.EventName == eventNames);
            }

            var eventNameVM = new EventParticipantViewModel
            {
                Name = new SelectList(await eventNameQuery.Distinct().ToListAsync()),
                EventParticipants = await events.ToListAsync()
            };

            return View(eventNameVM);
        }

        // GET: EventParticipants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EventParticipant == null)
            {
                return NotFound();
            }

            var eventParticipant = await _context.EventParticipant
                .FirstOrDefaultAsync(m => m.EventParticipantId == id);
            if (eventParticipant == null)
            {
                return NotFound();
            }

            return View(eventParticipant);
        }

        // GET: EventParticipants/Create
        public IActionResult Create()
        {
            // Lấy danh sách các sự kiện từ cơ sở dữ liệu
            var events = _context.Event.ToList();

            // Truyền danh sách các sự kiện đến view thông qua ViewBag
            ViewBag.Events = events;

            return View();
        }

        // POST: EventParticipants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventParticipantId,EventName,EventImage,EventParticipantName,EventParticipantEmail,EventParticipantPhone")] EventParticipant eventParticipant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventParticipant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventParticipant);
        }

        // GET: EventParticipants/Edit/5
        // GET: EventParticipants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EventParticipant == null)
            {
                return NotFound();
            }

            var eventParticipant = await _context.EventParticipant.FindAsync(id);
            if (eventParticipant == null)
            {
                return NotFound();
            }

            // Lấy danh sách các sự kiện từ cơ sở dữ liệu
            var events = _context.Event.ToList();

            // Truyền danh sách các sự kiện đến view thông qua ViewBag
            ViewBag.Events = events;

            return View(eventParticipant);
        }

        // POST: EventParticipants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventParticipantId,EventName,EventImage,EventParticipantName,EventParticipantEmail,EventParticipantPhone")] EventParticipant eventParticipant)
        {
            if (id != eventParticipant.EventParticipantId)
            {
                return NotFound();
            }

            // Check ModelState for validation errors
            if (ModelState.IsValid)
            {
                try
                {
                    // Update the entity and save changes
                    _context.Update(eventParticipant);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventParticipantExists(eventParticipant.EventParticipantId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // If ModelState is not valid, return the view with validation errors
            return View(eventParticipant);
        }


        // GET: EventParticipants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EventParticipant == null)
            {
                return NotFound();
            }

            var eventParticipant = await _context.EventParticipant
                .FirstOrDefaultAsync(m => m.EventParticipantId == id);
            if (eventParticipant == null)
            {
                return NotFound();
            }

            return View(eventParticipant);
        }

        // POST: EventParticipants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EventParticipant == null)
            {
                return Problem("Entity set 'EventManangerContext.EventParticipant'  is null.");
            }
            var eventParticipant = await _context.EventParticipant.FindAsync(id);
            if (eventParticipant != null)
            {
                _context.EventParticipant.Remove(eventParticipant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventParticipantExists(int id)
        {
            return (_context.EventParticipant?.Any(e => e.EventParticipantId == id)).GetValueOrDefault();
        }
        public IActionResult GetEventImage(string eventName)
        {
            // Tìm sự kiện có tên là eventName trong cơ sở dữ liệu và lấy EventImage của nó
            var eventImage = _context.Event.FirstOrDefault(e => e.EventName == eventName)?.EventImage;

            return Json(eventImage);
        }


    }
}
