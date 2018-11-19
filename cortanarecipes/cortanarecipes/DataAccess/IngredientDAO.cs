using cortanarecipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _context.Ingredients.Where(p => p.RecipeId == recipeid).OrderBy(p => p.Sequence).ToList();
        }

        public Ingredient Ingredient(int ingredientId)
        {
            return _context.Ingredients.Find(ingredientId);
        }

        public void Add(Ingredient ingredient)
        {
            ingredient.Sequence = NextSequence(ingredient.RecipeId);
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

        public int NextSequence(int recipeid)
        {
            if (_context.Ingredients.Where(p => p.RecipeId == recipeid).OrderBy(p => p.Sequence).LastOrDefault() is Ingredient ingredient)
            {
                return ingredient.Sequence + 1;
            }
            return 0;
        }

        public async Task RemoveAll(int recipeId)
        {
            var lista = Ingredients(recipeId);

            foreach (var item in lista)
            {
                _context.Remove(item);
            }

            await _context.SaveChangesAsync();
        }
    }
}
