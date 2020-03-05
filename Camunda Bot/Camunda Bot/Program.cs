using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace CamundaBot
{


    class Activity
    {
        public string id { get; set; }
        public string parentActivityInstanceId { get; set; }
        public string activityId { get; set; }
        public string activityName { get; set; }
        public string activityType { get; set; }
        public string processDefinitionKey { get; set; }
        public string processDefinitionId { get; set; }
        public string processInstanceId { get; set; }
        public string executionId { get; set; }
        public string taskId { get; set; }
        public string calledProcessInstanceId { get; set; }
        public string calledCaseInstanceId { get; set; }
        public string assignee { get; set; }
        public string canceled { get; set; }
        public string completeScope { get; set; }
        public string tenantId { get; set; }
        public string removalTime { get; set; }
        public string rootProcessInstanceId { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int durationInMillis { get; set; }
    }




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

        public async Task<List<Activity>> GetActivities()
        {
            string url = "http://localhost:8080/engine-rest/history/activity-instance?processDefinitionId=" + this.definitionID;

            HttpResponseMessage response = await this.client.GetAsync(url);

            string[] activities = Regex.Matches(response.Content.ReadAsStringAsync().Result, @"{[^{}]*}")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();

            List<Activity> activityList = new List<Activity>();

            
            foreach (string activity in activities)
            {
                activityList.Add(JsonConvert.DeserializeObject<Activity>(activity));
            }
            

            return activityList;
        }


        
    
    }

    class Program
    {

        static async Task Main(string[] args)
        {
            // ******* The parameters need to be configured correctly before running the bot *******

            // The definition key of the process.
            string definitionKey = "sequence";

            // The definition ID for your deployment of the process in Camunda.
            string definitionID = "sequence:1:56ede483-5de0-11ea-a86b-00d86175334f";
            string json = "";

            // Building the CamundaBot using the parameters above.
            CamundaBot sequenceBot = new CamundaBot(definitionKey, definitionID, json);


            // This should print the response from Camunda, Just like what is returned to Postman.
            //string result = await sequenceBot.StartProcess();
            //Console.WriteLine(result);

            List<Activity> activities = await sequenceBot.GetActivities();
            

            Console.WriteLine(activities[6].activityName);



            
        }
    }
}
