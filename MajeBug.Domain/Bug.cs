using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajeBug.Domain
{
    public class Bug
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Body{ get; set; }
        public bool IsFixed { get; set; }
        public string StepsToReproduce { get; set; }    
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt{ get; set; }
        //created by tracking
        public string CreatedById { get; set; }
        public User CreatedBy { get; set; }
        //modified by tracking
        public string ModfiedById { get; set; }
        public User ModifiedBy { get; set; }
        //severity
        public Severity Severity { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
