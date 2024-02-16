using Cards.Business.Entity.CardEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Business.Service.IService
{
    public interface ICardService
    {
        CreateCardResponseBE CreateCard(CreateCardBE createCard);
        List<SearchCardRespondBE> searchCard(SearchCardBE searchCardBE);
        List<SingleCardRetrievalRespondBE> singleCardRetrieval (SingleCardRetrievalBE singleCardRetrievalBE);
        CardUpdateResponsedBE CardUpdate  (CardUpdateBE cardUpdateBE);
        CardDeletionBEResponsedBE CardDeletion(CardDeletionBE cardDeletionBE);
    }
}
