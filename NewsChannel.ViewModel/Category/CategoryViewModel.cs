﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace NewsChannel.ViewModel.Category
{
    public class CategoryViewModel
    {
        //[JsonProperty("Id")]
        public int? CategoryId { get; set; }

        [Display(Name ="عنوان دسته بندی"), JsonProperty("دسته")]
        [Required(ErrorMessage ="وارد نمودن {0} الزامی است.")]
        public string CategoryName { get; set; }

        [JsonProperty("ردیف")]
        public int Row { get; set; }

        [Display(Name ="دسته پدر"),JsonProperty("دسته پدر")]
        public string ParentCategoryName { get; set; }


        [Display(Name = "آدرس"),JsonProperty("آدرس")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string Url { get; set; }
    }
}
