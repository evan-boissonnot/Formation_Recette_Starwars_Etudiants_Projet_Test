//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StarWars.JediFollowing.Web.UI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Padawann
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> PlanetId { get; set; }
        public int LevelValue { get; set; }
    
        public virtual Planet Planet { get; set; }
    }
}