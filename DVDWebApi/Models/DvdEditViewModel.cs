using DVDWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace DVDWebApi.UI.Models
{
    public class DvdEditViewModel
    {
        public Dvd Dvd { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Dvd.Title))
            {
                errors.Add(new ValidationResult("Title Required"));
            }
            if (string.IsNullOrEmpty(Dvd.Director))
            {
                errors.Add(new ValidationResult("Director Required"));
            }
            if (string.IsNullOrEmpty(Dvd.Rating))
            {
                errors.Add(new ValidationResult("Rating Required"));
            }
            if (string.IsNullOrEmpty(Dvd.ReleaseYear.ToString()))
            {
                errors.Add(new ValidationResult("Release Year Required"));
            }
            if (string.IsNullOrEmpty(Dvd.Notes))
            {
                errors.Add(new ValidationResult("Notes Required"));
            }

            /*if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

                var extension = Path.GetExtension(ImageUpload.FileName);

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, png, gif, or jpeg."));
                }
            }*/

            return errors;
        }
    }
}