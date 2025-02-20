﻿using BookShop.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.ViewModels
{
    //Register with View(Website)
    public class RegisterViewModel:RegisterBaseViewModel /*GoogleReCaptchaModelBase*/
    {
        [GoogleRecaptchaValidationAttributes]
        [BindProperty(Name = "g-recaptcha-response")]
        public string GoogleRecaptchaResponse { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور")]
        [Compare("Password", ErrorMessage = "کلمه عبور وارد شده با تکرار کلمه عبور مطابقت ندارد.")]
        public string ConfirmPassword { get; set; }
    }

    //Register with API(Application)
    public class RegisterBaseViewModel
    {
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [EmailAddress(ErrorMessage = "ایمیل شما نامعتبر است.")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [StringLength(100, ErrorMessage = "{0} باید دارای حداقل {2} کاراکتر و حداکثر دارای {1} کاراکتر باشد.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "تاریخ تولد")]
        public string BirthDate { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string UserName { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string PhoneNumber { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool PhoneNumberConfirmed { get; set; }
    }

    public class SingInViewModel : SignInBaseViewModel
    {
        [Display(Name ="مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است")]
        [StringLength(4,ErrorMessage ="کد امنیتی باید دارای 4 کاراگتر باشد")]
        [Display(Name = "کد امنیتی")]
        public string CaptchaCode { get; set; }
    }

    public class SignInBaseViewModel
    {
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }
    }

    public class ForgetPasswordViewModel
    {
        [Display(Name ="ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده نامعتبر است")]
        [Required(ErrorMessage ="وارد نمودن {0} الزامی است")]
        public string Email { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [EmailAddress(ErrorMessage = "ایمیل شما نامعتبر است.")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [StringLength(100, ErrorMessage = "{0} باید دارای حداقل {2} کاراکتر و حداکثر دارای {1} کاراکتر باشد.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور جدید")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور جدید")]
        [Compare("Password", ErrorMessage = "تکرار کلمه عبور با کلمه عبور وارد شده مطابقت ندارد.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "کد اعتبارسنجی")]
        public string Code { get; set; }

        [Display(Name = "مرا به خاطر بسپار؟")]
        public bool RememberBrowser { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [DataType(DataType.Password)]
        [Display(Name ="کلمه عبور فعلی")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [StringLength(100, ErrorMessage = "{0} باید دارای حداقل {2} کاراکتر و حداکثر دارای {1} کاراکتر باشد.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور جدید")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور")]
        [Compare("NewPassword", ErrorMessage = "کلمه عبور وارد شده با تکرار کلمه عبور مطابقت ندارد.")]
        public string ConfirmPassword { get; set; }

        public UserSidebarViewModel UserSidebar { get; set; }
    }

    public class UserSidebarViewModel
    {
        public string FullName { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? LastVisit { get; set; }
        public string Image { get; set; }
    }
    public class LoginWith2faViewModel
    {
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [StringLength(7, ErrorMessage = "کد اعتبارسنجی با حداقل دارای {2} کاراکتر و حداکثر دارای {1} کاراکتر باشد.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "کد اعتبارسنجی")]
        public string TwoFactorCode { get; set; }

        public bool RememberMe { get; set; }

        [Display(Name = "مرا به خاطر بسپار؟")]
        public bool RememberMachine { get; set; }
    }
    public class LoginWithRecoveryCodeViewModel
    {
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [DataType(DataType.Text)]
        [Display(Name = "کد بازیابی")]
        public string RecoveryCode { get; set; }
    }
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Display(Name = "استان")]
        public int ProvinceID { get; set; }

        [Display(Name = "شهر")]
        public int CityID { get; set; }
        public UserSidebarViewModel UserSidebar { get; set; }
    }
}
