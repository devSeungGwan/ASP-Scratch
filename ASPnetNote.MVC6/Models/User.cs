using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPnetNote.MVC6.Models
{
    public class User
    {
        /// <summary>
        /// 사용자 번호
        /// </summary>
        [Key] // PK 설정
        public int UserNo { get; set; }

        /// <summary>
        /// 사용자 이름
        /// </summary>
        [Required] // Not Null 설정
        public string UserName { get; set; }

        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required] // Not Null 설정
        public string UserId { get; set; }

        /// <summary>
        /// 사용자 비밀번호
        /// </summary>
        [Required] // Not Null 설정
        public string UserPassword { get; set; }
    }
}
