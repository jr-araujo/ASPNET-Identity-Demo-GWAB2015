using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using IdentitySample.Models;
using Owin;
using System;
using Microsoft.Owin.Security.Facebook;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySample
{
    public partial class Startup
    {

        //private const string XmlSchemaString = "http://www.w3.org/2001/XMLSchema#string";

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and role manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(1),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "{SEU ID CLIENTE FORNECIDO PELA MICROSOFOT}",
            //    clientSecret: "{SUA CHAVE SECRETA FORNECIDA PELA MICROSOFT}");

            //app.UseTwitterAuthentication(
            //   consumerKey: "{SEU ID CLIENTE FORNECIDO PELO TWITTER}",
            //   consumerSecret: "{SUA CHAVE SECRETA FORNECIDA PELO TWITTER}");

            var fao = new FacebookAuthenticationOptions
            {
                AppId = "[SEU_APP_ID]",
                AppSecret = "[SEU_APP_SECRET]",

                // Apresentação de configuração para Login Externo - Facebook
                //Provider = new FacebookAuthenticationProvider
                //{
                //    OnAuthenticated = async facebookContext =>
                //    {
                //        facebookContext.Identity.AddClaim(new Claim("FacebookAccessToken", facebookContext.AccessToken));

                //        foreach (var profileItem in facebookContext.User)
                //        {
                //            var claimType = string.Format("urn:facebook:{0}", profileItem.Key);
                //            string claimValue = profileItem.Value.ToString();
                //            if (!facebookContext.Identity.HasClaim(claimType, claimValue))
                //                facebookContext.Identity.AddClaim(new System.Security.Claims.Claim(claimType, claimValue, "Facebook"));
                //        }
                //    }
                //},

                // Apresentação de configuração para Login Externo - Facebook
                // Isso garante que todas as vezes que a aplicação utilizar o Facebook como fator de autenticação
                // as informações do usuários serão trazidas do cookie do facebook de forma externa, para dentro da 
                // aplicação cliente.
                //SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie
            };

            // Apresentação de configuração para Login Externo - Facebook
            //fao.Scope.Add("email");
            //fao.Scope.Add("publish_actions");
            //fao.Scope.Add("public_profile");
            
            app.UseFacebookAuthentication(fao); 
            
            //app.UseGoogleAuthentication(
            //    clientId: "{SEU ID CLIENTE FORNECIDO PELA GOOGLE}",
            //    clientSecret: "{SUA CHAVE SECRETA FORNECIDA PELA GOOGLE}");
        }
    }
}