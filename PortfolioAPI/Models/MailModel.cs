using System.ComponentModel.DataAnnotations;

namespace portfolio.Models{
    public class MailModel{
        [Required]
        public string Name{get;set;}
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email{get;set;}
        public string Phone{get;set;}
        [Required]
        public string Message{get;set;
        }
    }
}