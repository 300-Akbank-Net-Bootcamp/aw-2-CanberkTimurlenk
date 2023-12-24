using System.ComponentModel.DataAnnotations.Schema;
using Vb.Base.Entity;

namespace Vb.Data.Entity;

[Table("Contact", Schema = "dbo")]
public class Contact : BaseEntity
{
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public string ContactType { get; set; }
    public string Information { get; set; }
    public bool IsDefault { get; set; }
}
