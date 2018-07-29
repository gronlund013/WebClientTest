using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
	        try
	        {
				Console.WriteLine(Assembly.GetCallingAssembly());
		        HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(@"https://reqres.in/api/users?page=2");
		        request.Method = "GET";
		        String test = String.Empty;
		        using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
		        {
			        Stream dataStream = response.GetResponseStream();
			        StreamReader reader = new StreamReader(dataStream);
			        test = reader.ReadToEnd();
			        Console.WriteLine(test);
			        reader.Close();
			        dataStream.Close();
		        }
	        }
	        catch (Exception ex)
	        {
				Console.WriteLine("Failed with exception: " + ex.Message + Environment.NewLine + ex.StackTrace);
	        }

	        Console.ReadKey();
        }
    }
}
