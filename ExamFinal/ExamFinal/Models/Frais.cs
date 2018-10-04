using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamFinal.Models
{
    public class Frais
    {


        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Nom { get; set; }


        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Prenom { get; set; }


        [Required(ErrorMessage = "Le date est obligatoire")]
        public string Date { get; set; }


        [Range(5, 200)]
        public int Kilometre { get; set; }



        public string Ville { get; set; }


        [Range(0,Double.MaxValue)]
        public double FraisDeResturant { get; set; }

        [Required(ErrorMessage = "Le code postal est obligatoire")]
        public string CodePostal { get; set; }

        [EmailAddress]
        public string Courriel { get; set; }


        public Frais(string v1, string v2, string v3, int v4, string v5, double v6, string v7, string v8)
        {
            this.Nom = v1;
            this.Prenom = v2;
            this.Date = v3;
            this.Kilometre = v4;
            this.Ville = v5;
            this.FraisDeResturant = v6;
            this.CodePostal = v7;
            this.Courriel = v8;
        }


    }
}