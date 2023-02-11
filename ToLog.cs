﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_Appointment
{
    public static class ToLog
    {
        private static string fileName = "AppointmentLogger.txt";

        public static void logActivity()
        {
            bool fileExistence = false;
            string previousFile = "";

            try
            {
                FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader fileReader = new StreamReader(input);
                previousFile = fileReader.ReadToEnd().Trim();
                input.Close();
            }
            catch (IOException)
            {
                fileExistence = true;
            }
            finally
            {
                FileStream output = new FileStream(fileName, FileMode.Create);
                StreamWriter fileWriter = new StreamWriter(output);
                string currentLog = $"The user\"{DBconnection.GetUserID()}\" logged " +
                    $"in on {DateTime.Now.ToUniversalTime()} (EST).";

                if (fileExistence)
                {
                    fileWriter.WriteLine(currentLog);
                    fileWriter.Close();
                }
                else
                {
                    fileWriter.WriteLine(previousFile);
                    fileWriter.WriteLine(currentLog);
                    fileWriter.Close();
                }
            }
        }
    }
}