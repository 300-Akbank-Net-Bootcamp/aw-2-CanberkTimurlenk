using System.ComponentModel.DataAnnotations.Schema;
using Vb.Base.Entity;

namespace Vb.Data.Entity;

[Table("Customer", Schema = "dbo")]
public class Customer : BaseEntity
{
    public string IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CustomerNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime LastActivityDate { get; set; }

    public virtual List<Address> Addresses { get; set; }
    public virtual List<Contact> Contacts { get; set; }
    public virtual List<Account> Accounts { get; set; }
}