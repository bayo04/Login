using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Models
{
    // model klasa za korisnika, sadrži sol i hash za sva 3 načina hashiranja
    public class User
    {
        public string UserName { get; set; }

        public string PwdHash { get; set; }

        public string PwdHashSalt { get; set; }

        public string Salt { get; set; }

        public string PwdHashPepper { get; set; }
    }
}
