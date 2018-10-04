using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamFinal.Models
{
    public class Frais
    {
        private string v1;
        private string v2;
        private string v3;
        private int v4;
        private string v5;
        private double v6;
        private string v7;
        private string v8;

        public Frais(string v1, string v2, string v3, int v4, string v5, double v6, string v7, string v8)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
            this.v7 = v7;
            this.v8 = v8;
        }

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


    }
}