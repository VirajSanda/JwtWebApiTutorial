using Dapper;
using JwtWebApiTutorial.Data;
using JwtWebApiTutorial.Models;
using Newtonsoft.Json;
using System.Drawing;
using System.Text.Json;
using static System.Data.CommandType;

namespace JwtWebApiTutorial.Repository.SummaryRepository
{
    public class SummaryRepository : BaseRepository, ISummaryRepository
    {
        #region Const
        private const string SP_SELECT_ALLCOINS = "[dbo].[Select_Allcoins]";
        private const string SP_UPDATE_COINPRICE = "[dbo].[Update_CoinPrice]";
        #endregion

        //public async Task<List<Coin>> GetAll()
        //{
        //    List<Coin> coins = SqlMapper.Query<Coin>(con, SP_SELECT_ALLCOINS, commandType: StoredProcedure).ToList();
        //    return coins;
        //}
        public async Task<CoinPrice> UpdateCoinPriceBySymbol(CoinPrice coinPrice)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Price", coinPrice.Price);
            parameters.Add("@Symbol", coinPrice.Symbol);
            CoinPrice coins = SqlMapper.Query<CoinPrice>(con, SP_UPDATE_COINPRICE, parameters, commandType: StoredProcedure).FirstOrDefault();
            return coins;
        }
        //public async Task<List<CoinPrice>> UpdateAllCoinPrices(List<CoinPrice> coinPrice)
        //{
        //    DynamicParameters parameters = new DynamicParameters();
        //    parameters.Add("@CoinPrice", JsonConvert.SerializeObject(coinPrice));
        //    List<CoinPrice> coins = SqlMapper.Query<CoinPrice>(con, SP_SELECT_ALLCOINS, commandType: StoredProcedure).ToList();
        //    return coins;
        //}


        //------------------------------------------------------------//

        public async Task<List<Coin>> GetAll()
        {
            using (con)
            {
                IEnumerable<Coin> coinList = await con.QueryAsync<Coin>(SP_SELECT_ALLCOINS, commandType: StoredProcedure);
                return coinList.ToList();
            }
        }
        //public async Task<CoinPrice> UpdateCoinPriceBySymbol(CoinPrice coinPrice)
        //{
        //    using (con)
        //    {
        //        if (con.ConnectionString != null)
        //        {

        //        }
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@Price", coinPrice.Price);
        //        parameters.Add("@Symbol", coinPrice.Symbol);
        //        int a = await con.ExecuteAsync(SP_UPDATE_COINPRICE, parameters, commandType: StoredProcedure);
        //        CoinPrice coinPrice1 = new();
        //        return coinPrice1;
        //    }
        //}

        public async Task<List<CoinPrice>> UpdateAllCoinPrices(List<CoinPrice> coinPrice)
        {
            using (con)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CoinPrice", JsonConvert.SerializeObject(coinPrice));
                IEnumerable<CoinPrice> coins = await con.QueryAsync<CoinPrice>(SP_SELECT_ALLCOINS, commandType: StoredProcedure);
                return coins.ToList();
            }
        }
    }
}
