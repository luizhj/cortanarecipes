using cortanarecipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return _context.Instructions.Where(p => p.RecipeId == recipeid).ToList();
        }

        public Instruction Instruction(int instructionId)
        {
            return _context.Instructions.Find(instructionId);
        }

        public void Add(Instruction instruction)
        {
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
    }
}
