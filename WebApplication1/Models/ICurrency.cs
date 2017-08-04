using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public interface ICurrency
    {
        Guid Id { get; set; }

        [Display(Name = "Имя базовой валюты")]
        [Required(ErrorMessage = "Поле имя базовой валюты обязательно для заполнения")]
        string NameFrom { get; set; }

        [Display(Name = "Имя валюты назначения")]
        [Required(ErrorMessage = "Поле имя валюты назначения обязательно для заполнения")]
        string NameTo { get; set; }

        [Display(Name = "Код базовой валюты")]
        [Required(ErrorMessage = "Поле код базовой валюты обязательно для заполнения")]
        string CodeFrom { get; set; }

        [Display(Name = "Код валюты назначения")]
        [Required(ErrorMessage = "Поле код валюты назначения обязательно для заполнения")]
        string CodeTo { get; set; }
    }
}