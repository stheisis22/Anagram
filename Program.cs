using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Anagrams
{
    class Anagrams
    {
        static void Main()
        {
             //Ordena diccionario
              var d = Read();

              // Lee entrada y muestra anagrama
              string line;
              while ((line = Console.ReadLine()) != null)
              {
                  Show(d, line);
              }

           
        }

        static Dictionary<string, string> Read()
        {
              var d = new Dictionary<string, string>();
              // Lee cada linea
              using (StreamReader r = new StreamReader("wordlist.txt"))
              {
                  string line;
                  while ((line = r.ReadLine()) != null)
                  {
                      // Ordena por orden alfabetico y agrega el valor al string
                      string a = Alphabetize(line);
                      string v;
                      if (d.TryGetValue(a, out v))
                      {
                          d[a] = v + "," + line;
                      }
                      else
                      {
                          d.Add(a, line);
                      }
                  }
              }
            return d;
        }

        static string Alphabetize(string s)
        {
            char[] a = s.ToCharArray();
            Array.Sort(a);
            return new string(a);
        }

        static void Show(Dictionary<string, string> d, string w)
        {
            string v;
            if (d.TryGetValue(Alphabetize(w), out v))
            {
                Console.WriteLine(v);
            }
            else
            {
                Console.WriteLine("-");
            }
        }

        
    }
}
