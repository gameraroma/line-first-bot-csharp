using System;
using System.Security.Cryptography;
using System.Text;

namespace first.line.chatbot.LineMessaging
{
    internal static class ValidateSignature
    {
        /// <summary>
        /// The signature in the X-Line-Signature request header must be verified to confirm that the request was sent from the LINE Platform.
        /// Authentication is performed as follows.
        /// 1. With the channel secret as the secret key, your application retrieves the digest value in the request body created using the HMAC-SHA256 algorithm.
        /// 2. The server confirms that the signature in the request header matches the digest value which is Base64 encoded
        /// https://developers.line.me/en/docs/messaging-api/reference/#signature-validation
        /// </summary>
        /// <param name="channelSecret">ChannelSecret</param>
        /// <param name="requestBody">RequestBody</param>
        /// <param name="lineSignature">X-Line-Signature header</param>
        /// <returns></returns>
        internal static bool IsSignatureValid(string channelSecret, string requestBody, string lineSignature)
        {
            string signature;

            var encoding = new ASCIIEncoding();
            var keyByte = encoding.GetBytes(channelSecret);
            var messageByte = encoding.GetBytes(requestBody);
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
