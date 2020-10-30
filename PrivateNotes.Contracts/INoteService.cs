using System.Collections;

namespace PrivateNotes.Contracts
{
    public interface INoteService
    {
        IEnumerable<NoteListModel> GetAllNotes();
        NoteDetailModel GetNoteById(int id);
        bool CreateNote(NoteCreateModel model);
        bool UpdateNote(NoteUpdateModel model);
        bool DeleteNote(int id);
    }
}