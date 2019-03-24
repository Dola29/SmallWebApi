using SmallApi.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmallApi.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [FirstLetterUp]
        [StringLength(10, ErrorMessage = "This field should have {1} character")]
        public string Name { get; set; }
        public List<Book> Books { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var firstLeter = Name[0].ToString();

                if (firstLeter != firstLeter.ToUpper())
                {
                    yield return new ValidationResult("The first Letter should be upper case", new string[] { nameof(Name) });
                }
            }
        }
    }
}
