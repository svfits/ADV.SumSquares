using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADV.Model.EF
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Имя")]
        public string UserName { get; set; }

        [Display(Name = "Возраст")]
        public int Age { get; set; }
    }    
}