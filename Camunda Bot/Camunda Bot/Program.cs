using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CamundaBot
{


    class CamundaBot
    {
        private string definitionKey, definitionID, json;
        private HttpClient client;


        public CamundaBot(string definitionKey, string definitionID, string json)
        {
            this.definitionID = definitionID;
            this.definitionKey = definitionKey;
            this.json = json;
            this.client = new HttpClient();
        }

        public async Task<string> StartProcess()
            // Start the process of the CamundaBot using the stored processId and json
        {
            string url = "http://localhost:8080/engine-rest/process-definition/key/" + this.definitionKey + "/start";

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            
            // Send the POST message to Camunda to start the process
            HttpResponseMessage response = await this.client.PostAsync(url, data);

            
            string result = response.Content.ReadAsStringAsync().Result;

            return result;
        }

        public async Task<string> GetActivities()
        {
            string url = "http://localhost:8080/engine-rest/history/activity-instance?processDefinitionId=" + this.definitionID;

            HttpResponseMessage response = await this.client.GetAsync(url);

            string activities = response.Content.ReadAsStringAsync().Result;

            return activities;
        }

    
    }

    class Program
    {

        static async Task Main(string[] args)
        {
            string definitionKey = "sequence";
            string definitionID = "sequence:1:cf32a197-5dbf-11ea-a86b-00d86175334f";
            string json = "";
            CamundaBot sequenceBot = new CamundaBot(definitionKey, definitionID, json);


            // This should print the response from Camunda, Just like what is returned to Postman.
            string result = await sequenceBot.StartProcess();
            Console.WriteLine(result);

            string activities = await sequenceBot.GetActivities();
            Console.WriteLine(activities);

            
        }
    }
}
