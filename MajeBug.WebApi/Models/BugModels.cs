using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MajeBug.WebApi.Models
{
    /// <summary>
    /// this class is a model for bug
    /// </summary>
    public class BugApi
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Body { get; set; }
        [Required]
        public bool IsFixed { get; set; }
        public string StepsToReproduce { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        //created by tracking
        public string CreatedById { get; set; }
        public UserApi CreatedBy { get; set; }
        //modified by tracking
        public string ModfiedById { get; set; }
        public UserApi ModifiedBy { get; set; }
        //severity
        public int Severity { get; set; }
        public byte[] RowVersion { get; set; }

    }

    /// <summary>
    /// this class is a model for user
    /// </summary>
    public class UserApi
    {
        public string Id { get; set; }
        public DateTime CreatedAd { get; set; }
        public string DisplayName { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    public class CreateBugApi
    {
        [Required]
        [MaxLength(120)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Body { get; set; }
        [Required]
        public bool IsFixed { get; set; }
        public string StepsToReproduce { get; set; }
        public int Severity { get; set; }
    }
}