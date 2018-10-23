using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public class Index
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Индекс")]
        [Required(ErrorMessage = "Заполните поле индекс!")]
        [RegularExpression(@"\-?\d+(\d{0,})?", ErrorMessage = "Некоректный ввод индекса!")]
        [DataType(DataType.Text)]
        public string Name_Index { get; set; }
    }
}