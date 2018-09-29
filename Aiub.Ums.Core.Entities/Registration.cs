using System.ComponentModel.DataAnnotations.Schema;

namespace Aiub.Ums.Core.Entities
{
    [Table("Registration")]
    public class Registration
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int SectionId { get; set; }

        //public virtual Section Section { get; set; }
        //public virtual Student Student { get; set; }
    }
}
