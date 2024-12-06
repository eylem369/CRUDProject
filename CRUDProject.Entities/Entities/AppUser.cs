namespace CRUDProject.Entities.Entities
{
    public class AppUser : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string? ImagePath { get; set; } = "wwwroot/UserImages/defaultImage.png";
    }
}
