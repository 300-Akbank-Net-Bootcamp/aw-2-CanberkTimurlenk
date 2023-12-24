using System.ComponentModel.DataAnnotations.Schema;
using Vb.Base.Entity;

namespace Vb.Data.Entity;

[Table("Address", Schema = "dbo")]
public class Address : BaseEntity
{
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string PostalCode { get; set; }
    public bool IsDefault { get; set; }
}
