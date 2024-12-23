using AutoMapper;
using EstadoCuenta.WEB.Models;
using EstadoCuenta.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstadoCuenta.WEB.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IMapper _mapper;


        public UsuariosController(IApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
           
            var usersDto = await _apiService.ConsumirApi<UsuarioVM>("api/Usuarios");
       
            return View(usersDto.Data);
        }

    }
}

