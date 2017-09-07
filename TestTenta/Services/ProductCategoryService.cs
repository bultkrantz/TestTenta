using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestTenta.Data;

namespace TestTenta.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private ApplicationDbContext _context;

        public ProductCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SelectListItem> GetSelectList()
        {
            var categories = _context.Categories.ToList();
            var categorySelect = new List<SelectListItem>();

            categories.ForEach(c => categorySelect.Add(new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }));

            return categorySelect;
        }
    }
}
