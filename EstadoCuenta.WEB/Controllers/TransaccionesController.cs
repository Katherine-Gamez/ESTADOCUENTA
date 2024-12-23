using AutoMapper;
using EstadoCuenta.WEB.Models;
using EstadoCuenta.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstadoCuenta.WEB.Controllers
{
    public class TransaccionesController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IMapper _mapper;


        public TransaccionesController(IApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Transaccion(int id)
        {
            var cuenta = await _apiService.ConsumirApiI<TransaccionesVM>("api/Transacciones/", id, HttpMethod.Get);

            return View(cuenta.Data);
        }
    }
}