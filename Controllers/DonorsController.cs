using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookDonorsAPI.Data;
using BookDonorsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookDonorsAPI.Controllers
{
    [Route("[controller]")]
    public class DonorsController : Controller
    {
        private readonly BookDonationContext _context;

        public DonorsController(BookDonationContext context)
        {
            _context = context;
        }

        // GET: Donors
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var donors = await _context.Donors.ToListAsync();
            return View(donors); // Returns the list view of donors
        }

        // GET: Donors/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor); // Returns the details view of a specific donor
        }

        // GET: Donors/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new donor
        }

        // POST: Donors/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Donor donor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the donors list after creation
            }
            return View(donor); // If the model state is invalid, return to the Create view with the model
        }

        // GET: Donors/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            return View(donor); // Returns the edit view for a specific donor
        }

        // POST: Donors/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Donor donor)
        {
            if (id != donor.DonorID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the donors list after edit
            }
            return View(donor); // If the model state is invalid, return to the Edit view with the model
        }

        // GET: Donors/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor); // Returns the delete confirmation view for a specific donor
        }

        // POST: Donors/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor != null)
            {
                _context.Donors.Remove(donor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the donors list after deletion
        }

        // *** NEW: About Us ***
        // GET: About Us
        [HttpGet("About")]
        public IActionResult About()
        {
            return View(); // Returns the About Us view
        }

        private bool DonorExists(int id)
        {
            return _context.Donors.Any(e => e.DonorID == id);
        }
    }
}
