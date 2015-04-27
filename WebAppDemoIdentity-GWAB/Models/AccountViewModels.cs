using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentitySample.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O email é obrigatório.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O email informado não é um email válido")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Tipo de Autenticação é obrigatória.")]
        public string Provider { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O código é obrigatório.")]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Relembrar este browser?")]
        public bool RememberBrowser { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O email é obrigatório.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O email informado não é um email válido")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O email é obrigatório.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O email informado não é um email válido")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é um email válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "A senha e confirmação dA senha não estão iguais.")]
        public string ConfirmPassword { get; set; }

        //Apresentação de propriedade customizada no ApplicationUser
        //[Required(AllowEmptyStrings = false, ErrorMessage = "O endereço de cobrança é obrigatório.")]
        //[Display(Name = "Endereço de Cobrança")]
        //[StringLength(150, ErrorMessage = "O Endereço de cobrança deve ter no máximo 150 caracteres.")]
        //public string EnderecoCobranca { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é um email válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "A senha e confirmação dA senha não estão iguais.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é um email válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}