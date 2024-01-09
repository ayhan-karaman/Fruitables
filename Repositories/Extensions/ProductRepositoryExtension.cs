using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtension
    {
        public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products, int? categoryId)
        {
            return categoryId is null ? products  : products.Where(x => x.CategoryId == categoryId);
        }
        public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products, string? searchTerm)
        {
            return searchTerm is null ? products : products.Where(
                p => p.Name.ToLower().Contains(searchTerm.ToLower())
                || p.UnitPrice.ToString().ToLower().Contains(searchTerm.ToLower())
            );
        }

        public static IQueryable<Product> FilteredByMinAndMaxPrice(this IQueryable<Product> products, int? minPrice, int? maxPrice, bool isValidPrice)
        {
            return isValidPrice ? products.Where(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice)  : products;

        }

        public static IQueryable<Product> ToPaginate(this IQueryable<Product> products, int pageNumber, int pageSize)
        {
            return products.Skip((pageNumber -1)* pageSize).Take(pageSize); 
        }
    }
}