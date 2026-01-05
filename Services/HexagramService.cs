using System.Text.Json;
using DivineTool64.Models;

namespace DivineTool64.Services
{
    public class HexagramService
    {
        private readonly List<Hexagram> _hexagrams;

        public HexagramService()
        {
            var json = File.ReadAllText("Data/hexagrams.json");
            _hexagrams = JsonSerializer.Deserialize<List<Hexagram>>(json);
        }

        public Hexagram GetHexagram(List<Yao> yaos)
        {
            if (yaos.Count != 6)
                throw new ArgumentException("必須是六爻");

            int lower =
                yaos[0].Value |
                (yaos[1].Value << 1) |
                (yaos[2].Value << 2);

            int upper =
                yaos[3].Value |
                (yaos[4].Value << 1) |
                (yaos[5].Value << 2);

            return _hexagrams.First(h =>
                h.LowerTrigram == lower &&
                h.UpperTrigram == upper);
        }
    }
}