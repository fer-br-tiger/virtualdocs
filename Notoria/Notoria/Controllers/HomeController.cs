using Microsoft.AspNetCore.Mvc;
using Notoria.Models;
using Notoria.Responses;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Transbank.Webpay.WebpayPlus;
using Transbank.Common;
using Transbank.Webpay.Common;
using Rotativa.AspNetCore;

namespace Notoria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string URL = "http://localhost:3004";
        private const string API_FEDOK = "https://integracion.fedok.cl:455/fedokApiServices";
        private HttpClient httpClient;
        private HttpRequestMessage request;
        private Transaction tx;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger= logger;
            httpClient = new();
            request = new();
            tx = new Transaction(new Options(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY, WebpayIntegrationType.Test));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login user)
        {
            // var json = await httpClient.GetStringAsync(URL + "/login");

            int stock = 30;
            if (!ModelState.IsValid)
                return View();
            else
            {
                var rta = await httpClient.PostAsJsonAsync<Login>(URL + "/login", user);
                ResponseLogin? result = rta.Content.ReadFromJsonAsync<ResponseLogin>().Result;
                if (!result.Ok)
                    return View();
                else if (stock == 0) {
                    return RedirectToAction("CompraContratos");
                } else
                    return RedirectToAction("Dashboard");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard(string token_ws)
        {
            string countUser = await httpClient.GetStringAsync(URL + "/countUser");
            ViewData["CountUser"] = countUser;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Contratos()
        {
            var resp = await httpClient.GetStringAsync(URL + "/agreements");
            IList<Contrato>? contratos = new List<Contrato>();
            contratos = JsonConvert.DeserializeObject<IList<Contrato>>(resp);
            
            return View(contratos);
        }

        public IActionResult Empresa()
        {
            return View();
        }

        public IActionResult Usuario()
        {
            return View();
        }

        public IActionResult Invitado()
        {
            return View();
        }

        public IActionResult Calculadora()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Firma()
        {
            UserFedok userFedok = new UserFedok();

            userFedok.rut = "15400758-k";
            userFedok.name = "Jenny";
            userFedok.native_surname = "Rodriguez";
            userFedok.surname = "Rojas";
            userFedok.email = "jencarfi_249@hotmail.com";
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiamF2aWVyc290b2FudGlodWFsQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiOTBiMDBmZjYtMjYxYS00NzI5LThjNWUtOTNjOTBkNDgxZmY0IiwibmJmIjoiMTY2Njc5OTM3OSIsImV4cCI6IjE2NjY4ODU3NzkifQ.CRama6zB-PtF-3rm0LvNINZOceA6N0QMkyqMpSxehic");
            request.Content = JsonContent.Create(userFedok);
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(API_FEDOK + "/users/create_user");
            var response = await httpClient.SendAsync(request);
            var txt = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine(txt);
            return View();
        }

        public IActionResult CompraContratos()
        {
            return View();
        }

        public IActionResult CrearTransaccion(int cantTrans)
        {
            var tokenAndURL = tx.Create("1", "virtual-1", cantTrans, "https://localhost:7153/Home/Dashboard");
            ViewData["url"] = tokenAndURL.Url;
            ViewData["token_ws"] = tokenAndURL.Token;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}