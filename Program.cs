using System;
using System.Collections.Generic;
using System.Linq;

namespace programme_poo
{

    class Personne
    {

        static int nombreDePersonnes = 0; // quand on met static, on aura qu'une seule variable qui va se créer pour la classe sinon on créé des variables pour toutes les personnes. // marche comme une variable globale

        public string nom; // est fait référence par this.nom
        int age;
        string emploi;
        int numeroPersonne;

        public Personne(string nom, int age, string emploi = null) // ici est le second nom de la ligne suivante // ICI est le constructeur, on y passe les paramètres nom age emploi.
        {
            this.nom = nom; // this permet d'éviter les confusions, fait référence à l'objet courant
            this.age = age;
            this.emploi = emploi;

            nombreDePersonnes++;

            this.numeroPersonne = nombreDePersonnes;
        }

        public void Afficher() // On fait en sorte qu'une personne puisse s'afficher, Afficher() est donc une méthode de personne, une action.
        {
            Console.WriteLine("PERSONNE N° " + numeroPersonne);
            Console.WriteLine("NOM : " + nom); // ici le this est implicit
            Console.WriteLine(" AGE : " + age + " ans");
            if (emploi == null)
            {
                Console.WriteLine(" Aucun emploi spécifié");
            }
            else
            {
                Console.WriteLine(" EMPLOI : " + emploi);
            }

        }

        public static void AfficherNombreDePersonnes()
        {
            Console.WriteLine("Nombre total de personnes : " + nombreDePersonnes);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Personne personne1 = new Personne("Paul", 30);
            personne1.Afficher();

            // Console.WriteLine("nom personne1 : " + personne1.nom);

            /*Personne personne2 = new Personne("Jacques", 35, "Professeur");
            personne2.Afficher();*/

/*            var personnes = new List<Personne> { 
                new Personne("Paul", 30, "Développeur"), 
                new Personne("Jacques", 35, "Professeur"), 
                new Personne("David", 35, "Etudiant"), 
                new Personne("Juliette", 35, "CP"), 
            };*/

            // personnes = personnes.OrderBy(p => p.nom).ToList(); // ici on a pu trier par nom parce qu'on a mis nom en public

            /*foreach (var personne in personnes)
            {
                personne.Afficher();
            }

            Personne.AfficherNombreDePersonnes(); // en mettant le nom de la classe avant la variable static pour y accéder, vu que c'est une variable de classe*/

        }
    }
}