using System.ComponentModel.DataAnnotations.Schema;
using Vb.Base.Entity;

namespace Vb.Data.Entity;

[Table("EftTransaction", Schema = "dbo")]
public class EftTransaction : BaseEntity
{
    public int AccountId { get; set; }
    public virtual Account Account { get; set; }

    public string ReferenceNumber { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }

    public string SenderAccount { get; set; }
    public string SenderIban { get; set; }
    public string SenderName { get; set; }
}
