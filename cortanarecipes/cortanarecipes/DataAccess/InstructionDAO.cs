using cortanarecipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cortanarecipes.DataAccess
{
    public class InstructionDAO : IDisposable
    {
        private ApplicationContext _context;

        public InstructionDAO()
        {
            _context = new ApplicationContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IList<Instruction> Instructions(int recipeid)
        {
            return _context.Instructions.Where(p => p.RecipeId == recipeid).OrderBy(p => p.Sequence).ToList();
        }

        public Instruction Instruction(int instructionId)
        {
            return _context.Instructions.Find(instructionId);
        }

        public void Add(Instruction instruction)
        {
            instruction.Sequence = NextSequence(instruction.Id);
            _context.Instructions.Add(instruction);
            _context.SaveChanges();
        }

        public void Update(Instruction instruction)
        {
            _context.Instructions.Update(instruction);
            _context.SaveChanges();
        }

        public void Remove(Instruction instruction)
        {
            _context.Instructions.Remove(instruction);
            _context.SaveChanges();
        }

        public int NextSequence(int recipeId)
        {
            if (_context.Instructions.Where(p => p.RecipeId == recipeId).OrderBy(p => p.Sequence).LastOrDefault() is Instruction instruction)
            {
                return instruction.Sequence + 1;
            }
            return 0;
        }

        public async Task RemoveAll(int recipeId)
        {
            var lista = Instructions(recipeId);

            foreach (var item in lista)
            {
                _context.Remove(item);
            }

            await _context.SaveChangesAsync();
        }

    }
}
