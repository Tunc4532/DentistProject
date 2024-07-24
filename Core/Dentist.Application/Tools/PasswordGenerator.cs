using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Tools
{
    public static class PasswordGenerator
    {
        public static string GeneratePassword()
        {
            StringBuilder sb = new();
            for (int i = 0; i < 8; i++)
            {
                var rnd = new Random();
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rnd.NextDouble() + 65)));
                sb.Append(ch);
            }
            return sb.ToString();
        }
    }
}
