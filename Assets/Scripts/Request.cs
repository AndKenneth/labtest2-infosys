using UnityEngine;
using System.Collections.Generic;
using System.Net;
using System.IO;


public class Request {
    public static string serverRoot = "http://kand413.azurewebsites.net";
    public static string zumoApiVersion = "zumo-api-version=2.0.0";

    public class ReadingData
    {
        public List<MyTree> response;
    }

    public static List<MyTree> getTrees()
    {
        string jsonResponse = Request.get("/tables/treesurvey" + "?" + zumoApiVersion);

        ReadingData trees = JsonUtility.FromJson<ReadingData>("{\"response\" : " + jsonResponse + "}");
        return trees.response;
    }

    public static string get(string url)
    {
        string requestString = Request.serverRoot + url;
        Debug.Log(requestString);
        try
        {
            //Instantiate a new request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestString);
            //Declaring a response variable
            string jsonResponse;

            //Setting request headers
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            //Making the request
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                //Reading the response into our response variable
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    jsonResponse = reader.ReadToEnd();
                }
            }

            //Returning our JSON string
            return jsonResponse;
        }
        catch (WebException ex)
        {
            //If something goes wrong during the webrequest an exception will be thrown and the following will be printed to console.
            Debug.Log("Something went wrong with your request. Exception message: " + ex.Message);
            return string.Empty;
        }
    }
}
