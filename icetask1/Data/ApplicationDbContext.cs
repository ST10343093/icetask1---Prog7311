using icetask1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace icetask1.Data
{
    public class ApplicationDbContext : DbContext
    {
        //constructor that passes the DbContext options to the base class for configuration
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //DbSet representing the collection of ToDoTask entities in the database
        public DbSet<ToDoTask> Tasks { get; set; }
    }
}
