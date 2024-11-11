using Microsoft.EntityFrameworkCore;
using StudyBuddy.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<ParentStudentLink> ParentStudentLinks { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Folder> Folders { get; set; }
    public DbSet<UnverifiedAccount> UnverifiedAccounts { get; set; }
    public DbSet<StudySession> StudySessions { get; set; }
}