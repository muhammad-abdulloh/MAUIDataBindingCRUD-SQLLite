using MAUIDataBindingCRUD.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIDataBindingCRUD.Services
{
    public class CustomerDBService
    {
        private readonly string CONNECTION_STRING = "mauimy_db.db3";

        private readonly SQLiteAsyncConnection _connection;

        public CustomerDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, CONNECTION_STRING));
         
            _connection.CreateTableAsync<Customer>();
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _connection.Table<Customer>().ToListAsync();

            return customers;
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await _connection.Table<Customer>().FirstOrDefaultAsync(x => x.Id == id);

            return customer;
        }

        public async Task Insert(Customer customer)
        {
             await _connection.InsertAsync(customer);
        }

        public async Task Delete(Customer customer)
        {
            await _connection.DeleteAsync(customer);
        }

        public async Task Update(Customer customer)
        {
            await _connection.UpdateAsync(customer);
        }


    }
}
