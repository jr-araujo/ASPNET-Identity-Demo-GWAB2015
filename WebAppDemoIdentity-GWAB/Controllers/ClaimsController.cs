using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;
using WebAppDemoIdentity_GWAB.Filters;

namespace WebAppDemoIdentity_GWAB.Controllers
{
    [ClaimsAuthorize("AdmClaims", "True")]
    public class ClaimsController : Controller
    {
        private ApplicationDbContext _dbContext = null;

        private ApplicationDbContext DbContext
        {
            get { return _dbContext ?? HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>(); }
            set { _dbContext = value; }
        }

        private ApplicationUserManager _userManager = null;

        private ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            set { _userManager = value; }
        }

        private ApplicationUser CurrentUser
        {
            get
            {
                Task<ApplicationUser> user = UserManager.FindByEmailAsync(HttpContext.User.Identity.Name);

                return user.Result;
            }
        }

        public ClaimsController()
        {
            
        }

        public ClaimsController(ApplicationUserManager userManager, ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            UserManager = userManager;
        }

        // GET: Claims
        public async Task<ActionResult> Index()
        {
            var claims = await UserManager.GetClaimsAsync(CurrentUser.Id);

            return View(claims);
        }
    }
}