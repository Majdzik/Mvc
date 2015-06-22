using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajdzikMvc.Models
{
    interface IEntry<T>
    {
        T Id { get; set; } 
    }

    public abstract class AEntry<T> : IEntry<T>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
    }

    public class Language:AEntry<int>
    {
       
        public CultureInfo Culture { get; set; }
        [Index("IX_FirstNameLastName", 1, IsUnique = true)]
        public dynamic Name { get; set; }
        public DateTime DueDate { get; set; }
     
    }
}


