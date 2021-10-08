using System;
using System.Collections.Generic;
using System.Linq;

namespace programme_poo
{

    class Enfant : Etudiant
    {
        string classeEcole;
        Dictionary<string, float> notes;
        public Enfant(string nom, int age, string classeEcole, Dictionary<string, float> notes) : base(nom, age, null)
        {
            this.classeEcole = classeEcole;
            this.notes = notes;
        }

        public override void Afficher()
        {
            AfficherNomEtAge();
            Console.WriteLine(" Enfant en classe de " + classeEcole);
            if ((notes != null) && (notes.Count > 0))
            {
                Console.WriteLine(" Notes moyennes :");
                foreach (var note in notes)
                {
                    Console.WriteLine("    " + note.Key + " : " + note.Value + " / 10");
                }
            }
            AfficherProfesseurPrincipal();
        }
    }



    class Etudiant : Personne // Etudiant hérite de Personne
    {
        string infoEtudes;
        public Personne professeurPrincipal;
        public Etudiant(string nom, int age, string infoEtudes) : base(nom, age, "Etudiant")
        {
            this.infoEtudes = infoEtudes;
        }

        public override void Afficher() // cette fonction surcharge une fonction venant de la classe aprent
        {
            AfficherNomEtAge();
            Console.WriteLine(" Etudiant en " + infoEtudes);
            AfficherProfesseurPrincipal();
        }

        protected void AfficherProfesseurPrincipal()
        {
            if (professeurPrincipal != null)
            {
                Console.WriteLine(" Le professeur principal est : ");
                professeurPrincipal.Afficher();
            }
        }

    }

    class Personne
    {

        static int nombreDePersonnes = 0; // quand on met static, on aura qu'une seule variable qui va se créer pour la classe sinon on créé des variables pour toutes les personnes. // marche comme une variable globale

        protected string nom; // protected rend la variable utilisable dans les classes dérivées (ou enfants)
        protected int age;
        string emploi;

        protected int numeroPersonne;


        public Personne(string nom, int age, string emploi = null) // ici est le second nom de la ligne suivante // ICI est le constructeur, on y passe les paramètres nom age emploi.
        {
            this.nom = nom; // this permet d'éviter les confusions, fait référence à l'objet courant
            this.age = age;
            this.emploi = emploi;

            nombreDePersonnes++;
            this.numeroPersonne = nombreDePersonnes;
        }

        public virtual void Afficher() // On fait en sorte qu'une personne puisse s'afficher, Afficher() est donc une méthode de personne, une action.
        { // le virtual signifie que quand on appelle la méthode Afficher, c'est le code ci-dessous qui peut être appliquer ou un autre, qui viendrait d'une autre fonction afficher dans une classe enfant
            AfficherNomEtAge();
            if (emploi == null)
            {
                Console.WriteLine(" Aucun emploi spécifié");
            }
            else
            {
                Console.WriteLine(" EMPLOI : " + emploi);
            }

        }

        protected void AfficherNomEtAge()
        {
            Console.WriteLine("PERSONNE N° " + numeroPersonne);
            Console.WriteLine("NOM : " + nom); // ici le this est implicit
            Console.WriteLine(" AGE : " + age + " ans");
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
            /*Personne personne1 = new Personne("Paul", 30);
            personne1.Afficher();*/

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

            // var personne1 = new Personne { nom = "Paul", age=30, emploi = "Ingénieur" };

            var professeur = new Personne("Jacques", 36, "Professeur");

            var etudiant = new Etudiant("David", 20, "école d'ingénieur informatique") {
                professeurPrincipal = professeur
            };
            

            etudiant.Afficher();

            var notesEnfant1 = new Dictionary<string, float>
            {
                { "Maths", 5f }, { "Geo", 8.5f }, { "Dictée", 3.3f }
            };

            var enfant = new Enfant("Sophie", 7, "CP", notesEnfant1)
            {
                professeurPrincipal = professeur
            };
            enfant.Afficher();
            
        }
    }
}