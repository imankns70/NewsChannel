using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace NewsChannel.ViewModel.Tag
{
    public class TagViewModel
    {
        [JsonProperty("Id")]
        public int? TagId { get; set; }

        [JsonProperty("ردیف")]
        public int Row { get; set; }

        [JsonProperty("برچسب"),Display(Name = "عنوان برچسب")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string TagName { get; set; }
    }
}
