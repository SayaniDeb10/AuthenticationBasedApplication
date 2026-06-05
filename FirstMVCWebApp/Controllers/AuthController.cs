using FirstMVCWebApp.Data;
using FirstMVCWebApp.Dto;
using FirstMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCWebApp.Controllers
{
    public class AuthController(AppDbContext _context) : Controller//MVC controller, if here will ControllerBase then it will be Api controller
    {
        //Dependency Injection -> its internal method we can access with this type
        //private readonly AppDbContext _context;
        ////ctor -> controler
        //public AuthController(AppDbContext context)
        //{
        //    _context = context;
        //}
        public IActionResult Login()
        //IActionResult -> returns view, redirect to action, content, json (Its returns 4 types of things)
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> CreateUser(UserDto dto)
        {
            if(dto == null || string.IsNullOrEmpty(dto.Username) 
                || string.IsNullOrEmpty(dto.Email) 
                || string.IsNullOrEmpty(dto.Password))
            {
                ViewBag.ErrorMessage = "Kindly Fill All required Fields";
                return View("Register");
            }
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (existingUser == null)
            {
                var user = new User
                {
                    Email = dto.Email,
                    Password = dto.Password,
                    Username = dto.Username
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                //ViewBag -> Controller to view 
                ViewBag.ErrorMessage = "User with this email already exists.";
                return View("Register");
            }
            //TempData -> Controller to controller // action to action
            TempData["SuccessMessage"] = "User Created Successfully. Please Login With Your Credential.";
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> LoginUser(UserDto dto)
        {
            if(dto == null || string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
            {
                ViewBag.ErrorMessage = "Kindly Fill All The Details.";
                return View("Login"); 
            }
            var isUserExists = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (isUserExists == null) {
                ViewBag.ErrorMessage = "User With this Credential Does Not Exist.";
                return View("Login");
            }
            else
            {
                if (isUserExists.Password == dto.Password)
                {
                    //ViewBag.ErrorMessage = "Login Successfully.";
                    return RedirectToAction ("Index", "Dashboard");
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect Password.";
                    return View("Login");
                }
            }
        }
    }
}
