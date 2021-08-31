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
        public int PID { get; set; }

        [Required(ErrorMessage = "This is Mandatory")]
        [MaxLength(7)]
        public string SKU { get; set; }

        [Required(ErrorMessage = "please eneter barcode")]
        public int Barcode { get; set; }

        [Required(ErrorMessage = "required")]
        public string Name { get; set; }


        [Required(ErrorMessage = "required")]
        public int QTY { get; set; }

        public string status { get; set; }
    }

 
}
