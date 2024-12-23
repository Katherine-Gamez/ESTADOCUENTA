using System;
using AutoMapper;
using EstadoCuenta.INFRASTRUCTURE.Data;
using EstadoCuenta.WEB.Models;
using EstadoCuenta.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstadoCuenta.WEB.Controllers
{
    public class MovimientosController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IMapper _mapper;


        public MovimientosController(IApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Pagos(MovimientoVM movimientoVM)
        {
            var result = await _apiService.ConsumirApi<UsuarioVM>("api/Usuarios");

            return View(result.Data);
        }

        public async Task<IActionResult> Compras(MovimientoVM movimientoVM)
        {
            var result = await _apiService.ConsumirApi<UsuarioVM>("api/Usuarios");

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Movimiento(MovimientoVM movimientoVM)
        {
            var result= await _apiService.ConsumirApi("api/Movimientos/", movimientoVM);
            return Ok(); 
        }
    }
}