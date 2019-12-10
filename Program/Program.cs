using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Uri Static Methods

            bool isValid = Uri.CheckSchemeName("https");
            isValid.Prin(); // true

            isValid = Uri.CheckSchemeName("qwesasd");
            isValid.Prin(); // true!

            UriHostNameType type = Uri.CheckHostName("localhost.com");
            type.Prin(); // dns

            type = Uri.CheckHostName("asdasdasd");
            type.Prin(); // dns

            type = Uri.CheckHostName("https://google.com");
            type.Prin(); // uknown

            #endregion


            #region Initialization

            // don't throw
            Uri.TryCreate("asdasd", UriKind.Absolute, out Uri newUri);




            // throw Exception if value is invalid
            var uri = new Uri($"https://google.com");

            // this works fine
            uri = new Uri($"{Uri.UriSchemeHttps}://google.com");
            uri.Prin(); // https://google.com/

            uri = new Uri("api/values", UriKind.Relative);
            uri.Prin(); // /api/values

            // bad practise on Linux
            uri = new Uri("C:/test/path/file.txt");
            uri.Prin();         //file:///C:/test/path/file.txt
            uri.IsFile.Prin();  // True

            #endregion

            #region Uri Props 



            uri = new Uri("https://localhost.com/api/values?version=1");
            uri.Prin(); // https://localhost.com/api/values?version=1

            uri.PathAndQuery.Prin();    // api/values?version=1
            uri.Host.Prin();            // localhost.com
            uri.Query.Prin();           // ?version=1
            uri.Port.Prin();            // 443
            uri.Authority.Prin();       // localhost.com // typically a server DNS host name or IP address
            uri.Fragment.Prin();        // '' // http://www.contoso.com/index.htm#main, the Fragment property would return #main.
            uri.IsDefaultPort.Prin();   // True
            uri.IsFile.Prin();          // False
            uri.LocalPath.Prin();       // api/values


            #endregion

            #region Url Methods

            uri = new Uri("https://localhost.com/api/values?version=1");

            string path = uri.GetComponents(UriComponents.Path, UriFormat.UriEscaped);
            path.Prin();     // api/values
            string query = uri.GetComponents(UriComponents.Query, UriFormat.UriEscaped);
            query.Prin();    // version=1
            string host = uri.GetComponents(UriComponents.Host, UriFormat.UriEscaped);
            host.Prin();     // localhost.com

            // same as above
            // returns string

            uri.GetLeftPart(UriPartial.Path).Prin();
            uri.GetLeftPart(UriPartial.Scheme).Prin();
            uri.GetLeftPart(UriPartial.Query).Prin();



            #endregion

            #region Is Base Of +

            var localhost = new Uri("https://localhost.com");
            var uriAddress = new Uri("https://localhost.com/api/values");
            var otherUriAddres = new Uri("https://otherhost.com/api/values");

            localhost.IsBaseOf(uriAddress);     // True
            localhost.IsBaseOf(otherUriAddres); // False




            #endregion

            #region Absolute
            $"{new string('.', 20)} uri.AbsolutePath".Prin();


            var baseAddress = new Uri("https://localhost.com");
            baseAddress.AbsoluteUri.Prin();     // https://localhost.com // contains a scheme, an authority, and a path. 
            baseAddress.IsAbsoluteUri.Prin();   // True
            baseAddress.AbsolutePath.Prin();    // "/" //   path to the desired information on the server's file system NO scheme, host name, or query portion 


            var full = new Uri(baseAddress, "/api/values");
            full.AbsoluteUri.Prin();     // https://localhost.com/api/values // contains a scheme, an authority, and a path. 
            full.IsAbsoluteUri.Prin();   // True
            full.AbsolutePath.Prin();    // "/api/values"  //  path to the desired information on the server's file system NO scheme, host name, or query portion 

            goto UriBuilder;

            var relativeAddress = new Uri("api/values", UriKind.Relative);
            // throw exception since uri is Relative
            relativeAddress.AbsolutePath.Prin();  //  throw // path to the desired information on the server's file system, NO scheme, host name, or query portion 
            relativeAddress.AbsoluteUri.Prin();   //  throw
            relativeAddress.IsAbsoluteUri.Prin(); //  false 



        #endregion


        // Uri Builder
        UriBuilder:

            #region UriBuilder

            var uriBuilder = new UriBuilder(schemeName: "https", hostName: "hp.com");
            uriBuilder.Query = "versino = 1";
            uriBuilder.Path = "api/values";
            //uriBuilder.Host = "";
            // and so on...

            // Finally
            Uri newUria = uriBuilder.Uri; // https://hp.com/api/values?versino = 1


            #endregion

        }
    }


    public static class Extension{
        public static void Prin(this object o)=> System.Console.WriteLine(o);
    }
    
}
