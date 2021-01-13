﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASPnetNote.MVC6.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "사용자 ID를 입력하세요")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "사용자 비밀번호를 입력하세요.")]
        public string UserPassword { get; set; }

    }
}
