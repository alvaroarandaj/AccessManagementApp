using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AccessManagement_BackEnd.Classes
{
    public class Installation
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Installation(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
