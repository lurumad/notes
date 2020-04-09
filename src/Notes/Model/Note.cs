using System;

namespace Notes.Model
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Important { get; set; }
        public string UserId { get; set; }
    }
}
