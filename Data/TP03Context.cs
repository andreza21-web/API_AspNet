using Microsoft.EntityFrameworkCore;
using TP03API.Models;

namespace TP03API.Data
{
    public class TP03Context : DbContext
    {
        public TP03Context(DbContextOptions<TP03Context> options)
            : base(options)
        {
        }

        public DbSet<Livros> Livros { get; set; } = default!;
    }
}
