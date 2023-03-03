using RestauranteService.Dtos;

namespace RestauranteService.ItemServiceHttpClient
{
    public interface IItemServiceHttpClient
    {
        void EnviaRestauranteParaItemService(RestauranteReadDto restauranteReadDto);
    }
}