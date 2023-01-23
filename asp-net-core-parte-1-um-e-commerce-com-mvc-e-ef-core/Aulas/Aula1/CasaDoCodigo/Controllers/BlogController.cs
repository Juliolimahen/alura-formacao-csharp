using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CasaDoCodigo.Controllers
{
    public class BlogController : Controller
    {

        private IConfiguration _configuration;

        public BlogController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public IActionResult Usuarios()
        {
            // Configuração usando a string de chave
            ViewData["SecurityLanguage"] = _configuration["Security:Language"];

            // Configuração usando método GetSection

            ViewData["SecuritySuperUserLogin"] =
            _configuration.GetSection("Security").GetSection("SuperUser").GetSection("Login");

            // Configuração usando GetSection e string de chave ao mesmo tempo
            ViewData["SecuritySuperUserEmail"] =
                _configuration.GetSection("Security")["SuperUser:Email"];

            // Configuração usando GetSection e string de chave ao mesmo tempo
            ViewData["SecuritySuperUserShowEmail"] =
                _configuration.GetSection("Security")["SuperUser:ShowEmail"];

            return View();
        }
    }
}
