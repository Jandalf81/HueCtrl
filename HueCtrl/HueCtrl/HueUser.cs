using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HueCtrl
{
    internal class HueUser
    {
        private string name;
        private string clientKey;

        public HueUser(string name, string clientKey)
        {
            this.name = name;
            this.clientKey = clientKey;
        }

        public string getName() 
        { 
            return name; 
        }
    }
}
