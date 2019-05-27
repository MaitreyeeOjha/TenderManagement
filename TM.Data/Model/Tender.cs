using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TM.Data
{
    [Table("Tender")]
    public class Tender
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public int TenderId { get; set; }

        [StringLength(100, ErrorMessage = "Title should be within 100 characters")]
        [Required(ErrorMessage = "Tender title is required")]
        [JsonProperty("title")]
        public string Title { get; set; }

        [StringLength(100, ErrorMessage = "Reference Number should be within 100 characters")]
        [Required(ErrorMessage = "Tender Reference Number is required")]
        [JsonProperty("referenceNumber")]
        public string ReferenceNumber { get; set; }

        [Required(ErrorMessage = "Tender Release Date is required")]
        [CurrentDateAttribute(ErrorMessage = "Tender Release date should be a future date")]
        [JsonProperty("releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Tender Closing Date is required")]
        [CurrentDateAttribute(ErrorMessage = "Tender Closing date should be a future date")]
        [JsonProperty("closingDate")]
        public DateTime ClosingDate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createdBy")]
        public User CreatedBy { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ReleaseDate < ClosingDate)
            {
                yield return
                  new ValidationResult(errorMessage: "Closing Date must be greater than Release Date",
                                       memberNames: new[] { "Closing Date" });
            }
        }
    }
}
