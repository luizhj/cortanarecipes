using cortanarecipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cortanarecipes.DataAccess
{
    public class RecipeDAO : IDisposable
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
            return _context.Recipes.OrderBy(p => p.Id).ToList();
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

        public async Task Remove(Recipe Recipe)
        {
            await new InstructionDAO().RemoveAll(Recipe.Id);
            await new IngredientDAO().RemoveAll(Recipe.Id);

            _context.Recipes.Remove(Recipe);
            _context.SaveChanges();
        }
    }
}
