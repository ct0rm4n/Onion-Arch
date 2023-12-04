using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Abstracts;

namespace ViewModels.ProductFeature
{
    public class ProductFeatureSaveVM : SaveVM,IBaseVM
    {
        public DateTime RealeseDate { get; set; }
        public string MadeIn { get; set; }
    }
}
