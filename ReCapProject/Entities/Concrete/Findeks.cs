using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Findeks:IEntity
    {
        public int FindeksId { get; set; }
        public int CustomerId { get; set; }
        public string NationalIdentity { get; set; }
        public int FindeksScore { get; set; }
    }
}
