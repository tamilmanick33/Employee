using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee.Models
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
       
        public string ContactNo { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage ="Please select a date")]
        [Display(Name ="Selected Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}",ApplyFormatInEditMode = true)]
        public string JoiningDate { get; set; }
        public string DEPT { get; set; }
        public string City { get; set; }
        public string RollName { get; set; }
        public string ProjectName { get; set; }
      
    }
}