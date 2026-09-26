using BenchmarkDotNet.Running;
using ConsoleApp3;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ConsoleApp3
{
   internal class Program
    {
            static void Main(string[] args)
        {
            
            //*****************************************************************Part 1*****************************************************************
            string[] sessionNames =
            {
            "C# Basics",
            "Arrays",
            "Functions",
            "Date and Time",
            "Exception Handling"
            };

            DateTime[] sessionDates =
            {
            new DateTime(2026, 9, 10, 18, 0, 0),
            new DateTime(2026, 9, 13, 18, 0, 0),
            new DateTime(2026, 9, 17, 18, 0, 0),
            new DateTime(2026, 9, 20, 18, 0, 0),
            new DateTime(2026, 9, 24, 18, 0, 0)
            };

            int[] sessionDurations =
            {
            180,
            240,
            180,
            240,
            180
            };
            //*****************************************************************Part 2*****************************************************************
            DisplaySessions(sessionNames, sessionDates, sessionDurations);
            //*****************************************************************Part 3*****************************************************************
            Console.WriteLine("Please, Enter the session name");
            string SessionName = Console.ReadLine();

            int IndexSession = SearchSession(sessionNames, SessionName);
            if (IndexSession < 0)
            {
                Console.WriteLine("Session not found.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Name: {sessionNames[IndexSession]}");
                Console.WriteLine($"Date: {DateOnly.FromDateTime(sessionDates[IndexSession])}");
                Console.WriteLine($"Start time: {TimeOnly.FromDateTime(sessionDates[IndexSession])}");
                Console.WriteLine($"Duration: {sessionDurations[IndexSession]} minutes");
                Console.WriteLine();
            }
            //*****************************************************************Part 4*****************************************************************
            //*****************************************************************4.1*****************************************************************
            string[] SortedSessionNames = new string[sessionNames.Length];
            Array.Copy(sessionNames, SortedSessionNames, sessionNames.Length);
            Array.Sort(SortedSessionNames);
            Console.WriteLine("The Sorted sessionNames is : ");
            foreach (string Names in SortedSessionNames)
            {
                Console.WriteLine(Names);
            }
            Console.WriteLine();
            //*****************************************************************4.2*****************************************************************
            string[] ReversedSessionNames = new string[sessionNames.Length];
            Array.Copy(sessionNames, ReversedSessionNames, sessionNames.Length);
            Array.Reverse(ReversedSessionNames);
            Console.WriteLine("The Reversed sessionNames is : ");
            foreach (string Names in ReversedSessionNames)
            {
                Console.WriteLine(Names);
            }
            Console.WriteLine();
            //*****************************************************************4.3*****************************************************************
            Console.WriteLine("Enter session name : ");
            string SessionName1 = Console.ReadLine();
            Console.WriteLine($"Index: {Array.IndexOf(sessionNames, SessionName1)}");
            Console.WriteLine();
            //*****************************************************************4.4*****************************************************************
            Console.WriteLine("Enter session name : ");
            string SessionName2 = Console.ReadLine();
            Console.WriteLine(Array.Exists(sessionNames, name => name == SessionName2) ? "Session exists." : "Session does not exist.");
            Console.WriteLine();
            //*****************************************************************4.5*****************************************************************
            Console.WriteLine("Enter session name : ");
            SessionName2 = Console.ReadLine();
            string FoundSession = Array.Find(sessionNames, n => n.Equals(SessionName2, StringComparison.OrdinalIgnoreCase));
            if (FoundSession != null)
            {
                Console.WriteLine($"Found session {FoundSession}");
            }
            else
            {
                Console.WriteLine("Session not found.");
            }
            Console.WriteLine();
            //*****************************************************************4.6*****************************************************************
            Console.WriteLine("Enter session name");
            string SessionName3 = Console.ReadLine();
            int index = Array.FindIndex(sessionNames, n => n == SessionName3);
            if (index != -1)
            {
                Console.WriteLine($"Condition met at Index: {index}");
            }
            else
            {
                Console.WriteLine("No session matched the condition.");
            }
            Console.WriteLine();
            //4.7
            string[] CopiedSessionNames = new string[sessionNames.Length];
            Array.Copy(sessionNames, CopiedSessionNames, sessionNames.Length);
            CopiedSessionNames[0] = "C# Basicssss";
            Console.WriteLine("The original array content is :");
            foreach (string name in sessionNames)
            {
                Console.Write($"{name} |");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The Copied array content is :");
            foreach (string name in CopiedSessionNames)
            {
                Console.Write($"{name} |");
            }
            Console.WriteLine();
            Console.WriteLine();
            //***************************************************************** Part 5 *****************************************************************
            Console.WriteLine($"Total Duration: {GetTotalDuration(sessionDurations)} minutes");
            Console.WriteLine($"Average duration: {GetAverageDuration(sessionDurations)} minutes");
            Console.WriteLine($"Shortest duration: {GetShortestDuration(sessionDurations)} minutes");
            Console.WriteLine($"Longest duration: {GetLongestDuration(sessionDurations)} minutes");
            Console.WriteLine();
            int[] SortedDurations = new int[sessionDurations.Length];
            Array.Copy(sessionDurations, SortedDurations, sessionDurations.Length);
            Array.Sort(SortedDurations);
            Console.WriteLine("The Sorted Durations array : ");
            foreach (int D in SortedDurations)
            {
                Console.Write($"{D} |");
            }
            Console.WriteLine();
            Console.WriteLine();
            //*****************************************************************7.1*****************************************************************
            int num1 = 10;
            int num2 = 20;
            Console.WriteLine("The Numbers Value Before using Funcation");
            Console.WriteLine($"Num1 : {num1}");
            Console.WriteLine($"Num2 : {num2}");
            SwapNumbers(ref num1, ref num2);
            Console.WriteLine("The Numbers Value After using Funcation");
            Console.WriteLine($"Num1 : {num1}");
            Console.WriteLine($"Num2 : {num2}");
            Console.WriteLine();
            //*****************************************************************7.2***********************************************************************
            Console.WriteLine("Enter the session name:");
            string SessionName4 = Console.ReadLine();
            int Index = GetIndexFromName(SessionName4, sessionNames, sessionDurations, out int Duration);
            Console.WriteLine($"The name index is: {Index}");
            Console.WriteLine($"The Duration of session is: {Duration}");
            Console.WriteLine();
            //*****************************************************************7.3***********************************************************************
            int[] TestArr = [1, 2, 3, 4, 5, 6];
            Console.WriteLine("The array content before using Function");
            foreach (int item in TestArr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            ChangeArrayContent(TestArr);
            Console.WriteLine("The array content After using Function");
            foreach (int item in TestArr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            //***************************************************************** Part 8 *********************************************************************
            Console.WriteLine(CalculateTotalDuration(120, 120, 240));
            Console.WriteLine(CalculateTotalDuration(120, 120, 240, 360, 140, 250));
            Console.WriteLine(CalculateTotalDuration(120, 120));
            Console.WriteLine();
            //***************************************************************** Part 9 *****************************************************************
            Console.WriteLine("Enter the session name:");
            string sessionname5 = Console.ReadLine();
            DisplayDateDetails(sessionname5, sessionNames, sessionDates, sessionDurations);
            //***************************************************************** Part 10 *****************************************************************
            Console.WriteLine("Enter two session names");
            string sessionname6 = Console.ReadLine();
            string sessionname7 = Console.ReadLine();
            CompareSessionDates(sessionname6, sessionname7, sessionNames, sessionDates);
            Console.WriteLine();
            //***************************************************************** Part 11 *****************************************************************
            CompareSessionsDatesWithNow(sessionNames, sessionDates);
            Console.WriteLine();
            //***************************************************************** Part 12 *****************************************************************
            Console.WriteLine("Enter the session Name");
            string sessionname8 = Console.ReadLine();
            FindTheNextSession(sessionNames, sessionDates, sessionDurations);
            //***************************************************************** Part 13 *****************************************************************
            DateTime TempDate = sessionDates[1];
            Console.WriteLine("The date formatting: ");
            Console.WriteLine(TempDate.ToString("yyyy-MM-dd"));
            Console.WriteLine(TempDate.ToString("dd/MM/yyyy"));
            Console.WriteLine(TempDate.ToString("dd MMMM yyyy"));
            Console.WriteLine(TempDate.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(TempDate.ToString("hh:mm tt"));
            Console.WriteLine();
            //***************************************************************** Part 14 *****************************************************************
           Console.WriteLine(CheckDateFormat().ToString("yyyy-MM-dd HH:mm"));
            Console.WriteLine();
            //***************************************************************** Part 15 *****************************************************************
            Console.WriteLine($"the Convert number is: {GetMenuOption()}");
            Console.WriteLine();
            //***************************************************************** Part 16 *****************************************************************
            Console.WriteLine("Enter session index: ");
            int num = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(sessionNames[num]);
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("The selected session index is out of range.");
            }
            Console.WriteLine();
            //***************************************************************** Part 17 *****************************************************************
            try
            {
                ChechDurationValidation();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}\n");
            }
            //***************************************************************** Part 18 *****************************************************************
            Console.WriteLine("Enter session index: ");
            int number = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(sessionNames[number]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The selected session index is out of range.");
            }
            finally
            {
                Console.WriteLine("Input operation finished.");
            }
            Console.WriteLine();
            //***************************************************************** Part 19 *****************************************************************
            string scheduleReport1 = SchuduleReportUsingString(sessionNames, sessionDates, sessionDurations);
            Console.WriteLine("The schedule report using string :");
            Console.WriteLine(scheduleReport1);
            //***************************************************************** Part 20 *****************************************************************
            string scheduleReport2 = SchuduleReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations);
            Console.WriteLine("The schedule report using stringbuilder :");
            Console.WriteLine(scheduleReport2);
            //***************************************************************** Benchmark Part *****************************************************************
            BenchmarkRunner.Run<StringBenchmark>();
            //***************************************************************** Console Menu ******************************************************************
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("===================================\r\n" +
               "Academy Schedule Analyzer\r\n" +
               "===================================\r\n" +
               "1.  Display all sessions\r\n" +
               "2.  Search for a session\r\n" +
               "3.  Sort session names\r\n" +
               "4.  Reverse session names\r\n" +
               "5.  Find session index\r\n" +
               "6.  Check if session exists\r\n" +
               "7.  Show duration statistics\r\n" +
               "8.  Show session date details\r\n" +
               "9.  Show past and upcoming sessions\r\n" +
               "10. Find next session\r\n" +
               "11. Compare two session dates\r\n" +
               "12. Read and validate a custom date\r\n" +
               "13. Select session by index\r\n" +
               "14. Validate session duration\r\n" +
               "15. Generate report using string\r\n" +
               "16. Generate report using StringBuilder\r\n" +
               "0.  Exit\r\n" +
               "Choose an option:/n");
                int option = GetMenuOption(); 
                Console.WriteLine();

                switch (option)
                {
                    case 1:
                        DisplaySessions(sessionNames, sessionDates, sessionDurations);
                        break;

                    case 2:
                        Console.Write("Enter session name to search: ");
                        string searchName = Console.ReadLine();
                        int foundIndex = SearchSession(sessionNames, searchName);
                        if (foundIndex != -1)
                        {
                            DisplaySessionDetails(foundIndex, sessionNames, sessionDates, sessionDurations);
                        }
                        else
                        {
                            Console.WriteLine("Session not found.\n");
                        }
                        break;

                    case 3:
                   
                        string[] sortedNames =new string[sessionNames.Length];
                        Array.Copy(sessionNames,sortedNames,sessionNames.Length);
                        Array.Sort(sortedNames);
                        Console.WriteLine("Sorted Session Names:");
                        foreach (string name in sortedNames)
                        {
                            Console.WriteLine($"- {name}");
                        }
                        Console.WriteLine();
                        break;

                    case 4:
                        string[] reversedNames = new string[sessionNames.Length];
                        Array.Copy(sessionNames, reversedNames, sessionNames.Length);
                        Array.Reverse(reversedNames);
                        Console.WriteLine("Reversed Session Names:");
                        foreach (string name in reversedNames)
                        {
                            Console.WriteLine($"- {name}");
                        }
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.Write("Enter session name to find its index: ");
                        string nameForIndex = Console.ReadLine();
                        try
                        {
                            int idx = GetIndexFromName(nameForIndex, sessionNames, sessionDurations, out int sessionDuration);
                            Console.WriteLine($"Session found at index: {idx} (Duration: {sessionDuration} minutes)\n");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}\n");
                        }
                        break;

                    case 6:
                        Console.Write("Enter session name to check: ");
                        string nameToCheck = Console.ReadLine();
                        bool exists = Array.Exists(sessionNames, n => n.Equals(nameToCheck, StringComparison.OrdinalIgnoreCase));
                        Console.WriteLine(exists ? "Session exists.\n" : "Session does not exist.\n");
                        break;

                    case 7:
                        Console.WriteLine("=== Duration Statistics ===");
                        Console.WriteLine($"Total Duration: {GetTotalDuration(sessionDurations)} minutes");
                        Console.WriteLine($"Average Duration: {GetAverageDuration(sessionDurations):F2} minutes");
                        Console.WriteLine($"Shortest Duration: {GetShortestDuration(sessionDurations)} minutes");
                        Console.WriteLine($"Longest Duration: {GetLongestDuration(sessionDurations)} minutes\n");
                        break;

                    case 8:
                        Console.Write("Enter session name: ");
                        string dateDetailName = Console.ReadLine();
                        DisplayDateDetails(dateDetailName, sessionNames, sessionDates, sessionDurations);
                        break;

                    case 9:
                        CompareSessionsDatesWithNow(sessionNames, sessionDates);
                        Console.WriteLine();
                        break;

                    case 10:
                        FindTheNextSession(sessionNames, sessionDates, sessionDurations);
                        break;

                    case 11:
                        Console.Write("Enter first session name: ");
                        string firstSession = Console.ReadLine();
                        Console.Write("Enter second session name: ");
                        string secondSession = Console.ReadLine();
                        CompareSessionDates(firstSession, secondSession, sessionNames, sessionDates);
                        break;

                    case 12:
                        DateTime customDate = CheckDateFormat();
                        Console.WriteLine($"Valid date entered: {customDate:yyyy-MM-dd HH:mm}\n");
                        break;

                    case 13:
                        Console.Write($"Enter session index (0 to {sessionNames.Length - 1}): ");
                        try
                        {
                            int selectedIndex = int.Parse(Console.ReadLine());
                            DisplaySessionDetails(selectedIndex, sessionNames, sessionDates, sessionDurations);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Error: Index is out of range.\n");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: Please enter a valid number.\n");
                        }
                        break;

                    case 14:
                        try
                        {
                            ChechDurationValidation();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Validation Error: {ex.Message}\n");
                        }
                        break;

                    case 15:
                        string stringReport = BuildReportUsingString(sessionNames, sessionDates, sessionDurations);
                        Console.WriteLine(stringReport);
                        break;

                    case 16:
                        StringBuilder sbReport = BuildReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations);
                        Console.WriteLine(sbReport.ToString());
                        break;

                    case 0:
                        isRunning = false;
                        Console.WriteLine("Exiting Academy Schedule Analyzer. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose a number between 0 and 16.\n");
                        break;
                }
            }
        }
        //***************************************************************** Funcations *****************************************************************
        static void DisplaySessionDetails(int index, string[] names, DateTime[] dates, int[] durations)
        {


            Console.WriteLine($"{index + 1}. {names[index]}");
            Console.WriteLine($"Date: {DateOnly.FromDateTime(dates[index])}");
            Console.WriteLine($"Start time: {TimeOnly.FromDateTime(dates[index])}");
            Console.WriteLine($"Duration: {durations[index]} minutes");
            Console.WriteLine();

        }
        static void DisplaySessions(string[] names, DateTime[] dates, int[] durations)
        {
            for (int i = 0; i < names.Length; i++)
            {
                DisplaySessionDetails(i, names, dates, durations);
            }
        }
        static int SearchSession(string[] names, string name)
        {
            return Array.FindIndex(names, n => n.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        static int GetTotalDuration(int[] durations)
        {
            int total = 0;
            foreach (int duration in durations)
            {
                total += duration;
            }
            return total;
        }
        static double GetAverageDuration(int[] durations)
        {
            int Total = GetTotalDuration(durations);
            double average = 1.0 * Total / durations.Length;
            return average;
        }
        static int GetShortestDuration(int[] durations)
        {
            int min = durations[0];
            for (int i = 1; i < durations.Length; i++)
            {
                if (durations[i] < min)
                    min = durations[i];
            }
            return min;
        }
        static int GetLongestDuration(int[] durations)
        {
            int max = durations[0];
            for (int i = 1; i < durations.Length; i++)
            {
                if (max < durations[i])
                    max = durations[i];
            }
            return max;
        }
        static TimeOnly GetSessionEndTime(string SessionName, string[] Names, DateTime[] dates, int[] durations)
        {
            int index = Array.IndexOf(Names, SessionName);

            if (index == -1)
            {
                throw new Exception("This Item is Not Found");
            }

            TimeOnly EndTime = TimeOnly.FromDateTime(dates[index]);
            EndTime = EndTime.AddMinutes(durations[index]);
            return EndTime;
        }
        static DateTime ReadSessionDate(string name, string[] names, DateTime[] dates)
        {
            int index = Array.IndexOf(names, name);
            if (index == -1)
            {
                throw new Exception("This item is not found!");
            }
            return dates[index];
        }
        static string BuildReportUsingString(string[] names, DateTime[] dates, int[] durations)
        {
            string report = "=== Training Schedule Report ===\n\n";
            for (int i = 0; i < names.Length; i++)
            {
                report += $"{i + 1}. {names[i]}\n";
                report += $"Date: {DateOnly.FromDateTime(dates[i])}\n";
                report += $"Start time: {TimeOnly.FromDateTime(dates[i])}\n";
                report += $"Duration: {durations[i]} minutes\n\n";
            }
            return report;
        }
        static StringBuilder BuildReportUsingStringBuilder(string[] names, DateTime[] dates, int[] durations)
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("=== Training Schedule Report ===");
            report.AppendLine();
            for (int i = 0; i < names.Length; i++)
            {
                report.AppendLine($"{i + 1}. {names[i]}\n");
                report.AppendLine($"Date: {DateOnly.FromDateTime(dates[i])}\n");
                report.AppendLine($"Start time: {TimeOnly.FromDateTime(dates[i])}\n");
                report.AppendLine($"Duration: {durations[i]} minutes\n\n");
                report.AppendLine();
            }
            return report;
        }
        static void SwapNumbers(ref int num1, ref int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }
        static int GetIndexFromName(string name, string[] names, int[] durations, out int duration)
        {
            int index = Array.FindIndex(names, n => n.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (index == -1)
                throw new Exception("ArgumentOutOfRangeException");
            duration = durations[index];
            return index;
        }
        static void ChangeArrayContent(int[] arr)
        {
            arr[0] = 10;
        }
        static int CalculateTotalDuration(params int[] Duration)
        {
            int index = 0;
            int total = 0;
            while (index < Duration.Length)
            {
                total += Duration[index];
                index++;
            }
            return total;
        }
        static void DisplayDateDetails(string name, string[] names, DateTime[] Dates, int[] duration)
        {
            int index = Array.FindIndex(names, N => N.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (index == -1)
            {
                Console.WriteLine("Session not found.");
                return;
            }
            DateTime date = Dates[index];
            Console.WriteLine("The Date Details is : \n");
            Console.WriteLine($"Date: {date.ToString("dd MMMM yyyy")}");
            Console.WriteLine($"Day: {date.DayOfWeek}");
            Console.WriteLine($"Year: {date.Year}");
            Console.WriteLine($"Month: {date.Month}");
            Console.WriteLine($"Day Number: {date.Day}");
            Console.WriteLine($"Start Time: {TimeOnly.FromDateTime(date)}");
            Console.WriteLine($"Duration: {duration[index]}");
            Console.WriteLine($"End Time: {TimeOnly.FromDateTime(date).AddMinutes(duration[index])}");
            Console.WriteLine();
        }
        static void CompareSessionDates(string sessionname6, string sessionname7, string[] names, DateTime[] dates)
        {
            int index1 = Array.FindIndex(names, n => n.Equals(sessionname6, StringComparison.OrdinalIgnoreCase));
            int index2 = Array.FindIndex(names, n => n.Equals(sessionname7, StringComparison.OrdinalIgnoreCase));
            if (index1 == -1 || index2 == -1)
            {
                Console.WriteLine("Session Not Found!1");
                return;
            }
            else
            {
                TimeSpan DateDiff = dates[index1] > dates[index2] ? dates[index1] - dates[index2] : dates[index2] - dates[index1];
                Console.WriteLine("Diffrence: ");
                Console.WriteLine($"{DateDiff.TotalDays} days");
                Console.WriteLine($"{DateDiff.TotalHours} hours");
                Console.WriteLine();
            }
        }
        static void CompareSessionsDatesWithNow(string[] names, DateTime[] dates)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (dates[i] < DateTime.Now)
                {
                    Console.WriteLine($"{names[i]} Past");
                }
                else
                {
                    Console.WriteLine($"{names[i]} Upcoming");
                }
            }
        }
        static void FindTheNextSession(string[] names, DateTime[] dates, int[] durations)
        {
            DateTime NowDate = DateTime.Now;
            int CurrIndex = -1;
            for (int index1 = 0; index1 < names.Length; index1++)
            {
                if (dates[index1] > NowDate)
                {
                    CurrIndex = index1;
                    break;
                }
            }
            if (CurrIndex == -1)
            {
                Console.WriteLine("There are no upcoming sessions.");
                return;
            }
            Console.WriteLine("Next Session: \n");
            Console.WriteLine(names[CurrIndex]);
            Console.WriteLine(dates[CurrIndex].ToString("dd MMMM yyyy"));
            Console.WriteLine(TimeOnly.FromDateTime(dates[CurrIndex]));
            Console.WriteLine();
            Console.WriteLine("Time Remaining: ");
            TimeSpan Diff = dates[CurrIndex] - NowDate;
            Console.WriteLine($"{Diff.Days} days");
            Console.WriteLine($"{Diff.Hours} hours");
            Console.WriteLine();
        }
        static DateTime CheckDateFormat()
        {
            bool test = false;
            while (true)
            {
                Console.WriteLine("Enter date as this formatting yyyy-MM-dd HH:mm");
                string Date = Console.ReadLine();
                test = DateTime.TryParseExact(Date, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);
                if(test)
                {
                    return date;
                }
            }
        }
        static int GetMenuOption()
        {
            while (true)
            {
                Console.Write("Choose an option: ");
                string input = Console.ReadLine();

                try
                {
                    int convertNum = int.Parse(input);
                    return convertNum; 
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid menu option. Enter a number.");
                }
            }
        }
        static void ChechDurationValidation()
        {
            Console.WriteLine("Enter duration:");
            int duration=int.Parse(Console.ReadLine());
            if (duration <= 0)
            {
                throw new ArgumentException("Duration must be greater than zero.");
            }
            else
                Console.WriteLine("Duration accepted.\n");
        }
        static string SchuduleReportUsingString(string[] names, DateTime[]dates ,int[]durations)
        {
            string result = "";
            for(int i=0;i<names.Length;i++)
            {
                result += $"{names[i]} - {dates[i].ToString("dd/MM/yyyy hh:mm tt")} - {durations[i]} minutes\n";
            }
            return result;
        }
        static string SchuduleReportUsingStringBuilder(string[] names, DateTime[] dates, int[] durations)
        {
            var result = new StringBuilder (names.Length);
            for (int i = 0; i < names.Length; i++)
            {
                result .Append( $"{names[i]} - {dates[i].ToString("dd/MM/yyyy hh:mm tt")} - {durations[i]} minutes\n");
            }
            return result.ToString();
        }
    }
}
