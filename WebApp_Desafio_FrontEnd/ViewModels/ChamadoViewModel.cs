﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace WebApp_Desafio_FrontEnd.ViewModels
{
    [DataContract]
    public class ChamadoViewModel
    {
        private CultureInfo ptBR = new CultureInfo("pt-BR");

        [Display(Name = "ID")]
        [DataMember(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Assunto")]
        [DataMember(Name = "Assunto")]
        [Required(ErrorMessage = "O Assunto é obrigatório")]
        [MaxLength(255, ErrorMessage = "A descrição pode ter no máximo 255 caracteres.")]
        public string Assunto { get; set; }

        [Display(Name = "Solicitante")]
        [DataMember(Name = "Solicitante")]
        [Required(ErrorMessage = "O Solicitante é obrigatório")]
        [MaxLength(70, ErrorMessage = "A descrição pode ter no máximo 70 caracteres.")]
        public string Solicitante { get; set; }

        [Display(Name = "IdDepartamento")]
        [DataMember(Name = "IdDepartamento")]
        [Required(ErrorMessage = "O Departamento é obrigatório")]
        public int IdDepartamento { get; set; }

        [Display(Name = "Departamento")]
        [DataMember(Name = "Departamento")]
        public string Departamento { get; set; }

        [Display(Name = "DataAbertura")]
        [DataMember(Name = "DataAbertura")]
        public DateTime DataAbertura { get; set; }

        [DataMember(Name = "DataAberturaWrapper")]
        public string DataAberturaWrapper
        {
            get
            {
                return DataAbertura.ToString("d", ptBR);
            }
            set
            {
                DataAbertura = DateTime.Parse(value, ptBR);
            }
        }
    }
}
