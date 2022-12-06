using System.Collections;

namespace Pendu
{
    class Game
    {
        public List<char> GoodGuess; // Liste des Lettres trouvé
        public bool EndGame; // Si vrai alors la partie est gagné 
        public bool QuitGame; // Si vrai alors on quitte l'application
        public int NbError; // Nombre de faute
        ArrayList Words = new ArrayList(); //Création d'une liste de mot possible
        public string CurrentWord; // Affiche la mot que l'utilisateur est en train de deviner

        public void Play(int ErrorLeft, ArrayList Words)
        {
            //On initialise nos variable 
            EndGame = false;
            GoodGuess = new List<char>();
            // On selectionne un Mot Aleatoire parmi la liste donner 
            Random rnd = new Random();
            int index = rnd.Next(Words.Count);
            string WordToGuess = Words[index].ToString();
            WordToGuess = WordToGuess.ToUpper();
            Console.WriteLine("Le mot à deviner contient {0} lettres", WordToGuess.Length);

            while (!EndGame)
            {
                Console.WriteLine("Nombre d'erreur : {0}", NbError);
                Console.WriteLine("Veuillez rentrer une lettre :");

                char Lettre = char.ToUpper(Console.ReadKey(true).KeyChar); //on recupere l'input du clavier
                
                int result = WordToGuess.IndexOf(Lettre); 
                // on recupere l'index de la lettre selectionner si le resultat 
                // est -1 alors la lettre selectionner n'est pas dans le mot
                if(result == -1)
                {
                    Console.WriteLine("La lettre {0} est fausse", Lettre);
                    NbError ++;
                }
                else if (result >= 0)
                {
                    //On verifie si la lettre a deja été utiliser pour afficher un message différent 
                    if (GoodGuess.Contains(Lettre)){
                        Console.WriteLine("Vous avez deja utiliser la lettre {0}.", Lettre);
                    }
                    else {
                        Console.WriteLine("Vous avez trouver la lettre {0}", Lettre);
                        GoodGuess.Add(Lettre);
                    }   
                   
                }
                
                //On met a jour le mot que l'utilisateur est en train de deviner
                CurrentWord = DisplayWordtoGuess(WordToGuess);

                //Mise en place des conditions de victoire et de défaite
                if (CurrentWord.IndexOf('_') == -1)
                {
                    Console.WriteLine("Bravo vous avez trouvé !");
                    EndGame = true;
                }

                if (NbError == ErrorLeft)
                {
                    Console.WriteLine("Perdu ! Le mot était : {0}", WordToGuess);
                    EndGame = true;
                }
                
            }
        }
        //Fonction qui retourne le mot que l'utilisateur est en train de deviner
        public string DisplayWordtoGuess(string WordToGuess)
        {
            string currentWordGuessed = "";
            // pour chaque lettre dans le mot a deviner on verifie si elle 
            // correspond avec les lettres trouvé pour construire le mot
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
            Console.WriteLine();
            Console.WriteLine(currentWordGuessed);
            Console.WriteLine();

            return currentWordGuessed;
        }

        //Affichage du menu
        
        public void StartGame()
        {
            while(!QuitGame)
            {
                Console.WriteLine("Bienvenue dans le jeu du Pendu !");
                Console.WriteLine("Séléctionner une difficultés");
                Console.WriteLine("1 - Facile");
                Console.WriteLine("2 - Medium");
                Console.WriteLine("3 - Difficile");
                Console.WriteLine("4 - Quitter");

                char difficulty = Console.ReadKey(true).KeyChar;

                //Les mots et le nombre d'erreurs sont différents en fonction de la difficulté seléctionné
                switch (difficulty) {
                case '&':  
                        Words.Add("Gourde");
                        Words.Add("Soleil");
                        Words.Add("Ecran");
                        Console.WriteLine("Vous avez selectionné Facile, vous disposez de 15 erreurs");
                        Play(15, Words);
                        break;
                case 'é': 
                        Words.Add("Programmation");
                        Words.Add("Calopsitte");
                        Console.WriteLine("Vous avez selectionné Medium, vous disposez de 10 erreurs");
                        Play(10, Words);
                        break;
                    case '"': 
                        Words.Add("Hippopotomonstrosesquipedaliophobie");
                        Words.Add("Hexakosioihexekontahexaphobie");
                        Console.WriteLine("Vous avez selectionné Difficile, vous disposez de 7 erreurs");
                        Play(7, Words);
                        break;
                    default : 
                        Console.WriteLine("Au revoir !");
                        QuitGame = true;
                        break;
                }
            }
    
        }
    }
}