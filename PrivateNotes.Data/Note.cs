using System;
using System.ComponentModel.DataAnnotations;

namespace PrivateNotes.Data
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public Guid UserId { get; set; }
    }
}