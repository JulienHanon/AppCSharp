using System.Collections;

namespace Pendu
{
    class Game
    {
        public List<char> GoodGuess; // Liste des Lettres trouvé
        public List<char> BadGuess; // Liste des Lettres Manqué (peut-etre inutile)
        public bool isWin; // Si vrai alors la partie est gagné 
        public bool quitGame; // Si vrai alors on quitte l'application
        public int nbError; // Nombre de faute
        ArrayList Words = new ArrayList(); //Création d'une liste de mot possible
        //List<Words> WordList = new List<Words>(); 


        public void Play(int nbError, ArrayList Words)
        {
            this.nbError = nbError;
            
            while (!isWin)
            {
                // On selectionne un Mot Aleatoire parmi la liste donner 
                Random rnd = new Random();
                int index = rnd.Next(Words.Count);
                string WordToGuess = Words[index].ToString();
                Console.WriteLine("Le mot à deviner est {0}", Words[index]);
                Console.WriteLine("Le mot à deviner contient {0} lettres", WordToGuess.Length);
                Console.WriteLine("Veuillez rentrez une lettre :");

                char Lettre = char.ToUpper(Console.ReadKey(true).KeyChar);
                Console.WriteLine(Lettre);
                
                
                isWin = true; 

            }
        }
        public void DisplayWordtoGuess(string Word)
        {
            
        }
        public void StartGame()
        {
            while(!quitGame)
            {
                Console.WriteLine("Bienvenue dans le jeu du Pendu !");
                Console.WriteLine("Séléctionner une difficultés");
                Console.WriteLine("1 - Facile");
                Console.WriteLine("2 - Medium");
                Console.WriteLine("3 - Difficile");
                Console.WriteLine("4 - Quitter");

                char difficulty = Console.ReadKey(true).KeyChar;

                switch (difficulty) {
                case '&':  
                        Words.Add("Gourde");
                        Words.Add("Soleil");
                        Words.Add("Ecran");
                        Console.WriteLine("Vous avez selectionné Facile");
                        Play(15, Words);
                        break;
                case 'é': 
                        Words.Add("Programmation");
                        Words.Add("Calopsitte");
                        Console.WriteLine("Vous avez selectionné Medium");
                        Play(10, Words);
                        break;
                    case '"': 
                        Words.Add("Hippopotomonstrosesquipedaliophobie");
                        Words.Add("Hexakosioihexekontahexaphobie");
                        Console.WriteLine("Vous avez selectionné Difficile");
                        Play(7, Words);
                        break;
                    default : 
                        Console.WriteLine("Au revoir !");
                        quitGame = true;
                        break;
                }
            }
    
        }
    }
}