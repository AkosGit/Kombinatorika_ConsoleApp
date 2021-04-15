using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace combinatorics
{
    class InteractWithConsole
    {
        public InteractWithConsole()
        {
            Console.WriteLine("Navigáláshoz az opció számát írd be.");
            Console.WriteLine("A főmenühöz való visszalépéshez bármelyik lépésnél '.'-ot írj be.");
            loop();
           
        }
        int Permutations_WithRep(int n)
        {
            Console.WriteLine("Adja meg hány db 'k'-t akar megadni");
            int counter = Input("db:", 0, 0);
            int[] kTomb = new int[counter];
            Console.WriteLine("Adja meg az első 'k'-t");
            for (int j = 0; j < counter; j++)
            {
                kTomb[j] = Input($"k{j + 1}:", 0, 0);
                Console.WriteLine("írd be a következő 'k' értéket");
            }
            return Combinatorics.Permutation_WithRep(n, kTomb);
        }
        void loop()
        {
           
            while (true)
            {
                int output = 0;
                Console.WriteLine("Táblázattal akarod használni(1) vagy manuálisan választod ki a tipust(2)");
                int opt = Input("Opció:", 1, 2);
                if (opt == 1)
                {
                    Console.WriteLine("A következő kérédésekre igennel(1) vagy nemmel(0)\n");
                    bool Isused = Convert.ToBoolean(Input("Minden elemet felhasználunk?", 0, 1));
                    bool Isorder = Convert.ToBoolean(Input("Számít a sorrend?", 0, 1));
                    bool Isrep = Convert.ToBoolean(Input("Ismétlés van?", 0, 1));
                    int n = Input("n:",0,0);
                    if(Isused && Isorder && Isrep==false)
                    {

                        output = Combinatorics.Permutations(n);
                    }
                    if (Isused && Isorder && Isrep)
                    {

                        output=Permutations_WithRep(n);
                    }
                    if (Isused==false && Isorder && Isrep==false)
                    {

                        output = Combinatorics.Variations(n, Input("k:", 0, 0));
                    }
                    if (Isused == false && Isorder && Isrep)
                    {

                        output = Combinatorics.Variations_WithRep(n, Input("k:", 0, 0));
                    }
                    if (Isused == false && Isorder==false && Isrep==false)
                    {
                        output = Combinatorics.Combinations(n, Input("k:", 0, 0));

                    }
                    if (Isused == false && Isorder == false && Isrep)
                    {
                        output = Combinatorics.Combinations_WithRep(n, Input("k:", 0, 0));

                    }
                    Console.WriteLine(output);
                }
                else
                {
                    Console.WriteLine("Permutáció(1)\nIsmétléses Permutáció(2)");
                    Console.WriteLine("Variáció(3)\nIsmétléses Variáció(4)");
                    Console.WriteLine("Kombináció(5)\nIsmétléses Kombináció(6)");
                    int input = Input("Opció: ",1,6);
                    int n = Input("n:", 0, 0);
                    switch (input)
                    {
                        case 1:
                            output=Combinatorics.Permutations(n);
                            break;
                        case 2:
                            output=Permutations_WithRep(n);
                            break;
                        case 3:
                            output = Combinatorics.Variations(n, Input("k:",0,0));
                            break;
                        case 4:
                            output = Combinatorics.Variations_WithRep(n, Input("k:",0,0));
                            break;
                        case 5:
                            output = Combinatorics.Combinations(n, Input("k:",0,0));
                            break;
                        case 6:
                            output = Combinatorics.Combinations_WithRep(n, Input("k:",0,0));
                            break;
                    }
                    Console.WriteLine(output);
                }
            }
        }
        int Input(string var,int from, int to)// a from és to az érvényes számok intervalluma
        {
            int res = 0;
            Console.Write($"{var}");
            string n = Console.ReadLine();
            if (int.TryParse(n, out res) == false)
            {
                if (n==".")
                {
                    loop();
                }
                Console.WriteLine("Nem számot írtál be!");

                return Input(var,from,to);
            }
            if ((from != 0 && to != 0))//ha számolás van akkor nincs a számoknak intervalluma
            {
                if(!(res >= from && res <= to))
                {
                    Console.WriteLine("Ilyen opció nincs");
                    return Input(var, from, to);
                } 
            }

            return res;
        }
    }

}
