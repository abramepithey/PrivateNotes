using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PrivateNotes.Contracts;
using PrivateNotes.Data;
using PrivateNotes.Models;

namespace PrivateNotes.Services
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDbContext _context;
        private readonly Guid _userId;

        public NoteService(ApplicationDbContext context, Guid userId)
        {
            _context = context;
            _userId = userId;
        }
        
        public IEnumerable<NoteListModel> GetAllNotes()
        {
            var query = _context
                .Notes
                .Where(q => q.UserId == _userId)
                .Select(n => new NoteListModel
                {
                    NoteId = n.NoteId,
                    Title = n.Title
                }).ToArray();

            return query;
        }

        public NoteDetailModel GetNoteById(int id)
        {
            var entity = GetNoteHelper(id);
            
            return new NoteDetailModel
            {
                NoteId = entity.NoteId,
                Title = entity.Title,
                Content = entity.Content
            };
        }

        public bool CreateNote(NoteCreateModel model)
        {
            Note note = new Note {Title = model.Title, Content = model.Content, UserId = _userId};

            _context.Notes.Add(note);

            return _context.SaveChanges() == 1;
        }

        public bool UpdateNote(NoteUpdateModel model)
        {
            var entity = GetNoteHelper(model.NoteId);

            entity.Title = model.Title;
            entity.Content = model.Content;

            return _context.SaveChanges() == 1;
        }

        public bool DeleteNote(int id)
        {
            var entity = GetNoteHelper(id);

            _context.Notes.Remove(entity);

            return _context.SaveChanges() == 1;
        }

        private Note GetNoteHelper(int id)
        {
            var entity = _context
                .Notes
                .Single(e => e.NoteId == id && e.UserId == _userId);

            return entity;
        }
    }
}