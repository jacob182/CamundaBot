using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace CamundaBotForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            if (fbd.ShowDialog() == DialogResult.OK)
                FilePathLbl.Text = (fbd.SelectedPath);
        }


        [STAThread]
        private async void RunProgramBtn_Click(object sender, EventArgs e)
        {
            // * The definition key and ID are required for the CamundaBot to know which process to work with. *

            // The definition key of the process.
            string definitionKey = DefinitionKeyTxtBox.Text;

            // The definition ID for your deployment of the process in Camunda.
            string definitionID = DefinitionIDTxtBox.Text;

            // The JSON object containing the required variables (Leave blank if none are required)
            string json = JSONTxtBox.Text;

            // Do you want to start the process again? (true/false)
            bool startProcess = StartProcessCheckBox.Checked;
            // if so, how many times?
            int timesStarted = Convert.ToInt32(Math.Round(TimesTxtBox.Value, 0));


            // * Setting the file name and file path for the purpose of saving the returned activities into a csv file *

            // Where do you want to save the file?
            string fileName = FileNameTxtBox.Text;  // the name of the file to be saved.

            string filePath = FilePathLbl.Text; // This is where the file will be saved.

            filePath = filePath + @"\" + fileName + ".csv"; // Joining them together for use.




            // ******* These parameters need to be configured correctly before running the bot *******

            // Building the CamundaBot using the parameters above.
            CamundaBot sequenceBot = new CamundaBot(definitionKey, definitionID, json);


            // Starting the process the required amount of times
            if (startProcess)
            {
                for (int i = 0; i < timesStarted; i++)
                {
                    await sequenceBot.StartProcess();
                }
            }



            // Create a list of the Activities from Camunda using the GetActivities function
            List<Activity> activities = await sequenceBot.GetActivities();


            // Store the list of activities as a csv file.

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(activities);
            }

            // Displays success label
            SuccessLbl.Visible = true;
        }

    }
}
