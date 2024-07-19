﻿using SalesWebMvc.Data;

namespace SalesWebMvc.Models.Services
{
    public class SellerService
    {
        public readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context) 
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}