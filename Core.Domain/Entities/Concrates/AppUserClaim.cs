using Microsoft.AspNetCore.Identity;
using Domain.Enums;

namespace Domain.Entities.Concrates
{
    public class AppUserClaim : IdentityUserClaim<int>
    {
        public AppUserClaim()
        {
            InsertedDate = DateTime.Now;
            Status = Status.Inserted;
        }
        public int Id { get; set; }
        public DateTime? InsertedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
