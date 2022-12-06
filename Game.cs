using System.Collections;

namespace Pendu
{
    class Game
    {
        public List<char> GoodGuess; // Liste des Lettres trouvé
        public bool isWin; // Si vrai alors la partie est gagné 
        public bool quitGame; // Si vrai alors on quitte l'application
        public int nbError; // Nombre de faute
        ArrayList Words = new ArrayList(); //Création d'une liste de mot possible
        //List<Words> WordList = new List<Words>(); 
        public string currentWord;

        public void Play(int ErrorLeft, ArrayList Words)
        {
            isWin = false;
            GoodGuess = new List<char>();
            // On selectionne un Mot Aleatoire parmi la liste donner 
            Random rnd = new Random();
            int index = rnd.Next(Words.Count);
            string WordToGuess = Words[index].ToString();
            WordToGuess = WordToGuess.ToUpper();
            Console.WriteLine("Le mot à deviner contient {0} lettres", WordToGuess.Length);
            while (!isWin)
            {
                Console.WriteLine("Nombre d'erreur : {0}", nbError);
                Console.WriteLine("Veuillez rentrer une lettre :");

                char Lettre = char.ToUpper(Console.ReadKey(true).KeyChar); //on recupere l'input du clavier
                
                int result = WordToGuess.IndexOf(Lettre); 
                // on recupere l'index de la lettre selectionner si le resultat 
                // est -1 alors la lettre selectionner n'est pas dans le mot
                if(result == -1)
                {
                    Console.WriteLine("La lettre {0} est fausse", Lettre);
                    nbError ++;
                }
                else if (result >= 0)
                {
                    if (GoodGuess.Contains(Lettre)){
                        Console.WriteLine("Vous avez deja utiliser la lettre {0}.", Lettre);
                    }
                    else {
                        Console.WriteLine("Vous avez trouver la lettre {0}", Lettre);
                        GoodGuess.Add(Lettre);
                    }   
                   
                }

                currentWord = DisplayWordtoGuess(WordToGuess);

                if (currentWord.IndexOf('_') == -1)
                {
                    Console.WriteLine("Bravo vous avez trouvé !");
                    isWin = true;
                }

                if (nbError == ErrorLeft)
                {
                    Console.WriteLine("Perdu ! Le mot était : {0}", WordToGuess);
                    isWin = true;
                }
                
            }
        }
        public string DisplayWordtoGuess(string WordToGuess)
        {
            string currentWordGuessed = "";
            foreach(char l in WordToGuess)
            {
                if (GoodGuess.Contains(l))
                {
                    currentWordGuessed += l;
                }
                else
                {
                    currentWordGuessed += "_";
                }

            }
            Console.WriteLine(currentWordGuessed);
            Console.WriteLine();

            return currentWordGuessed;
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