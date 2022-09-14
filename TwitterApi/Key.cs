using System;
using System.Text;
using System.Web;

namespace TwitterApi
{
    public abstract class Key : ConsumerKeys
    {
        protected internal readonly string EncodedKey;
        public Models.TwitterApi.Token Token;

        public Key()
        {
            string urlEncodedKey = $"{HttpUtility.UrlEncode(ApiKey)}{":"}{HttpUtility.UrlEncode(ApiSecretKey)}";
            byte[] bytes = Encoding.UTF8.GetBytes(urlEncodedKey);
            EncodedKey = Convert.ToBase64String(bytes);
        }
    }
}
