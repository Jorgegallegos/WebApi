using MajeBug.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajeBud.Data.Repositories
{

    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(DataContext context) : base(context)
        {
            
        }
    }

}
