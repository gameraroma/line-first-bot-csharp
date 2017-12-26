using System;
using System.Security.Cryptography;
using System.Text;

namespace first.line.chatbot.LineMessaging
{
    internal static class ValidateSignature
    {
        internal static bool IsSignatureValid(string channelSecret, string body, string lineSignature)
        {
            string signature;

            var encoding = new ASCIIEncoding();
            var keyByte = encoding.GetBytes(channelSecret);
            var messageByte = encoding.GetBytes(body);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageByte);
                signature = Convert.ToBase64String(hashmessage);
            }

            var isValid = signature == lineSignature;
            return isValid;
        }
    }
}
