using System.Collections.Generic;
using System.Linq;
namespace TestGreatHello

{
    public class Greet : IGreetHello
    {
      
        public string GreetHello(params string[] names)
        {
            if (names == null)
            {
                return "Hello, my friend.";
            }
            if (names.Length == 1)
            {
                return names[0] == names[0].ToUpper() ? $"HELLO {names[0]}!" : $"Hello, {names[0]}.";
            }
            if (names.Length == 2 && !names[0].Contains(",") && !names[1].Contains(","))
            {
                return "Hello, " + names[0] + " and " + names[1] + ".";
            }

            bool trovato = false; 
            List<string> nomiUp = new();
            List<string> nomiDown = new();
            foreach (var tmp in names)
            {
                if (tmp.All(char.IsUpper))
                {
                    nomiUp.Add(tmp);
                }
                else
                if (tmp.Contains(",") && tmp.Contains('"'))
                {
                    trovato = true; 
                    nomiDown.Add(string.Concat(" and", tmp.Replace('"',' ').Split(",").First(),',', tmp.Replace("\"", string.Empty).Split(",").Last()));
                }
                else
                if (tmp.Contains(","))
                {
                    nomiDown.AddRange(tmp.Split(','));
                }
                else
                {
                    nomiDown.Add(tmp);
                }

            }

            if (nomiUp.Any())
            {
                return string.Concat("Hello, ", string.Join(", ", nomiDown.Where(x => x != nomiDown.Last())),
                    " and ", nomiDown.Last(), ". AND HELLO ", string.Join("", nomiUp), "!");
            }
            if (trovato)
            {
                return string.Concat("Hello, ", string.Join(nomiDown.First(),nomiDown.Where(x => x != nomiDown.Last())),nomiDown.Last(), ".");
            }
            
            return string.Concat("Hello, ", string.Join(", ", nomiDown.Where(x => x != nomiDown.Last())), " and ", nomiDown.Last(), ".");
        }



    }
}