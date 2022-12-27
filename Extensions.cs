using RestService.Dtos;
using RestService.Entities;

namespace RestService
{
    public static class Exstention
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto 
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}