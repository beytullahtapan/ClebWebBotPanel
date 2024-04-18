using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Expenditure
    {
        [Key]
        public int Id { get; set; }
        public string ExpenditureName { get; set; }
        public double ExpenditureAmount { get; set; }
        public double SafeBoxTotal { get; set; }

        public virtual SafeBox SafeBox { get; set; }
        public int SafeBoxId { get; set; }

        

    }
}
