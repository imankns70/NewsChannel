﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace NewsChannel.ViewModel.Video
{
    public class VideoViewModel
    {
        [JsonProperty("Id")]
        public string VideoId { get; set; }

        [JsonProperty("ردیف")]
        public int Row { get; set; }

        [JsonProperty("عنوان ویدیو"),Display(Name ="عنوان ویدیو")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string Title { get; set; }

        [Display(Name = "آدرس ویدیو"),Url(ErrorMessage ="آدرس وارد شده نا معتبر است.")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string Url { get; set; }

        [Display(Name = "پوستر ویدیو"),JsonIgnore]
        [Required(ErrorMessage = "انتخاب {0} الزامی است.")]
        public IFormFile PosterFile { get; set; }
        
        public string Poster { get; set; }

        [JsonIgnore]
        public DateTime? PublishDateTime { get; set; }

        [JsonProperty("تاریخ انتشار")]
        public string PersianPublishDateTime { get; set; }
    }
}
