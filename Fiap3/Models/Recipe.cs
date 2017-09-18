using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap3.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Prepare { get; set; }
        public string Secret { get; set; }
    }
    public class RecipeDto :IValidatableObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Prepare { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title.Contains("receita"))
            {
                var result = new ValidationResult("o titulo de sua receita nao pode ter o texto Receita", new[] { nameof(Title) });
                yield return result;
            }
        }
    }
}
