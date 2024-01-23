namespace MvcFriends.Data
{
    public class FriendContext : DbContext
    {
        public FriendContext(DbContextOptions<FriendContext> options) : base(options)
        {

        }

        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>().HasData(
                new Friend(){ Id = 1, Name = "Mary", Email = "mary@gmail.com", Mobile="09123456", Country="TW"},
                new Friend(){ Id = 2, Name = "Tom", Email = "tom@gmail.com", Mobile="09789640", Country="JP"},
                new Friend(){ Id = 3, Name = "John", Email = "john@gmail.com", Mobile="09889111", Country="CN"}
            );
        }
    }
}