using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BVL.Models
{
    public class EmailFormModel
    {
        //[Display(Name = "FullName", ResourceType = typeof(RHome))]
        //[Required(ErrorMessageResourceType = typeof(RHome), ErrorMessageResourceName = "FullNameRequired")]
        //public string FullName
        //{
        //    get;
        //    set;
        //}  

        [Required(ErrorMessage = "Please Enter Name")]
        //[Display(Name = "Name")]
        public string FromName { get; set; }

       // [Required, EmailAddress]
        [Required(ErrorMessage = "Please Enter Email Address")]
       // [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", 
        ErrorMessage = "Please Enter Correct Email Address")]
        public string FromEmail { get; set; }

        //[Required]
        [Required(ErrorMessage = "Please Enter Phone No")]
        //[Display(Name = "Mobile")]
        [StringLength(10, ErrorMessage = "The Phone must contains 10 characters", MinimumLength = 10)] 
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please Enter yuor message")]
        public string Message { get; set; }
        }
     
        
    }
