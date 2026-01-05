using DivineTool64.Models;

namespace DivineTool64.Services
{
    public class YaoService
    {
        public Yao GenerateYao()
        {
            int seed = DateTime.Now.Ticks.GetHashCode();
            Random rnd = new Random(seed);

            return new Yao
            {
                Value = rnd.Next(2)
            };
        }
    }
}