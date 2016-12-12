using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookATableMVC.ViewModels.Restaurants
{
    public class RestaurantAddEditViewModel:BaseByIdViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)\[\]]*$")]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(1, Int32.MaxValue)]
        public int Capacity { get; set; }
        //[Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? OpenHour { get; set; }
        //[Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? CloseHour { get; set; }

        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        
    }
}