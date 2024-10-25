using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessManagement_BackEnd.Classes
{
    public class AccessPoint
    {
        [Key]
        public Guid Id { get; set; }
        public string PointName { get; set; }

        [ForeignKey("Installation")]
        public Guid InstallationId { get; set; }

        public Installation Installation { get; set; } 
        
        public AccessPoint() { }

        public AccessPoint(Guid id, string pointName, Installation installation)
        {
            Id = id;
            PointName = pointName;
            InstallationId = installation.Id;
            Installation = installation;
        }
    }
}
