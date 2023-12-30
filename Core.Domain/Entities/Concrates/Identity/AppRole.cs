
using Domain.Entities.Abstarct;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Concrates
{
    public class AppRole : IdentityRole<int>,IEntity
    {
        public AppRole()
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