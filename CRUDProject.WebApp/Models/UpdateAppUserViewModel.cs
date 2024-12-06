namespace CRUDProject.WebApp.Models
{
    public class UpdateAppUserViewModel
    {
        public string Username { get; set; }
        public int Id { get; set; }
        public IFormFile File { get; set; }
    }
}
