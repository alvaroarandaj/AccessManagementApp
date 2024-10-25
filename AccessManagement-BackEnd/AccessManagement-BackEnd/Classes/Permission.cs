using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace AccessManagement_BackEnd.Classes
{
    public class Permission
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("AccessPoint")]
        public Guid AccessPointId { get; set; }

        public Permission(Guid id, Guid accessPointId)
        {
            Id = id;
            AccessPointId = accessPointId;
        }
    }
}
