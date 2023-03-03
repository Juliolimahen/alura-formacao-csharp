using RestauranteService.Dtos;
using System.Text;
using System.Text.Json;

namespace RestauranteService.ItemServiceHttpClient
{
    public class ItemServiceHttpClient : IItemServiceHttpClient
    {
        private readonly HttpClient _client;

        public ItemServiceHttpClient(HttpClient client)
        {
            _client = client;
        }

        public void EnviaRestauranteParaItemService(RestauranteReadDto
            restauranteReadDto)
        {
            var conteudoHttp = new StringContent(
                JsonSerializer.Serialize(restauranteReadDto),
                Encoding.UTF8,
                "application/json"
                );
        }
    }
}
