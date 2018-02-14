using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajeBug.Domain
{
    public class User
    {
        public string Id { get; set; }
        public DateTime CreatedAd { get; set; }
        public string  DisplayName { get; set; }

        public DateTime? BirthDate { get; set; }

    }
}
