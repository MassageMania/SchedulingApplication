using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_Appointment
{
    static class Program
    {
        /// <summary>
        /// 
        /// Assment Rubric : 
        /// The main entry point for the application.
        ///  
        /// A.   Create a log-in form that can determine the user’s location and translate log-in and error control messages (e.g., “The username and password did not match.”) into the user’s language and in one additional language.
        ///     -Log In.cs
        ///     -two languages log in dependent on iso
        ///     -Invalid Message (18-19 + 32-33) and execution with Log in Button.
        ///     
        /// B.Provide the ability to add, update, and delete customer records in the database, including name, address, and phone number.
        ///     -CustomerRecords.cs
        ///     ** I chose this one page because it seems to flow better in terms of screen space. **
        ///
        /// C.Provide the ability to add, update, and delete appointments, capturing the type of appointment and a link to the specific customer record in the database.
        ///     -Appointments.cs
        ///     -AddAppointsments.cs
        ///     -DeleteAppointments.cs
        ///     -ModifyAppointments.cs
        ///     ** I chose this one page because it was in my opinion A LOT of data being thrown around so more pages made sense to compartmentalize the data. **
        /// 
        /// D.Provide the ability to view the calendar by month and by week.
        ///     -Appointments.cs 
        ///     ** 3 Views of appointments Week, Month, and All.  Theres also a DTP which can be used to select dates months out **
        /// 
        /// E.Provide the ability to automatically adjust appointment times based on user time zones and daylight-saving time
        ///    - AddAppointments.cs  Upon Add appointments are converted to UTC, the creation and updates to the table are based in User Time Zones.
        /// 
        /// F.Write exception controls to prevent each of the following.You may use the same mechanism of exception control more than once, but you must incorporate at least two different mechanisms of exception control.
        ///  
        /// •   scheduling an appointment outside business hours
        ///    - AddAppointments.cs - Lines 218-237 
        ///    - ModifyAppointments.cs - Lines 324  - 333
        ///    
        /// •   scheduling overlapping appointments  
        ///   
        ///    - AddAppointments.cs - Lines 158 - 198 
        ///    - ModifyAppointments.cs - Lines 266 - 306
        /// 
        /// •   entering nonexistent or invalid customer data
        ///    - CustomerRecods.cs  Lines 72 through ~110
        ///    - ModifyAppointments.cs Lines 52 - 133
        ///    - Add Appointments Lines 64-131
        /// 
        /// •   entering an incorrect username and password
        ///     - Works
        ///     
        /// G.Write two or more lambda expressions to make your program more efficient, justifying the use of each lambda expression with an in-line comment.
        ///     - ModifyAppointments.cs  ** Lines 335 -337    &  Lines 360-362 **
        ///     - Add Appointments.cs  ** Lines  229-231  **
        /// 
        /// H.Write code to provide reminders and alerts 15 minutes in advance of an appointment, based on the user’s log-in.
        ///    -Log In.cs **  Line 109-141 **
        ///    
        /// I.Provide the ability to generate each of the following reports using the collection classes:
        ///    •   number of appointment types by month
        ///         Reports.cs ** The Type Report button  as a DISTINCT report**
        ///    •   the schedule for each consultant
        ///         Reports.cs ** Consultant Report button **
        ///    •   one additional report of your choice
        ///         Reports.cs  ** Customer Report button - Reports a list of all appointments for a specific customer. **
        /// 
        /// J.Provide the ability to track user activity by recording timestamps for user log-ins in a.txt file.Each new record should be appended to the log file if the file already exists.
        ///    - Log In.cs ** Lines 52 - 82 **
        /// 
        /// K.Demonstrate professional communication in the content and presentation of your submission.
        /// 
        /// 
        /// 
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBconnection.startConnection();
            Application.Run(new LogIn());
            Application.Exit();
            DBconnection.closeConnection();
        }
    }
}
