using Dapper;
using DL.ModernStore.Domain.Commands.Results;
using DL.ModernStore.Domain.Entities;
using DL.ModernStore.Domain.Repositories;
using DL.ModernStore.Infra.Contexts;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace DL.ModernStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;

        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        
        public Customer Get(Guid id)
        {
            return _context.Customer
                        .Include(x => x.User)
                        .FirstOrDefault(x=>x.Id == id);
        }

        //public Customer Get(string document)
        //{
        //    return _context.Customer
        //                .Include(x => x.User)
        //                .FirstOrDefault(x => x.Document.Number == document);
        //}

        public Customer GetByUserId(Guid id)
        {
            return _context.Customer
                        .Include(x => x.User)
                        .AsNoTracking()
                        .FirstOrDefault(x => x.User.Id == id);
        }

        public void Save(Customer customer)
        {
            _context.Customer.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified; 
        }

        public bool DocumentExists(string document)
        {
            return _context.Customer.Any(x => x.Document.Number == document);
        }

        public GetCustomerCommandResult Get(string username)
        {
            var sql = @"select * from Customers c 
                             left join User u on u.Id=c.Id
                             where u.Username = @username ";

            using (var conn = new SqlConnection(@"Server=sql5039.site4now.net; Database=DB_A4598C_ibsapps; User Id=DB_A4598C_ibsapps_admin;Password = dspectre32;"))
            {
                conn.Open();
                return conn.Query<GetCustomerCommandResult>(sql, new { username = username }).FirstOrDefault();
            }

            //return _context.Customer
            //        .Include(x=>x.User)
            //        .AsNoTracking()
            //        .Select(x => new GetCustomerCommandResult
            //        {
            //            Name = x.Name.ToString(),
            //            Document = x.Document.Number,
            //            Active = x.User.Active,
            //            Email = x.Email.Address,
            //            Username = x.User.UserName,
            //            Password = x.User.Password
            //        })
            //        .FirstOrDefault(x => x.Username == username);
        }
    }
}
