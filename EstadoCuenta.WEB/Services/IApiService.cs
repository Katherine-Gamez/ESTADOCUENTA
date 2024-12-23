using EstadoCuenta.INFRASTRUCTURE.Data;
using EstadoCuenta.WEB.Models;

namespace EstadoCuenta.WEB.Services
{
    public interface IApiService
    {
        Task<BaseResponse<IEnumerable<T>>> ConsumirApi<T>(string endpoint);
        Task<BaseResponse<TResponse>> ConsumirApi<TResponse>(string endpoint, int parametro, HttpMethod metodo);
        Task<BaseResponse<TResponse>> ConsumirApi<TResponse, TRequest>(string endpoint, TRequest objeto, HttpMethod metodo);
        Task<BaseResponse<IEnumerable<TResponse>>> ConsumirApiI<TResponse>(string endpoint, int parametro, HttpMethod metodo);
        Task<bool> ConsumirApi(string url, MovimientoVM data);
    }

}