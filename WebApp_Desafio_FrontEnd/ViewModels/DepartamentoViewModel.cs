﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace WebApp_Desafio_FrontEnd.ViewModels
{
    [DataContract]
    public class DepartamentoViewModel
    {
        [Display(Name = "ID")]
        [DataMember(Name = "ID")]
        public int ID { get; set; }

        
        [Display(Name = "Descricao")]
        [DataMember(Name = "Descricao")]
        [Required(ErrorMessage = "A Descricao é obrigatória")]
        [MaxLength(255, ErrorMessage = "A descrição pode ter no máximo 255 caracteres.")]
        public string Descricao { get; set; }

    }
}
