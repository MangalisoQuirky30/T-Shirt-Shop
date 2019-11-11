using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TShirtShopLibrary
{
    public class TShirtOrders
    {
        readonly SQLiteAsyncConnection database;
        public TShirtOrders(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TShirtOrder>().Wait();
        }


        public Task<List<TShirtOrder>> GetTShirtOrders()
        {
            return database.Table<TShirtOrder>().ToListAsync();
        }

        public Task<List<TShirtOrder>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<TShirtOrder>("SELECT *");
        }

        public Task<TShirtOrder> GetItemAsync(int id)
        {
            return database.Table<TShirtOrder>().Where(i => i.OrderId == id).FirstOrDefaultAsync();
        }


        public Task<int> UpdateTShirtOrder(TShirtOrder item)
        {
            return database.UpdateAsync(item);

        }

        public Task<int> InsertTShirtOrder(TShirtOrder item)
        {
            return database.InsertAsync(item);

        }


        public Task<int> SaveTShirtOrder(TShirtOrder item)
        {
            if (item.OrderId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }




        public Task<int> DeleteItemAsync(TShirtOrder item)
        {
            return database.DeleteAsync(item);
        }
    }
}
