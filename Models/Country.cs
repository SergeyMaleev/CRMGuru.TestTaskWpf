﻿
using System.ComponentModel.DataAnnotations;

namespace CRMGuru.TestTaskWpf.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название страны
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код страны
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Столица
        /// </summary>
        public City Сapital { get; set; }

        /// <summary>
        /// Площадь
        /// </summary>
        public double Area { get; set; }

        /// <summary>
        /// Население
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        public Region Region { get; set; }
    }
}
