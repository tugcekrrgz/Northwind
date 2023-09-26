using Northwind.API.DTOs;

namespace Northwind.API.Repositories
{
    public interface ICardRepository
    {
        public void AddItem(CardDTO cardDTO);
    }
}
