using System.Collections.Generic;
using PrivateNotes.Data;
using PrivateNotes.Models;

namespace PrivateNotes.Contracts
{
    public interface INoteService
    {
        IEnumerable<NoteListModel> GetAllNotes();
        NoteDetailModel GetNoteById(int id);
        bool CreateNote(NoteCreateModel model);
        bool UpdateNote(NoteUpdateModel model);
        bool DeleteNote(int id);
        Note GetNoteHelper(int id);
    }
}