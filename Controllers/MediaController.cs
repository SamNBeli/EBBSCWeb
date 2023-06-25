using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBBSCweb.Data;
using EBBSCweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EBBSCweb.Controllers
{
    public class MediaController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MediaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Media Page Management
        public async Task<IActionResult> Index()
        {
            var objMediaList = _context.Medias;
            return objMediaList != null ? View(await objMediaList.ToListAsync()) : Problem("Entity 'Media' is null ");
        }

        //GET: Add Media
        public IActionResult AddMedia()
        {
            return View();
        }

        // POST: Add Media
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMedia([Bind("Id,Name,DisplayOrder,Link")] Media media)
        {
            if (ModelState.IsValid)
            {
                _context.Add(media);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(media);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medias == null)
            {
                return NotFound();
            }

            var media = await _context.Medias.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }
            return View(media);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DisplayOrder,Link")] Media media)
        {
            if (id != media.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(media);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaExists(media.Id))
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
            return View(media);
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medias == null)
            {
                return NotFound();
            }

            var media = await _context.Medias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medias == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
            }
            var media = await _context.Medias.FindAsync(id);
            if (media != null)
            {
                _context.Medias.Remove(media);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaExists(int id)
        {
            return (_context.Medias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

