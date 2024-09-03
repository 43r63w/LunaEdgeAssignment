using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaTask.BLL.Hasher
{
    public static class HashPassword
    {
        public static string Hash(string password)
            => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public static bool CheckPasswordHash(string textPassword, string hashPassword)
            => BCrypt.Net.BCrypt.EnhancedVerify(textPassword, hashPassword);
    }
}
