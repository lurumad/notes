using Microsoft.EntityFrameworkCore;
using Notes.Model;

namespace Notes.Infrastructure.Data
{
    public class NotesDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {

        }
    }
}
