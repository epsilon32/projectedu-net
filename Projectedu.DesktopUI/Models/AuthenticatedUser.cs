using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectedu.DesktopUI.Models
{
    public class AuthenticatedUser
    {

        public string Token { get; set; }
        public string Username { get; set; }
        public int Id { get; set; }
        
        // TODO add other properties
    }
}
