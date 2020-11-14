using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateNotes.Data;
using PrivateNotes.Models;
using PrivateNotes.Services;

namespace PrivateNotes.MVC.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var service = CreateNoteService();
            var query = service.GetAllNotes();
            return View(query);
        }
        
        // GET
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        // POST
        [Authorize]
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNote(NoteCreateModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            var service = CreateNoteService();

            if (service.CreateNote(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
        
        // GET
        [Authorize]
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var service = CreateNoteService();
            try
            {
                var entity = service.GetNoteById(id);
                return View(entity);
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("Index");
            }
        }
        
        // GET
        [Authorize]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var service = CreateNoteService();
            try
            {
                var entity = service.GetNoteById(id);
                var model = 
                    new NoteUpdateModel
                    {
                        NoteId = entity.NoteId,
                        Title = entity.Title,
                        Content = entity.Content
                    };
                return View(model);
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("Index");
            }
        }
        
        // POST
        [Authorize]
        [HttpPost]
        [ActionName("Update")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateNote(NoteUpdateModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            var service = CreateNoteService();

            if (service.UpdateNote(model))
            {
                return RedirectToAction("Index", "Note");
            }

            return View(model);
        }
        
        // GET
        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var service = CreateNoteService();
            try
            {
                var entity = service.GetNoteById(id);
                return View(entity);
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("Index");
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Index");
            }
        }
        
        // POST
        [Authorize]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteNote(int id)
        {
            var service = CreateNoteService();
            
            service.DeleteNote(id);
            
            return RedirectToAction("Index", "Note");
        }

        private NoteService CreateNoteService()
        {
            var currentUser = this.User;
            var id = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            NoteService service = new NoteService(_context, Guid.Parse(id));
            return service;
        }
    }
}