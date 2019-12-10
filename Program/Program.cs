using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {

            // URI static methods

            // Left on Uri Compare



            bool isValid = Uri.CheckSchemeName("https");
            isValid.Prin(); // true

            isValid = Uri.CheckSchemeName("qwesasd");
            isValid.Prin(); // true!







            UriHostNameType type =  Uri.CheckHostName("localhost.com");
            type.Prin(); // dns

            type = Uri.CheckHostName("asdasdasd");
            type.Prin(); // dns

            type = Uri.CheckHostName("https://google.com");
            type.Prin(); // uknown


            












            // throw Exception if value is invalid
            var uri = new Uri($"https://google.com");
            // this works fine
            uri = new Uri($"{Uri.UriSchemeHttps}://google.com");

            uri = new Uri("/api/values");
            uri.Prin(); // file:///api/values

            // bad practise on Linux
            uri = new Uri("C:/test/path/file.txt");


            uri = new Uri("https://localhost.com/api/values?version=1");
            
            uri.PathAndQuery.Prin();    // api/values?version=1
            uri.AbsolutePath.Prin();    // api/values
            uri.AbsoluteUri.Prin();     // https://localhost.com/api/values?version=1
            uri.Host.Prin();            // localhost.com
            uri.Query.Prin();           // ?version=1
            uri.Port.Prin();            // 443
            uri.Authority.Prin();       // localhost.com

            









            


            uri.IsAbsoluteUri.Prin();   // true

            uri = new Uri("https://localhost.com");
            uri.IsAbsoluteUri.Prin(); // true

            uri = new Uri("/api/values");
            uri.IsAbsoluteUri.Prin(); // true


            uri = new Uri(baseUri: new Uri("https://localhost.com"), 
                      relativeUri: "/api/values");

            










        }
    }


    public static class Extension{
        public static void Prin(this object o)=> System.Console.WriteLine(o);
    }
    
}
