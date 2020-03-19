using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using CsvHelper;
using System.Globalization;

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
        // The CamundaBot uses the definition key and ID to tell Camunda which process we are working with.  Each CamundaBot has a HttpClient that it uses to interact with the REST API of Camunda.
        // The defnition key is used to start the process, and the definition ID is used to return the activity data that Camunda stores after starting a process.
      
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
        {
            // This current version of start process assumes you have Camunda running on the local machine, as it uses the localhost address to cammunicate with the REST API.
            // Start the process of the CamundaBot using the stored definitionId and json

            string url = "http://localhost:8080/engine-rest/process-definition/key/" + this.definitionKey + "/start";
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            // Declaring the variables to be used in starting the process
            HttpResponseMessage response = new HttpResponseMessage();
            string result = null;

            // Send the POST message to Camunda to start the process
            try
            {
                response = await this.client.PostAsync(url, data);
            }
            catch (HttpRequestException ex)
            {
                //Console.WriteLine("Error while starting process: No connection to the host could be made. Check the URL is correct, or the host is running.\n");
                throw ex;
            }


            // Retrieve the HTTP response message from Camunda to determine if the process started correctly.
            try
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (NullReferenceException ex)
            {
                //Console.WriteLine("Error while reading response from Camunda: No response has been received from the host.\n");
                throw ex;
            }

            return result;
            
        }











        public async Task<List<Activity>> GetActivities()
        {
            // 
            string url = "http://localhost:8080/engine-rest/history/activity-instance?processDefinitionId=" + this.definitionID;



            HttpResponseMessage response = null;
            
            // Retrieve the activity data from Camunda using a http GET request
            try
            {
                response = await this.client.GetAsync(url);
            }
            catch (HttpRequestException ex)
            {
                //Console.WriteLine("Error while retrieving activity data: No connection to the host could be made. Check the URL is correct, or the host is running.\n");
                throw ex;
            }


            // Using a Regular Expression to extract the activities as individual activities from the JSON formatted string that Camunda returns, and save it as a string array.
            string[] activities = null;
            try
            {
                activities = Regex.Matches(response.Content.ReadAsStringAsync().Result, @"{[^{}]*}")
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .ToArray();
            }
            catch (NullReferenceException ex)
            {
                //Console.WriteLine("Error while retrieving activity data: No data was received from the host.");
                throw ex;
            }




            // Using JSONConvert to deserialise the array of activity strings and convert them into Activity class objects and save them in a List.
            List<Activity> activityList = new List<Activity>();
            try
            {
                foreach (string activity in activities)
                {
                    activityList.Add(JsonConvert.DeserializeObject<Activity>(activity));
                }
            }
            catch(NullReferenceException ex) // No activities were retrieved. Create an exception to be handled.
            {
                //Console.WriteLine("Error while retrieving activity data: No data was received from the host.");
                throw ex;
            }
            
            return activityList;
            
        }


        
    
    }

    class Program
    {

        static async Task Main(string[] args)
        {
            // ******* These parameters need to be configured correctly before running the bot *******



            // * The definition key and ID are required for the CamundaBot to know which process to work with. *

            // The definition key of the process.
            string definitionKey = "sequence";

            // The definition ID for your deployment of the process in Camunda.
            string definitionID = "sequence:1:144c9246-6994-11ea-9260-00d86175334f";

            // The JSON object containing the required variables (Leave blank if none are required)
            string json = "{\"variable\": \"aaaa\"}";
            //string json = "";

            // Do you want to start the process again? (true/false)
            bool startProcess = true;
            // if so, how many times?
            int timesStarted = 1;




            // * Setting the file name and file path for the purpose of saving the returned activities into a csv file *

            // The name of the file to be saved.
            string fileName = "testFile";

            // This is where the file will be saved.
            string filePath = @"C:\Users\jralp\Desktop\Jake\Uni work\IFB398 Capstone\CamundaBot Repo\Camunda Bot\CSV files";

            // Joining them together for use.
            filePath = filePath + @"\" + fileName + ".csv";


            // ******* These parameters need to be configured correctly before running the bot *******




            // Building the CamundaBot using the parameters above.
            CamundaBot sequenceBot = new CamundaBot(definitionKey, definitionID, json);


            // Starting the process the required amount of times
            try
            {
                if (startProcess)
                {
                    for (int i = 0; i < timesStarted; i++)
                    {
                        await sequenceBot.StartProcess();
                    }
                }
            }
            catch (HttpRequestException ) // There was a problem connecting with the host.
            {
                Console.WriteLine("Error while starting process: \nNo connection to the host could be made. Check the URL is correct, or the host is running.\n");
            }
            catch (NullReferenceException) // There was no response from the host after connection was made.
            {
                Console.WriteLine("Error while starting process: \nNo response has been received from the host.\n");
            }



            // Create a list of the Activities from Camunda using the GetActivities function
            List<Activity> activities = null;
            try
            {
                activities = await sequenceBot.GetActivities();
            }
            catch (HttpRequestException) // There was a problem connecting with the host.
            {
                Console.WriteLine("Error while retrieving activity data: \nNo connection to the host could be made. Check the URL is correct, or the host is running.\n");
            }
            catch (NullReferenceException) // There was no response from the host after connection was made.
            {
                Console.WriteLine("Error while retrieving activity data: \nNo data was received from the host.\n");
            }




            // Store the list of activities as a csv file.
            StreamWriter writer;
            CsvWriter csv;
            try
            {
                using (writer = new StreamWriter(filePath))

                try
                {
                    using (csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        try
                        {
                            csv.WriteRecords(activities);
                        }
                        catch (CsvHelper.WriterException)
                        {
                            Console.WriteLine("Error saving data: \nNo data retrieved from the host.\n");
                        }

                    }
                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine("Error saving data: \nThere was an issue with the TextWriter.\n");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error while saving data: \nThe file path is incorrect or the file is still in use.\n");
            }




            // Write the name of an activity to the console to test that it worked.
            Console.WriteLine("Program finished.");



            
        }
    }
}
