using cortanarecipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cortanarecipes.DataAccess
{
    public class IngredientDAO : IDisposable
    {
        private ApplicationContext _context;

        public IngredientDAO()
        {
            _context = new ApplicationContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IList<Ingredient> Ingredients(int recipeid)
        {
            return _context.Ingredients.Where(p => p.RecipeId == recipeid).ToList();
        }

        public Ingredient Ingredient(int ingredientId)
        {
            return _context.Ingredients.Find(ingredientId);
        }

        public void Add(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
        }

        public void Update(Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
            _context.SaveChanges();
        }

        public void Remove(Ingredient ingredient)
        {
            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();
        }
    }
}
