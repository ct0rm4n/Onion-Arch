using Domain.Entities.Abstarct;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Concrates
{
    public class AppUserRole : IdentityUserRole<int>, IEntity
    {
        public AppUserRole()
        {
            InsertedDate = DateTime.Now;
            Status = Status.Inserted;
        }
        public DateTime? InsertedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public Status Status { get; set; }

        //Relational Properties
        public  AppUser User { get; set; }
        public  AppRole Role { get; set; }
    }
}


