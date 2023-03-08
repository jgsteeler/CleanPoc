using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanPoc.Core.Entities.Base;

public class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }

    public DateTime ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
   
}