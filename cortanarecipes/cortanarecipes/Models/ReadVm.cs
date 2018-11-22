namespace cortanarecipes.Models
{
    public class ReadVM
    {
        public Type Type { get; set; }
        public int Sequence { get; set; }
        public string Description { get; set; }
        public string Measure { get; set; }
        public double Quantity { get; set; }

        public override string ToString()
        {
            var retorno = "";

            switch (Type)
            {
                case Type.Ingredient:
                    retorno = Quantity.ToString() + " " + Measure + " of " + Description;
                    break;
                default:
                    retorno = Description;
                    break;
            }

            return retorno;
        }
    }

    public enum Type
    {
        Ingredient,
        Instruction
    }
}
