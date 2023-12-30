using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Abstracts;
using ViewModels.Product;
using Wrappers;

namespace ViewModels.Response
{
    public abstract class ResultVM<T> where T : IBaseVM
    {
        public Result<List<T>> Result { get; set; }
    }
}