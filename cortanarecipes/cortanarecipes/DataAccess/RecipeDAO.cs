using cortanarecipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cortanarecipes.DataAccess
{
    public class RecipeDAO :IDisposable
    {
        private ApplicationContext _context;

        public RecipeDAO()
        {
            _context = new ApplicationContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IList<Recipe> Recipes()
        {
            return _context.Recipes.ToList();
        }

        public Recipe Recipe(int RecipeId)
        {
            return _context.Recipes.Find(RecipeId);
        }

        public void Add(Recipe Recipe)
        {
            _context.Recipes.Add(Recipe);
            _context.SaveChanges();
        }

        public void Update(Recipe Recipe)
        {
            _context.Recipes.Update(Recipe);
            _context.SaveChanges();
        }

        public void Remove(Recipe Recipe)
        {
            _context.Recipes.Remove(Recipe);
            _context.SaveChanges();
        }
    }
}
