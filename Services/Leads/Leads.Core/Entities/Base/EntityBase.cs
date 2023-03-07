using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leads.Core.Entities.Base;

public class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; private set; }

    public BaseEntity()
    {
        this.ModifiedDate = DateTime.Now;
    }
}