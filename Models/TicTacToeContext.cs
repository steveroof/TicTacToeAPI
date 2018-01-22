using Microsoft.EntityFrameworkCore;

namespace TicTacToeAPI.Models
{
    public class TicTacToeContext : DbContext
    {
        public TicTacToeContext(DbContextOptions<TicTacToeContext> options)
            : base(options)
        {
        }

        public DbSet<TicTacToeItem> TicTacToeItems { get; set; }

    }
}