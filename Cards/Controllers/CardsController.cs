using Cards.Business.Entity.CardEntity;
using Cards.Business.Entity.UserEntity;
using Cards.Business.Service.DBAccess;
using Cards.Business.Service.IService;
using Cards.Business.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cards.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private ICardService _ICardService;
        public CardsController(ICardService cardService)
        {
            _ICardService = cardService;
        }


        [Route("CreateCard")]
        [HttpPost]
        public async Task<ActionResult<CreateCardResponseBE>> CreateCard(CreateCardBE createCard)
        {
            var UserID = HttpContext.Session.GetString("UserID");
            if(UserID != null)
            {

                createCard.Id = int.Parse(UserID);
            }
            if (createCard.Status == "")
            {

                createCard.Status = "To Do";
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            try
            {
                CreateCardResponseBE createCardResponseBE = new CreateCardResponseBE();
                createCardResponseBE = _ICardService.CreateCard(createCard);
                
                return createCardResponseBE;

            }
            catch (Exception e)
            {
                //LogBC.EntryLog("LoginController",e.Message);
                //error for saving 
                return null;
            }
        }

        [Route("SearchCard")]
        [HttpPost]
        public List<SearchCardRespondBE> SearchCard(SearchCardBE searchCardBE)
        {

            var UserID = HttpContext.Session.GetString("UserID");
            if (UserID != null)
            {

                searchCardBE.UserID = int.Parse(UserID);
            }

            try
            {
                List<SearchCardRespondBE> searchCardRespondBE = new List<SearchCardRespondBE>();
                searchCardRespondBE = _ICardService.searchCard(searchCardBE);

                return searchCardRespondBE;

            }
            catch (Exception e)
            {
                //LogBC.EntryLog("LoginController",e.Message);
                //error for saving 
                return null;
            }
        }

        //Single Card Retrieval:
        [Route("SingleCardRetrieval")]
        [HttpPost]
        public List<SingleCardRetrievalRespondBE> SingleCardRetrieval(SingleCardRetrievalBE singleCardRetrievalBE)
        {

            var UserID = HttpContext.Session.GetString("UserID");
            if (UserID != null)
            {

                singleCardRetrievalBE.UserID = int.Parse(UserID);
            }

            try
            {
                List<SingleCardRetrievalRespondBE> singleCardRetrievalRespondBEs = new List<SingleCardRetrievalRespondBE>();
                singleCardRetrievalRespondBEs = _ICardService.singleCardRetrieval(singleCardRetrievalBE);

                return singleCardRetrievalRespondBEs;

            }
            catch (Exception e)
            {
                //LogBC.EntryLog("LoginController",e.Message);
                //error for saving 
                return null;
            }
        }
        //CardUpdate
        [Route("CardUpdate")]
        [HttpPost]
        public CardUpdateResponsedBE CardUpdate (CardUpdateBE cardUpdateBE)
        {

            var UserID = HttpContext.Session.GetString("UserID");
            if (UserID != null)
            {

                cardUpdateBE.UserID = int.Parse(UserID);
            }

            try
            {
                CardUpdateResponsedBE cardUpdateResponsedBE = new CardUpdateResponsedBE();
                cardUpdateResponsedBE = _ICardService.CardUpdate(cardUpdateBE);

                return cardUpdateResponsedBE;

            }
            catch (Exception e)
            {
                //LogBC.EntryLog("LoginController",e.Message);
                //error for saving 
                return null;
            }
        }
        //CardDeletion
        [Route("CardDeletion")]
        [HttpPost]
        public CardDeletionBEResponsedBE CardDeletion(CardDeletionBE cardDeletionBE)
        {

            var UserID = HttpContext.Session.GetString("UserID");
            if (UserID != null)
            {

                cardDeletionBE.UserID = int.Parse(UserID);
            }

            try
            {
                CardDeletionBEResponsedBE  cardDeletionBEResponsedBE = new CardDeletionBEResponsedBE();
                cardDeletionBEResponsedBE = _ICardService.CardDeletion(cardDeletionBE);

                return cardDeletionBEResponsedBE;

            }
            catch (Exception e)
            {
                //LogBC.EntryLog("LoginController",e.Message);
                //error for saving 
                return null;
            }
        }
    }
}
