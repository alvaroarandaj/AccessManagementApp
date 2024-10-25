using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessManagement_BackEnd.Classes
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }

        public Profile Profile { get; set; }

        public User() { }

        public User(Guid id, string name, Profile profile)
        {
            Id = id;
            Name = name;
            ProfileId = profile.Id;
            Profile = profile;
        }
    }
}
