
using COMP003B.Assignment3.Models;
using Microsoft.AspNetCore.Mvc;


namespace COMP003B.Assignment3.Controllers
{
    public class EventsController : Controller
    {
        private static List<Event> _Events = new List<Event>();

        // GET: Events
        public IActionResult Index()
        {
            return View(_Events);
        }

        // GET: Events/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event Event)
        {
            // TODO: add model state valLocationation
            if (ModelState.IsValid)
            {
                // TODO: check if Event already exists
                if (!_Events.Any(s => s.Location == Event.Location))
                {
                    // TODO: add Event to list
                    _Events.Add(Event);
                }

                // TODO: redirect back to index
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Events/Edit/5
        [HttpGet]
        public IActionResult Edit(string? Location)
        {
            // TODO: check if Location is null
            if (Location == null)
            {
                return NotFound();
            }

            // TODO: find Event by Location
            var Event = _Events.FirstOrDefault(p => p.Location == Location);

            // TODO: check again if Event is null after searching the list
            if (Event == null)
            {
                return NotFound();
            }

            // TODO: return Event to view
            return View(Event);

        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string Location, Event Event)
        {
            // TODO: check if Location is the same as Event Location
            if (Location != Event.Location)
            {
                return NotFound();
            }

            // TODO: check if model state is valLocation
            if (ModelState.IsValid)
            {
                // TODO: search for Event in list
                var existingEvent = _Events.FirstOrDefault(s => s.Location == Event.Location);

                // TODO: chec if Event found
                if (existingEvent != null)
                {
                    // TODO: update Event details
                    existingEvent.Name = Event.Name;
                    existingEvent.Date = Event.Date;
                }

                //TODO: redirect back to index
                return RedirectToAction(nameof(Index));
            }

            return View(Event);
        }

        // GET: Events/Delete/5
        [HttpGet]
        public IActionResult Delete(string? Location)
        {
            // TODO: null check
            if (Location == null)
            {
                return NotFound();
            }

            // TODO: find Event by Location
            var Event = _Events.FirstOrDefault(s => s.Location == Location);

            // TODO: null check after searching the list
            if (Event == null)
            {
                return NotFound();
            }

            // TODO: returns the view of the Event found form the list
            return View(Event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string Location)
        {
            // TODO: look for Event in list
            var Event = _Events.FirstOrDefault(s => s.Location == Location);

            // TODO: Event found in list
            if (Event != null)
            {
                // TODO: remove Event from list
                _Events.Remove(Event);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}