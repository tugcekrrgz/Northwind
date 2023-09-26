using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.API.DTOs;
using Northwind.API.Helpers;
using Northwind.API.Repositories;
using Northwind.API.Services;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public CardController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        [Route("getitems")]
        public IActionResult GetItems()
        {
            var cardSession = SessionHelper.GetProductFromJson<CardService>(HttpContext.Session, "sepet");
            if(cardSession == null)
            {
                return NotFound("Sepetiniz Boş!");
            }
            else
            {
                return Ok(cardSession.MyCard.Values.ToList());
            }
        }



        [HttpGet]
        [Route("addtocard/{id}")]
        public IActionResult AddToCard(int id) 
        {
            //CardService cardService= SessionHelper.GetProductFromJson<CardService>(HttpContext.Session, "sepet") == null? new CardService() : SessionHelper.GetProductFromJson<CardService>(HttpContext.Session, "sepet");

            CardService cardService;

            if (SessionHelper.GetProductFromJson<CardService>(HttpContext.Session, "sepet") == null)
            {
                cardService = new CardService();
            }
            else
            {
                cardService = SessionHelper.GetProductFromJson<CardService>(HttpContext.Session, "sepet");
            }
            //İkisi de aynı kod.

            var product = _productRepository.GetAllProducts().FirstOrDefault(x => x.ProductId == id);

            if(product == null)
            {
                return NotFound("Ürün bulunamadı!");
            }
            else
            {
                //AutoMapper araştır.
                CardDTO cardDTO = new CardDTO
                {
                    Id=product.ProductId,
                    ProductName=product.ProductName,
                    UnitPrice=product.UnitPrice
                };

                cardService.AddItem(cardDTO);
                SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cardService);

                return Ok(cardDTO);
            }
        }
    }
}
