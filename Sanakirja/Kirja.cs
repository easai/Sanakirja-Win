using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


namespace Sanakirja
{
    [DataContract]
    public class Answer
    {
        [DataMember]
        public string expression;
        [DataMember]
        public string description;
        [DataMember]
        public string created_at;
        [DataMember]
        public string id;
        [DataMember]
        public string source;
    }


    class Kirja
    {

        string url = "http://sanakirja.pythonanywhere.com/api";

        public async Task<Sana> nrandAsync(int n)
        {
            Answer answer = new Answer();
            using (var client = new HttpClient())
            {
                var httpsResponse = await client.GetAsync(url + "/rand").ConfigureAwait(false);
                var responseContent = await httpsResponse.Content.ReadAsStringAsync();
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseContent)))
                {
                    var ser = new DataContractJsonSerializer(answer.GetType());
                    answer = ser.ReadObject(ms) as Answer;
                }
            }
            Sana sana = new Sana(answer.expression, answer.description);
            return sana;
        }
    }
}
