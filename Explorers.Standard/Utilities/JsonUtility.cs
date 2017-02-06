using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;

namespace WowDotNetAPI.Utilities
{
    public static class JsonUtility
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static string GetJSON(string url)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, url);
            return GetJSON(req);
        }

        public static string GetJSON(HttpRequestMessage req)
        {
            try
            {
                var res = HttpClient.SendAsync(req).Result;

                StreamReader streamReader = new StreamReader(res.Content.ReadAsStreamAsync().Result, Encoding.UTF8);
                return streamReader.ReadToEnd();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //JSON serialization - http://www.joe-stevens.com/2009/12/29/json-serialization-using-the-datacontractjsonserializer-and-c/
        public static T FromJSON<T>(string url) where T : class
        {
            var req = new HttpRequestMessage(HttpMethod.Get, url);
            return FromJSON<T>(req);
        }

        public static T FromJSON<T>(HttpRequestMessage req) where T : class
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(GetJSON(req))))
            {
                DataContractJsonSerializer DataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
                return DataContractJsonSerializer.ReadObject(stream) as T;
            }
        }

        public static T FromJSON<T>(string url, string publicAuthKey, string privateAuthKey) where T : class
        {
            var req = new HttpRequestMessage(HttpMethod.Get, url);
            DateTime date = DateTime.Now.ToUniversalTime();

            string stringToSign = 
                req.Method + "\n"
                + date.ToString("r") + "\n"
                + req.RequestUri.AbsolutePath + "\n";

            byte[] buffer = Encoding.UTF8.GetBytes(stringToSign);

            HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(privateAuthKey));

            string signature = Convert.ToBase64String(hmac.ComputeHash(buffer));

            req.Headers.Authorization = new AuthenticationHeaderValue("BNET" + publicAuthKey, "signature");

            return FromJSON<T>(req);
        }

        public static string ToJSON<T>(T obj) where T : class
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer DataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));

                DataContractJsonSerializer.WriteObject(stream, obj);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static T FromJSONStream<T>(StreamReader sr) where T : class
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(sr.ReadToEnd())))
            {
                DataContractJsonSerializer DataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
                return DataContractJsonSerializer.ReadObject(stream) as T;
            }
        }

        public static T FromJSONString<T>(string str) where T : class
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                DataContractJsonSerializer DataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
                return DataContractJsonSerializer.ReadObject(stream) as T;
            }
        }

    }
}
