using Cards.Business.Entity.CardEntity;
using Cards.Business.Service.IService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.Business.Service.DBAccess;
using Cards.Business.Entity.UserEntity;
using Microsoft.AspNetCore.Http;

namespace Cards.Business.Service.Service
{
    public class CardService : ICardService
    {

        //if you dont want to override conectionstring you can read on appsettin.json section connectionstring
        public string Conns = "Server=DESKTOP-651S2E8\\SQLEXPRESS; Database=Cards; Trusted_Connection=True;";

      

        public CreateCardResponseBE CreateCard(CreateCardBE createCard)
        {
            CreateCardResponseBE createCardResponse = new CreateCardResponseBE();


            try
            {
                using (SqlConnection sql = new SqlConnection(Conns))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_CREATECARD", sql))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", createCard.Id);
                        cmd.Parameters.AddWithValue("@Name", createCard.Name);
                        cmd.Parameters.AddWithValue("@Description", createCard.Description);
                        cmd.Parameters.AddWithValue("@Color", createCard.Color);
                        cmd.Parameters.AddWithValue("@Status", createCard.Status);
                        sql.Open();


                        using (System.Data.IDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                createCardResponse.ResultCode = (int)reader["RESULT"];
                                createCardResponse.Message = reader["DESCRIPTIONS"].ToString();

                                if (createCardResponse.ResultCode == 0)
                                {
                                    createCardResponse.Success = true;
                                }
                                else
                                {
                                    createCardResponse.Success = false;
                                }

                            }
                        }
                    }
                }


                return createCardResponse;
            }
            catch (Exception e)
            {
                LogBC.EntryLog("SP_CREATECARD", e.Message);

                return null;
            }
        }

        public List<SearchCardRespondBE> searchCard(SearchCardBE searchCardBE)
        {
            List<SearchCardRespondBE> ListsearchCardRespondBE = new List<SearchCardRespondBE>();
            SearchCardRespondBE searchCardRespondBE = new SearchCardRespondBE();

            try
            {
                using (SqlConnection sql = new SqlConnection(Conns))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_SEARCHCARD", sql))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", searchCardBE.UserID);
                        cmd.Parameters.AddWithValue("@Name", searchCardBE.Name);
                        cmd.Parameters.AddWithValue("@Color", searchCardBE.Color);
                        cmd.Parameters.AddWithValue("@Status", searchCardBE.Status);
                        cmd.Parameters.AddWithValue("@DateOfCreation", searchCardBE.DateofCreation);
                        cmd.Parameters.AddWithValue("@OrderBy", searchCardBE.OrderBy);
                        sql.Open();

                            var adapter = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                searchCardRespondBE = new SearchCardRespondBE();
                                searchCardRespondBE.CardId = dt.Rows[i]["CardId"].ToString();
                                searchCardRespondBE.Name = dt.Rows[i]["Name"].ToString();
                                searchCardRespondBE.Color = dt.Rows[i]["Color"].ToString();
                                searchCardRespondBE.Status = dt.Rows[i]["Status"].ToString();
                                searchCardRespondBE.DateofCreation = dt.Rows[i]["CreationDate"].ToString();
                                ListsearchCardRespondBE.Add(searchCardRespondBE);
                            }
                        
                    }
                }


                return ListsearchCardRespondBE;
            }
            catch (Exception e)
            {
                // SAVING ERROR IN THE DB
                LogBC.EntryLog("SP_SEARCHCARD", e.Message);

                return null;
            }
        }

        public List<SingleCardRetrievalRespondBE> singleCardRetrieval(SingleCardRetrievalBE singleCardRetrievalBE)
        {
            List<SingleCardRetrievalRespondBE> ListsingleCardRetrievalResponds = new List<SingleCardRetrievalRespondBE>();
            SingleCardRetrievalRespondBE singleCardRetrievalRespondBE = new SingleCardRetrievalRespondBE();

            try
            {
                using (SqlConnection sql = new SqlConnection(Conns))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_SingleCardRetrieval", sql))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", singleCardRetrievalBE.UserID);
                        cmd.Parameters.AddWithValue("@CardID", singleCardRetrievalBE.CardID);
                        sql.Open();

                        var adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            singleCardRetrievalRespondBE = new SingleCardRetrievalRespondBE();
                            singleCardRetrievalRespondBE.CardID = (dt.Rows[i]["CardID"]).ToString();
                            singleCardRetrievalRespondBE.UserID = (dt.Rows[i]["UserID"]).ToString();
                            singleCardRetrievalRespondBE.Name = dt.Rows[i]["Name"].ToString();
                            singleCardRetrievalRespondBE.Descriptions = dt.Rows[i]["Descriptions"].ToString();
                            singleCardRetrievalRespondBE.color = dt.Rows[i]["color"].ToString();
                            singleCardRetrievalRespondBE.Status = dt.Rows[i]["Status"].ToString();
                            singleCardRetrievalRespondBE.ReturnCode = dt.Rows[i]["RETURN_CODE"].ToString();
                            singleCardRetrievalRespondBE.Descriptions = dt.Rows[i]["DESCRIPTIONS"].ToString();
                            ListsingleCardRetrievalResponds.Add(singleCardRetrievalRespondBE);
                        }

                    }
                }


                return ListsingleCardRetrievalResponds;
            }
            catch (Exception e)
            {
                // SAVING ERROR IN THE DB
                LogBC.EntryLog("SP_SingleCardRetrieval", e.Message);

                return (List<SingleCardRetrievalRespondBE>)Results.BadRequest(e.Message);
            }
        }
        public CardUpdateResponsedBE CardUpdate(CardUpdateBE cardUpdateBE)
        {
            CardUpdateResponsedBE cardUpdateResponsedBE = new CardUpdateResponsedBE();


            try
            {
                using (SqlConnection sql = new SqlConnection(Conns))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_UpdateCard", sql))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", cardUpdateBE.UserID);
                        cmd.Parameters.AddWithValue("@CardID", cardUpdateBE.CardID);
                        cmd.Parameters.AddWithValue("@Name", cardUpdateBE.Name);
                        cmd.Parameters.AddWithValue("@Description", cardUpdateBE.Description);
                        cmd.Parameters.AddWithValue("@Color", cardUpdateBE.Color);
                        cmd.Parameters.AddWithValue("@Status", cardUpdateBE.Status);
                        sql.Open();


                        using (System.Data.IDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cardUpdateResponsedBE.ResultCode = (int)reader["RESULT"];
                                cardUpdateResponsedBE.Message = reader["DESCRIPTIONS"].ToString();

                                if (cardUpdateResponsedBE.ResultCode == 0)
                                {
                                    cardUpdateResponsedBE.Success = true;
                                }
                                else
                                {
                                    cardUpdateResponsedBE.Success = false;
                                }

                            }
                        }
                    }
                }


                return cardUpdateResponsedBE;
            }
            catch (Exception e)
            {
                LogBC.EntryLog("Sp_UpdateCard", e.Message);

                return null;
            }
        }
        public CardDeletionBEResponsedBE CardDeletion(CardDeletionBE cardDeletionBE)
        {
            CardDeletionBEResponsedBE cardDeletionBEResponsedBE = new CardDeletionBEResponsedBE();


            try
            {
                using (SqlConnection sql = new SqlConnection(Conns))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteCard", sql))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", cardDeletionBE.UserID);
                        cmd.Parameters.AddWithValue("@CardID", cardDeletionBE.CardID);
                        sql.Open();


                        using (System.Data.IDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cardDeletionBEResponsedBE.ResultCode = (int)reader["RESULT"];
                                cardDeletionBEResponsedBE.Message = reader["DESCRIPTIONS"].ToString();

                                if (cardDeletionBEResponsedBE.ResultCode == 0)
                                {
                                    cardDeletionBEResponsedBE.Success = true;
                                }
                                else
                                {
                                    cardDeletionBEResponsedBE.Success = false;
                                }

                            }
                        }
                    }
                }


                return cardDeletionBEResponsedBE;
            }
            catch (Exception e)
            {
                LogBC.EntryLog("SP_DeleteCard", e.Message);

                return null;
            }
        }
    }
}
