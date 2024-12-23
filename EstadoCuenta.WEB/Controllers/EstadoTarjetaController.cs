using AutoMapper;
using EstadoCuenta.WEB.Models;
using EstadoCuenta.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstadoCuenta.WEB.Controllers
{
    public class EstadoTarjetaController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IMapper _mapper;


        public EstadoTarjetaController(IApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> EstadoDeCuenta(int id)
        {

            var cuenta = await _apiService.ConsumirApi<EstadoCuentaVM>("api/EstadoTarjeta/", id,HttpMethod.Get);

            return View(cuenta.Data);
        }
    }
}

