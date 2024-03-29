﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NewsChannel.Common.Attributes;
using NewsChannel.DomainClasses.Business;
using NewsChannel.DomainClasses.Identity;
using Newtonsoft.Json;

namespace NewsChannel.ViewModel.News
{
    public class NewsViewModel
    {
        [JsonProperty("Id")]
        public int? NewsId { get; set; }

        [JsonProperty("ردیف")]
        public int Row { get; set; }

        [JsonProperty("عنوان خبر"), Display(Name = "عنوان خبر")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string Title { get; set; }

        [JsonProperty("ShortTitle")]
        public string ShortTitle { get; set; }

        [JsonIgnore]
        public bool FuturePublish { get; set; }

        [JsonIgnore]
        public User AuthorInfo { get; set; }
        [JsonIgnore]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است."),Display(Name = "چکیده")] 
        public string Abstract { get; set; }

        [JsonIgnore]
        public DateTime? PublishDateTime { get; set; }

        [Display(Name = "تاریخ انتشار"), JsonProperty("تاریخ انتشار")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string PersianPublishDate { get; set; }

        [Display(Name = "زمان انتشار"),JsonIgnore]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string PersianPublishTime { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }


        [JsonIgnore]
        public int? TagId { get; set; }
        [JsonProperty("نویسنده")]
        public string AuthorName { get; set; }

        [JsonIgnore]
        public string ImageName { get; set; }

        [Required(ErrorMessage = "انتخاب {0} الزامی است.")]
        [JsonIgnore,Display(Name ="تصویر شاخص")]
        public string ImageFile {get;set;}

        [JsonIgnore]
        public bool IsPublish { get; set; }

        [Required(ErrorMessage = "انتخاب {0} الزامی است.")]
        [Display(Name = "نوع خبر"),JsonIgnore()]
        public bool? IsInternal { get; set; }

        [JsonProperty("تگ ها")]
        public string NameOfTags { get; set; }
      

        [JsonProperty("نوع خبر")]
        public string NewsType { get; set; }

        [JsonProperty("بازدید")]
        public int NumberOfVisit { get; set; }

        [JsonProperty("NumberOfLike")]
        public int NumberOfLike { get; set; }

        [JsonProperty("NumberOfDisLike")]
        public int NumberOfDisLike { get; set; }
        [JsonProperty("NumberOfComment")]
        public int NumberOfComment { get; set; }

        [JsonProperty("دسته")]
        public string NameOfCategories { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "آدرس خبر"), JsonProperty("آدرس")]
        [UrlValidate("/", @"\", " ")]
        public string Url { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }


        [JsonProperty("متن خبر")]
        public string Description { get; set; }

        
        [JsonIgnore]
        public int[] CategoryIds { get; set; }

        [JsonIgnore]
        public NewsCategoriesViewModel NewsCategoriesViewModel { get; set; }

        [JsonIgnore]
        public virtual ICollection<NewsCategory> NewsCategories { get; set; }

        [JsonIgnore]
        public virtual ICollection<NewsTag> NewsTags { get; set; }
        [JsonIgnore]
        public virtual List<string> TagNames { get; set; }

        [JsonIgnore]
        public virtual List<int?> TagIds { get; set; }
    }
}
