using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using EstadoCuenta.INFRASTRUCTURE.Data;
using EstadoCuenta.WEB.Models;

namespace EstadoCuenta.WEB.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ApiService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<T>>> ConsumirApi<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error al llamar a la API: {response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync();

            try
            {
                var baseResponse = JsonSerializer.Deserialize<BaseResponse<IEnumerable<T>>>(
                    content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (baseResponse == null)
                    throw new JsonException("La respuesta de la API no es válida.");

                return baseResponse;
            }
            catch (JsonException ex)
            {
                throw new HttpRequestException($"Error al deserializar JSON: {ex.Message}");
            }
        }

        public async Task<BaseResponse<TResponse>> ConsumirApi<TResponse>(string endpoint, int parametro, HttpMethod metodo)
        {
            endpoint = $"{endpoint}{parametro}";

            var response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error al llamar a la API: {response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync();

            try
            {
                var baseResponse = JsonSerializer.Deserialize<BaseResponse<TResponse>>(
                    content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (baseResponse == null)
                    throw new JsonException("La respuesta de la API no es válida.");

                return baseResponse;
            }
            catch (JsonException ex)
            {
                throw new HttpRequestException($"Error al deserializar JSON: {ex.Message}");
            }
        }

        public async Task<BaseResponse<TResponse>> ConsumirApi<TResponse, TRequest>(string endpoint, TRequest objeto, HttpMethod metodo)
        {
            var request = new HttpRequestMessage(metodo, endpoint);
            if (objeto != null && (metodo == HttpMethod.Post || metodo == HttpMethod.Put))
            {
                var json = JsonSerializer.Serialize(objeto);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error al llamar a la API: {response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync();

            try
            {
                var baseResponse = JsonSerializer.Deserialize<BaseResponse<TResponse>>(
                    content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (baseResponse == null)
                    throw new JsonException("La respuesta de la API no es válida.");

                return baseResponse;
            }
            catch (JsonException ex)
            {
                throw new HttpRequestException($"Error al deserializar JSON: {ex.Message}");
            }
        }

        public async Task<BaseResponse<IEnumerable<TResponse>>> ConsumirApiI<TResponse>(string endpoint, int parametro, HttpMethod metodo)
        {
            endpoint = $"{endpoint}{parametro}";

            var response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error al llamar a la API: {response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync();

            try
            {
                var baseResponse = JsonSerializer.Deserialize<BaseResponse<IEnumerable<TResponse>>>(
                    content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (baseResponse == null)
                    throw new JsonException("La respuesta de la API no es válida.");

                return baseResponse;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al deserializar JSON. Contenido: {content}");
                throw new HttpRequestException($"Error al deserializar JSON: {ex.Message}");
            }
        }


        public async Task<bool> ConsumirApi(string url, MovimientoVM data)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error {response.StatusCode}: {responseContent}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                return false;
            }
        }
    }
}
