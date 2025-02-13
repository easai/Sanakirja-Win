using System.IO;
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

    /// <summary>
    /// Represents a book that fetches random words from an API.
    /// </summary>
    class Kirja
    {

        string url = "http://sanakirja.pythonanywhere.com/api";

        /// <summary>
        /// Fetches a random word asynchronously.
        /// </summary>
        /// <param name="n">The number of random words to fetch.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="Sana"/> object.</returns>
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
/*
            if (answer.expression == "")
            {
                string server = "localhost";
                string database = "danish";
                string user = "";
                string pass = "";

                string myConnectionString = string.Format(
                    "Server={0};Database={1};Uid={2};Pwd={3}",
                    server,
                    database,
                    user,
                    pass);
                using (var connection = new MySqlConnection(myConnectionString))
                {
                    try
                    {
                        connection.Open();
                        var cmd = connection.CreateCommand();
                        cmd.CommandText = $"Select * From dictionary";
                        var dataAdapter = new MySqlDataAdapter(cmd);
                        var dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        this.dataGridView1.DataSource = dataTable;
                        connection.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error : " + e.Message);
                    }
                }
            }
*/
            Sana sana = new Sana(answer.expression, answer.description);
            return sana;
        }
    }
}
