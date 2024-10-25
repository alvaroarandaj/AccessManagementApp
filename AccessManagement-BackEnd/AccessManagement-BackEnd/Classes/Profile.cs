using System.ComponentModel.DataAnnotations;

namespace AccessManagement_BackEnd.Classes
{
    public class Profile
    {
        [Key]
        public Guid Id { get; set; }
        public string ProfileName { get; set; }
        public List<Permission> Permissions { get; set; } = new List<Permission>();
        public Profile() { }
        public Profile(Guid id, string profileName)
        {
            Id = id;
            ProfileName = profileName;
        }
    }
}
