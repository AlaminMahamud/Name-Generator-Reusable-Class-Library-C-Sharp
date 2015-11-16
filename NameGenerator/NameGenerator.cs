using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameGenerator
{
    public class NameGenerator
    {
        private string[] malenames;
        private string[] femalenames;
        private string[] surnames;

        private string[] initials = new string[] { "A", "B", "C" };

        /// <summary>
        /// Creating an Random Object
        /// </summary>
        /// 
        private Random ran = new Random();

        public NameGenerator()
        {
            malenames = System.IO.File.ReadAllLines("maleNames.txt");
            femalenames = System.IO.File.ReadAllLines("femaleNames.txt");
            surnames = System.IO.File.ReadAllLines("surNames.txt");
        }

        ///
        /// Generate Female Name
        ///             
        public string GetFemaleName()
        {
            var randomFirstIndex = ran.Next(0, femalenames.Length - 1);
            var randomSurIndex = ran.Next(0, surnames.Length - 1);
            return femalenames[randomFirstIndex] + " " + femalenames[randomSurIndex];
        }

        public List<string> GetFemaleNames(int maxCount)
        {
            var temp = new List<string>();

            var q1 = from f in femalenames
                     orderby ran.NextDouble()
                     select f;

            var q2 = from s in surnames
                     orderby ran.NextDouble()
                     select s;

            var firstResults = q1.ToArray();
            var surResults = q2.ToArray();

            var count = firstResults.Count() < surResults.Count() ? firstResults.Length : surResults.Length;

            for (int i = 0; i < count; i++)
            {
                temp.Add(firstResults[i] + " " + surResults[i]);
            }

            return temp;
        }

        public string GetMaleName()
        {
            var firstIndex = ran.Next(0, malenames.Length-1);
            var surIndex = ran.Next(0,surnames.Length-1);
            return malenames[firstIndex] + " " + surnames[surIndex];
        }
        public List<string> GetMaleNames()
        {
            List<string> temp = new List<string>();

            var q1 = from m in malenames
                     orderby ran.NextDouble()
                     select m;

            var q2 = from m in surnames
                     orderby ran.NextDouble()
                     select m;

            var firstnames = q1.ToArray();
            var secondnames = q2.ToArray();

            var count = firstnames.Length < secondnames.Length ? firstnames.Length : secondnames.Length;
            for (int i = 0; i < count; i++)
            {
                temp.Add(firstnames[i] + " " + secondnames[i]);
            }

            return temp;
        }
    }
}
