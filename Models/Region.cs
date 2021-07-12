
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMGuru.TestTask.Interfaces.Models
{
    public class Region
    {
        [Key]
        [ForeignKey("Country")]
        public int Id { get; set; }

        /// <summary>
        /// Название региона
        /// </summary>
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
