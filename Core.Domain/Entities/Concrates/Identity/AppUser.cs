using Microsoft.AspNetCore.Identity;
using Domain.Enums;
using Domain.Entities.Abstarct;

namespace Domain.Entities.Concrates
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public AppUser()
        {
            InsertedDate = DateTime.Now;
            Status = Status.Inserted;
        }
        public DateTime? InsertedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public Status Status { get; set; }

        //Relational Properties
        public  ICollection<AppUserRole> UserRoles { get; set; }
    }
}
