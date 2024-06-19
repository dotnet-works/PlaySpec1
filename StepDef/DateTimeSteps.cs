using System.Globalization;
using TechTalk.SpecFlow;

namespace PlaySpec1.StepDef
{
    [Binding]
    public sealed class DateTimeSteps
    {
        public DateTimeSteps()
        {
            
        }

        [When(@"formattype1 yyyy-MM-dd ""([^""]*)"" string")]
        public async Task ParseDate(string dateString)
        {
            DateTime dat = DateTime.Parse(dateString);
            Console.WriteLine($"Parsed DateTime1: {dat}");
            
            DateTime userDate = DateTime.ParseExact(dateString, "yyyy-mm-dd", null);
            Console.WriteLine($"Parsed Exact DateTime1: {userDate}");

            Console.WriteLine($"yyyy-MM-dd ConvertTo => {dat.ToString("dd-MM-yyyy")}");
            Console.WriteLine($"yyyy-MM-dd ConvertTo => {dat.ToString("dd/MM/yyyy")}");

        }



        [When(@"formattype2 dd-MM-yyyy ""([^""]*)"" string2")]
        public async Task ParseDate2(string dateString)
        {
            DateTime dat = DateTime.ParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine($"Date {dateString} Parsed To => {dat}");
            Console.WriteLine($"dd-MM-yyyy ConvertTo dd/MM/yyyy => {dat.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"dd-MM-yyyy ConvertTo MM/dd/yyyy => {dat.ToString("MM/dd/yyyy")}");
            ////var result1 = DateTime.ParseExact(date1, "d", null);
            ////var result2 = DateTime.ParseExact(date1, "d", CultureInfo.InvariantCulture);
        }

        [When(@"formattype3")]
        public async Task ParseDate3()
        {
            string d1 = DateTime.Now.ToString("dddd-MMM-yyyy");
            string d2 = DateTime.Now.ToString("dd-MMM-yyyy");
            string d3 = DateTime.Now.ToString("dd-MMMM-yyyy");
            Console.WriteLine($"dayname-MonthAbbrName-Year => {d1}");
            Console.WriteLine($"daynumber-MonthAbbrName-Year => {d2}");
            Console.WriteLine($"daynumber-MonthAbbrName-Year => {d3}");
        }

        [When(@"formattype4 ""([^""]*)""")]
        public async Task ParseDate4(string dateString)
        {
            //string dateString = "20 October 2000";
            string format = "dd MMMM yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime dateTime = DateTime.ParseExact(dateString, format, provider);
            
            Console.WriteLine($"{dateString} Parsed To (MM/dd/yyyy) date: " + dateTime);
            string mont = "Oct";

            if("October".Contains(mont)) 
            {
                Console.WriteLine("Yes It conssist");
            }


        }








        [When(@"print the format datetime")]
        public async Task frmtDate()
        {
            // Get current DateTime. It can be any DateTime object in your code.
            DateTime aDate = DateTime.Now;

            // Format Datetime in different formats and display them
            Console.WriteLine(aDate.ToString("MM/dd/yyyy"));
            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            Console.WriteLine(aDate.ToString("MM/dd/yyyy HH:mm"));
            Console.WriteLine(aDate.ToString("MM/dd/yyyy hh:mm tt"));
            Console.WriteLine(aDate.ToString("MM/dd/yyyy H:mm"));
            Console.WriteLine(aDate.ToString("MM/dd/yyyy h:mm tt"));
            Console.WriteLine(aDate.ToString("MM/dd/yyyy HH:mm:ss"));
            Console.WriteLine(aDate.ToString("MMMM dd"));
            Console.WriteLine(aDate.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK"));
            Console.WriteLine(aDate.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’"));
            Console.WriteLine(aDate.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss"));
            Console.WriteLine(aDate.ToString("HH:mm"));
            Console.WriteLine(aDate.ToString("hh:mm tt"));
            Console.WriteLine(aDate.ToString("H:mm"));
            Console.WriteLine(aDate.ToString("h:mm tt"));
            Console.WriteLine(aDate.ToString("HH:mm:ss"));
            Console.WriteLine(aDate.ToString("yyyy MMMM"));
        }



    }
}