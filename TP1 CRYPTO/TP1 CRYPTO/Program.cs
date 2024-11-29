using System;
using System.Collections.Generic;
using System.Linq;

//Réalisateur Imerzoukene Anisse - Elouali Wissam BUT 2 groupe 4 
namespace Program
{
    static class Premier
    {
        /// <summary>
        /// Affiche la valeur des indexs contenant la valeur de vérité Mode.
        /// </summary>
        /// <param name="Tableau">Tableau traité.</param>
        /// <param name="Mode">Valeur de vérité à afficher</param>
        public static void AffichePremierTableauBool(bool[] Tableau, bool Mode)
        {
            Console.WriteLine("Tab:");
            for (int index = 0; index < Tableau.Length; index++)
            {
                if (Tableau[index] == Mode)
                {
                    Console.WriteLine($"{index}");
                }
            }
        }

        /// <summary>
        /// Crible d'Erathosthene n'étant pas celui présenté dans le cours. N'est pas le plus optimisé.
        /// Retourne un tableau de bool dont les indexs à false sont premiers. 
        /// </summary>
        /// <param name="Tableau">Tableau traité</param>
        public static void EratostheneImerzoukene(ref bool[] Tableau)
        {
            Tableau[0] = true;
            Tableau[1] = true;
            for (double index = 2; index*index < Tableau.Length; index++)               //amélioration index vers index carré (marche dans les deyx cas)
            {
                for(double parcour = index + 1; parcour < Tableau.Length; parcour = parcour + 1)
                {
                    if ((parcour / index % 1)==0.00)               //On cherche ici à savoir si l'index peut diviser les nombres vers l'avant, si oui ils ne sont pas premiers.
                    {
                        Tableau[(int)parcour] = true;
                    }
                }
            }
        }

        /// <summary>
        /// Trouve tous les premiers selon la taille du tableau boolPremier, met les indexs non premiers à true, les premiers à false.
        /// </summary>
        /// <param name="Tableau">Tableau traité.</param>
        static bool[] Crible(bool[] boolPremierA)
        {
            bool[] boolPremierB = new bool[boolPremierA.Length + 1];
            boolPremierB[0] = true;  // on traite les exceptions 
            boolPremierB[1] = true;
            for (int index = 2; index <= Math.Sqrt(boolPremierB.Length - 1); index++)
            {
                if (boolPremierB[index] == false)
                {
                    for (int Parcour = index + 1; Parcour <= boolPremierB.Length - 1; Parcour++)
                    {
                        if (boolPremierB[Parcour] == false && Parcour % index == 0)
                        {
                            boolPremierB[Parcour] = true;
                        }
                    }
                }
            }
            return boolPremierB;
        }

        /// <summary>
        /// On renvoie ici par reference une liste dont les indexs à false sont premiers.
        /// </summary>
        /// <param name="Tableau">Tableau de bools à transformer en tableau de int</param>
        /// <param name="mode">Valeur de vérité des indexs à retenir dans la liste.</param>
        /// <returns>Retourne les indexs dont la valeur de vérité est mode.</returns>
        public static List<int> TableauBoolVersListe(bool[] Tableau, bool mode)
        {
            List<int> ListInt = new List<int>();
            for(int index = 0; index < Tableau.Length; index++)
            {
                if (Tableau[index]==mode)
                {
                    ListInt.Add(index);
                }
            }
            return ListInt;
        }

        /// <summary>
        /// Determine et renvoie le pgcd de a et b
        /// </summary>
        /// <param name="a">Valeur a.</param>
        /// <param name="b">Valeur b.</param>
        /// <returns>PGCD</returns>
        public static int EuclidePGCD(int a, int b)
        {
            int r = a % b;
            if (r==0)
            {
                return b;
            }
            else if(b > r )
            {
                return EuclidePGCD(b, r);
            }
            return b;
        }

        /// <summary>
        /// Renvoie true si a et b sont etrangés sinon false.
        /// </summary>
        /// <param name="a">Valeur a.</param>
        /// <param name="b">Valeur b.</param>
        /// <returns>True si étranger, false sinon.</returns>
        public static bool Etranger(int a, int b )
        {
            if (EuclidePGCD(a, b) == 1) return true;
            return false;
        }

        /// <summary>
        /// Determine et revoie une liste contenant la DFP de Decompose.
        /// </summary>
        /// <param name="Decompose">Valeur dont on veut determiner la DFP.</param>
        /// <returns>List des valeurs composantes de la DFP de Decompose.</returns>
        public static List<int> DFP(int Decompose)
        {
            List<int> DFP = new List<int>();
            if (Decompose == 1 || Decompose == 0) { DFP.Add((int)Decompose); return DFP; }
            bool[] Tableau = new bool[Convert.ToInt32(Decompose)];
            Tableau = Crible(Tableau);
            List<int> ListPremiers = TableauBoolVersListe(Tableau, false);      //On veut traiter une liste de nombres premiers et non une liste de bools (plus simple pour les calculs)
            int index = 0;
            while(Decompose != 1 && index!=ListPremiers.Count){
                if(Decompose % ListPremiers[index] == 0){
                    Decompose = Decompose / ListPremiers[index];
                    DFP.Add((int)ListPremiers[index]);
                }
                else{
                    index++;
                }
            }
            return DFP;
        }

        /// <summary>
        /// Determine et renvoie la valeur de valeur exposant de la valeur "exposant".
        /// </summary>
        /// <param name="Valeur">Valeur dont on veut renvoyer sa valeur à l'esposant Exposant.</param>
        /// <param name="exposant">Valeut de l'exposant;</param>
        /// <returns>Valeur de la varible valeur exposant Exposant.</returns>
        public static double Exposant(double Valeur, int exposant)
        {
            double temp = Valeur;
            if (exposant == 0) return 1;
            if (exposant == 1) return Valeur;
            for (int index = 0; index < exposant - 1; index++)
            {
                Valeur = Valeur * temp;
            }
            return Valeur;
        }

        /// <summary>
        /// Renvoie le nombre de réurrence de valeur dans la liste Liste.
        /// </summary>
        /// <param name="Liste">Liste traité.</param>
        /// <param name="Valeur">Valeur dont on veut renvoyer le nombre d'apparitions.</param>
        /// <returns>Nombre de récurrence de valeur dans Liste.</returns>
        public static int NombreDeRecurrence(List<int> Liste, int Valeur)
        {
            int tmp = 0;
            for(int index = 0; index < Liste.Count; index++)
            {
                if (Liste[index] == Valeur) tmp++;
            }
            return tmp;
        }

        /// <summary>
        /// Determine et renvoie l'indicateur d'Euler de la valeur val.
        /// </summary>
        /// <param name="val">Valeur dont on veut la valeur de l'indicateur d'Euler.</param>
        /// <returns>Indicateur d'Euler</returns>
        public static double Euler(int val)
        {
            if (val == 0 || val == 1) return val;
            List<int> Liste = DFP(val);
            List<int> ListeSansDoublon = new HashSet<int>(Liste).ToList();
            if(Liste.Count == 0 || (Liste.Count == 1 && Liste[0]==1)) return 0;
            double Euler = 1;
            for (int index = 0; index < ListeSansDoublon.Count; index++)
            {
                Euler = Euler * (Exposant(ListeSansDoublon[index], NombreDeRecurrence(Liste, Convert.ToInt16(ListeSansDoublon[index]) ) - 1)) * (ListeSansDoublon[index] - 1);
            }
            return Euler;
        }

        public static void Main()
        {
            //Crible selon quantité de cases tableau
            Console.WriteLine("Test Crible 10 :");
            bool[] Tableau = new bool[10];
            AffichePremierTableauBool(Tableau, false);
            Tableau = Crible(Tableau);
            AffichePremierTableauBool(Tableau, false);

            //DFP
            Console.WriteLine("Test DFP 50 :");
            List<int> Liste = DFP(50);
            for (int index = 0; index < Liste.Count; index++)
            {
                Console.WriteLine($"{Liste[index]} ");
            }

            //PGCD
            Console.WriteLine($"Test PGCD 25 - 50 : {EuclidePGCD(25, 50)}");
            //Etranger
            Console.WriteLine($"Test etranger 7 et 11 : {Etranger(7, 11)}");
            //Euler 
            Console.WriteLine($"Test Euler 10 : {Euler(10)}");
        }
    }
}