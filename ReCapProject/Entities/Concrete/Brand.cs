using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand:IBrand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
