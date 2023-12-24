using System.ComponentModel.DataAnnotations.Schema;
using Vb.Base.Entity;

namespace Vb.Data.Entity;

[Table("Account", Schema = "dbo")]
public class Account : BaseEntity
{
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public int AccountNumber { get; set; }
    public string IBAN { get; set; }
    public decimal Balance { get; set; }
    public string CurrencyType { get; set; }
    public string Name { get; set; }
    public DateTime OpenDate { get; set; }

    public virtual List<AccountTransaction> AccountTransactions { get; set; }
    public virtual List<EftTransaction> EftTransactions { get; set; }
}