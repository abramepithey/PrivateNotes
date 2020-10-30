using System.Collections.Generic;
using PrivateNotes.Contracts;
using PrivateNotes.Data;
using PrivateNotes.Models;

namespace PrivateNotes.Services
{
    public class NoteService : INoteService
    {
        private ApplicationDbContext _context;

        public NoteService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<NoteListModel> GetAllNotes()
        {
            throw new System.NotImplementedException();
        }

        public NoteDetailModel GetNoteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateNote(NoteCreateModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateNote(NoteUpdateModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteNote(int id)
        {
            throw new System.NotImplementedException();
        }

        public Note GetNoteHelper()
        {
            throw new System.NotImplementedException();
        }
    }
}