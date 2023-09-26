using Northwind.API.DTOs;
using Northwind.API.Repositories;

namespace Northwind.API.Services
{
    public class CardService : ICardRepository
    {
        public Dictionary<int, CardDTO> MyCard = new Dictionary<int, CardDTO>();
        public void AddItem(CardDTO cardDTO)
        {
            if (MyCard.ContainsKey(cardDTO.Id))
            {
                MyCard[cardDTO.Id].Quantity += 1;
                return;
            }
            MyCard.Add(cardDTO.Id, cardDTO);
        }
    }
}
