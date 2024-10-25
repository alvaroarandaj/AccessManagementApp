using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace AccessManagement_BackEnd.Classes
{
    public class AccessRecord
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [ForeignKey("AccessPoint")]
        public Guid AccessPointId { get; set; }
        public DateTime AccessDateTime { get; set; }

        public AccessRecord(Guid id, Guid userId, Guid accessPointId, DateTime accessDateTime)
        {
            Id = id;
            UserId = userId;
            AccessPointId = accessPointId;
            AccessDateTime = accessDateTime;
        }

    }
}
