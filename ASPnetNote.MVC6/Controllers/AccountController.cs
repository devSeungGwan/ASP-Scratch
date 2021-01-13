using ASPnetNote.MVC6.DataContext;
using ASPnetNote.MVC6.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPnetNote.MVC6.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            // ID, Password: 필수
            if (ModelState.IsValid)
            {
                using (var db = new ASPnetNoteDbContext())
                {
                    // Linq - 메서드 체어닝(Method Chaining)
                    // => : A go to B
                    //var user = db.Users
                    //    .FirstOrDefault(u => u.UserId == model.UserId && u.UserPassword == model.UserPassword);
                    
                    var user = db.Users
                        .FirstOrDefault(
                            u => u.UserId.Equals(model.UserId) &&
                            u.UserPassword.Equals(model.UserPassword)
                        );
                }
            }


            return View(model);
        }


        /// <summary>
        /// 회원 가입
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Java try(sqlSession){} catch(){}
                // C#
                using (var db = new ASPnetNoteDbContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
