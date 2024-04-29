using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Runtime.ExceptionServices;
using BlazorSignalRBelgianCavesRegister.Client.Models;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.Questionners
{
    public partial class CaveQuestionner
    {
        [Inject]
        List<Question> Questions { get; set; } = new List<Question>()
        {
            new Question
            {
                Enonce = "Y a t'il 75 grottes répertoriées en Belgique ?",
                Response = true
            },
            new Question
            {
                Enonce = "Les Grottes de Han sont elles les plus courtes de Belgique ?",
                Response = false
            },
            new Question
            {
                Enonce = "Le Trou Bernard est il le gouffre le plus profond de Belgique avec 140 m ?",
                Response = true
            },
            new Question
            {
                Enonce = "Le Trou d'Aquin est-il la grotte non aménagée la plus fréquentée de Belgique ?",
                Response = true
            },
            new Question
            {
                Enonce = "La lune est-elle une planète ?",
                Response = false
            },
            new Question
            {
                Enonce = "(pour certains) Les Grottes de Han, sont elles les plus belles d'Europe ?",
                Response = true
            },
            new Question
            {
                Enonce = "Une stalagtite est elle une concrétions pendue au plafond ?",
                Response = true
            },
            new Question
            {
                Enonce = "Charle Martel est il vraiment venu en Belgique ?",
                Response = true
            },
            new Question
            {
                Enonce = "Est ce lui qui à découvert le passage de la Boite Aux Lettres (de sinistres mémoire(pour les débutants ;-) )) au Trou d'Aquin ?",
                Response = true
            },
            new Question
            {
                Enonce = "Les chauves-souris s'attaquent elles à l'homme ?",
                Response = false
            },
            new Question
            {
                Enonce = "Le poisson peut-il voler ?",
                Response = false
            },
            new Question
            {
                Enonce = "Les humains peuvent-ils respirer sous l'eau ?",
                Response = false
            },
            new Question
            {
                Enonce = "La France est-elle une république ?",
                Response = true
            },
            new Question
            {
                Enonce = "Les oiseaux ont-ils des dents ?",
                Response = false
            },
            new Question
            {
                Enonce = "La glace est-elle faite d'eau ?",
                Response = true
            },
            new Question
            {
                Enonce = "L'ordinateur fonctionne-t-il grâce à l'électricité ?",
                Response = true
            },
            new Question
            {
                Enonce = "La musique a-t-elle un effet sur l'humeur ?",
                Response = true
            },
            new Question
            {
                Enonce = "Les poissons respirent-ils sous l'eau ?",
                Response = true
            },
            new Question
            {
                Enonce = "Le chien est-il un mammifère ?",
                Response = true
            },
            new Question
            {
                Enonce = "Le fer est-il un gaz ?",
                Response = false
            },
            new Question
            {
                Enonce = "Le plastique est-il biodégradable ?",
                Response = false
            },
            new Question
            {
                Enonce = "La gravité maintient-elle les objets au sol ?",
                Response = true
            },
            new Question
            {
                Enonce = "Les plantes ont-elles besoin de lumière pour pousser ?",
                Response = true
            },
            new Question
            {
                Enonce = "L'eau bout-elle à 100 degrés Celsius ?",
                Response = true
            },
            new Question
            {
                Enonce = "Le soleil tourne-t-il autour de la terre ?",
                Response = false
            },
        };
        public bool QuestionnaireFini
        {
            get
            {
                return Questions.Count <= QuestionActuelle;
            }
        }
        public int BonnesResponses { get; set; }
        public int QuestionActuelle { get; set; } = 0;

        void RecevoirResponse(bool resultat)
        {
            if (resultat)
            {
                BonnesResponses++;
            }
            NextQuestion();
        }
        void NextQuestion()
        {
            QuestionActuelle++;
        }
        void RestartGame()
        {
            QuestionActuelle = 0;
            BonnesResponses = 0;
        }
    }
}
