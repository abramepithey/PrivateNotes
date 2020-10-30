using System.Collections.Generic;
using PrivateNotes.Contracts;
using PrivateNotes.Models;

namespace PrivateNotes.Services
{
    public class NoteService : INoteService
    {
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
    }
}