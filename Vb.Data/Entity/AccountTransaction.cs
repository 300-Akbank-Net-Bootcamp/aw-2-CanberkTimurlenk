using System.ComponentModel.DataAnnotations.Schema;
using Vb.Base.Entity;

namespace Vb.Data.Entity;

[Table("AccountTransaction", Schema = "dbo")]
public class AccountTransaction : BaseEntity
{
    public int AccountId { get; set; }
    public virtual Account Account { get; set; }

    public string ReferenceNumber { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public string TransferType { get; set; }
}