using Dapper;
using DL.ModernStore.Domain.Commands.Results;
using DL.ModernStore.Domain.Entities;
using DL.ModernStore.Domain.Repositories;
using DL.ModernStore.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DL.ModernStore.Infra.Repositories
{
    public class ProductRepository : ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;

        public ProductRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context.Products
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Id == id);
        }

       
        public IEnumerable<GetProductListCommandResult> Get()
        {
            var sql = @"select Id, Title, Price, Image from Products ";

            using (var conn = new SqlConnection(@"Server=sql5039.site4now.net; Database=DB_A4598C_ibsapps; User Id=DB_A4598C_ibsapps_admin;Password = dspectre32;"))
            {
                conn.Open();
                return conn.Query<GetProductListCommandResult>(sql);
            }
        }
    }
}
