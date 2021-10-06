using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _08312021_Empite_Co_Solution.Models
{
    public class ProductDTOs
    {
        [Key]
        public int ItemCode { get; set; }

        [Required(ErrorMessage = "This is Mandatory")]
        [MaxLength(15)]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "please eneter barcode")]
        public string UnitofMeasure { get; set; }

        [Required(ErrorMessage = "required")]
        public string UnitPrice { get; set; }


        [Required(ErrorMessage = "required")]
        public int SupplierCode { get; set; }

        // string status { get; set; }
    }

 
}
