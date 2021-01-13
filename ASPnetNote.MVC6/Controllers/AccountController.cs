using ASPnetNote.MVC6.DataContext;
using ASPnetNote.MVC6.Models;
using ASPnetNote.MVC6.ViewModel;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // ID, Password: 필수
            if (ModelState.IsValid)
            {
                using (var db = new ASPnetNoteDbContext())
                {
                    // Linq - 메서드 체어닝(Method Chaining)
                    // => : A go to B

                    // 해당 방식으로 작성 시 메모리 누수가 발생하여 성능 상 이득을 가져가기 힘듬.
                    //var user = db.Users
                    //    .FirstOrDefault(u => u.UserId == model.UserId && u.UserPassword == model.UserPassword);
                    
                    // Equals 메소드를 사용하여 내용 비교 시 메모리 누수가 발생하지 않도록 한다.
                    var user = db.Users.FirstOrDefault(
                        u => u.UserId.Equals(model.UserId) &&
                        u.UserPassword.Equals(model.UserPassword)
                        );

                    if (user != null)
                    {
                        // 로그인에 성공했을 때
                        //HttpContext.Session.SetInt32(key, value);
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);
                        return RedirectToAction("LoginSuccess", "Home");
                    }
                }

                // 로그인에 실패했을 때
                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");

            }


            return View(model);
        }

        
        
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");

            //HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
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
