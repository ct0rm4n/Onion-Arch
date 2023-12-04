using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Abstracts
{
    public abstract class SaveVM
    {
        public int Id { get; set; }
        public DateTime InsertedDate { get; set; }
    }
}