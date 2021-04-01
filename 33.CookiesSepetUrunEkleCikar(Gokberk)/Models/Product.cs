using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace _33.CookiesSepetUrunEkleCikar_Gokberk_.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public decimal Price { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        //https://stackoverflow.com/questions/7397207/json-net-error-self-referencing-loop-detected-for-type
        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}