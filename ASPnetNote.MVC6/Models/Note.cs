using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPnetNote.MVC6.Models
{
    public class Note
    {
        /// <summary>
        /// 게시물 번호
        /// </summary>
        [Key]
        public int NoteNo { get; set; }

        /// <summary>
        /// 게시물 제목
        /// </summary>
        [Required]
        public string NoteTitle { get; set; }

        /// <summary>
        /// 게시물 내용
        /// </summary>
        [Required]
        public string NoteContents { get; set; }

        /// <summary>
        /// 작성자 번호
        /// </summary>
        [Required]
        public int UserNo { get; set; }
        

        [ForeignKey("UserNo")] // 사용자 번호가 외래키임을 확인
        public virtual User User { get; set; }

        // 레이지 로딩을 위해 Virtal 사용

    }
}
