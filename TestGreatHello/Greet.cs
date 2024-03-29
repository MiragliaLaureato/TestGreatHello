﻿using System.Linq;

namespace TestGreatHello
{
    public class Greet : IGreetHello
    {
        private static string[] SplitComma(string sign, string[] names)
        {
            var comma = names?.Where(x => x.Contains(sign)).ToArray();
            names = names?.Except(comma).ToArray();
            return names?.Concat(comma.SelectMany(x => x.Split(sign))).ToArray();
        }

        public string GreetHello(params string[] names)
        {
            names = SplitComma(", ", names);

            if (names == null)
                return "Hello, my friend.";

            if (names.Length == 1)
                return names[0] == names[0].ToUpper() ? $"HELLO {names[0]}!" : $"Hello, {names[0]}.";

            if (names.Length == 2)
                return $"Hello, {names[0]} and {names[1]}.";

            var nameUpp = names.Where(x => x.All(char.IsUpper)).ToList();
            var nameDown = names.Except(nameUpp).ToList();

            var result = string.Concat("Hello, ", string.Join(", ", nameDown.Where(x => x != nameDown.Last())), " and ", nameDown.Last(), ".");
            
            if (nameUpp.Any())
                return string.Concat(result, " AND HELLO ", string.Join(", ", nameUpp.Select(x => x)), "!");

            return result;
        }

    }
}