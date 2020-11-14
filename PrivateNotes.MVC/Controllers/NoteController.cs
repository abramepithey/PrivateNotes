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
        public IActionResult CreateNote(NoteCreateModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = CreateNoteService();
            service.CreateNote(model);
            return RedirectToAction("Index");
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