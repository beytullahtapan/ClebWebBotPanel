﻿using System.ComponentModel.DataAnnotations;

namespace PanelClebWeb.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adını Giriniz!")]
        public string UserName { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifreyi Giriniz!")]
        public string Password { get; set; }
    }
}
