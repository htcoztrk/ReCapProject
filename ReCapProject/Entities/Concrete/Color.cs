using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Color:IColor
    {
        
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
