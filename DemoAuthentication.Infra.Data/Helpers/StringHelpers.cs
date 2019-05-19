using System;
using System.Security.Cryptography;
using System.Text;

namespace DemoAuthentication.Infra.Data.Helpers
{
    public static class StringHelpers
    {
        public static string Encrypt(this string senha)
        {
            var salt ="|D6AE17249253490FB0507476557634BB5FCB05825A0C4351B31803D03E24A18C";
            var arryBytes = Encoding.UTF8.GetBytes(senha + salt);

            byte[] hasBytes;

            using (var sha = SHA512.Create())
            {
                hasBytes = sha.ComputeHash(arryBytes);
            }
            return Convert.ToBase64String(hasBytes);
        }
    }
}
