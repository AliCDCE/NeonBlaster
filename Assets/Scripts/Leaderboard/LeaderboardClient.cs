// using UnityEngine;
// using UnityEngine.Networking;
// using System.Collections;
// using System.Collections.Generic;

// public class LeaderboardClient : MonoBehaviour {
//     private const string SERVER_URL = "http://localhost:8080/api/leaderboard";

//     public void AddScore(string name, int score, System.Action callback)
//     {
//         StartCoroutine(UploadScore(name, score, callback));
//     }

//     public void GetTopScores(int count, System.Action<Dictionary<string, int>> callback)
//     {
//         StartCoroutine(RetrieveScores(count, callback));
//     }

//     private IEnumerator UploadScore(string name, int score, System.Action callback)
//     {
//         WWWForm form = new WWWForm();
//         form.AddField("name", name);
//         form.AddField("score", score);

//         Debug.Log("done1");

//         using (UnityWebRequest request = UnityWebRequest.Post(SERVER_URL, form))
//         {
//             Debug.Log("done2");
//             yield return request.SendWebRequest();
//             Debug.Log("done3");

//             if (request.result == UnityWebRequest.Result.Success)
//             {
//                 Debug.Log("done4");
//                 callback();
//             }
//             else
//             {
//                 Debug.Log("done5");
//                 Debug.LogError("Error uploading score: " + request.error);
//             }
//         }
//     }

//     private IEnumerator RetrieveScores(int count, System.Action<Dictionary<string, int>> callback)
//     {
//         string url = SERVER_URL + "?count=" + count;

//         using (UnityWebRequest request = UnityWebRequest.Get(url))
//         {
//             yield return request.SendWebRequest();

//             if (request.result == UnityWebRequest.Result.Success)
//             {
//                 string responseJson = request.downloadHandler.text;
//                 Dictionary<string, int> scores = JsonUtility.FromJson<Dictionary<string, int>>(responseJson);
//                 callback(scores);
//             }
//             else
//             {
//                 Debug.LogError("Error retrieving scores: " + request.error);
//             }
//         }
//     }
// }








// using System.Collections;
// using System.Collections.Generic;
// using System.IO;
// using System.Net;
// using System.Text;
// using UnityEngine;

// public class LeaderboardClient : MonoBehaviour
// {
//     private const string SERVER_URL = "http://localhost:8080/";

//     public void AddScore(string name, int score)
//     {
//         string requestString = "addScore," + name + "," + score + ",0";
//         StartCoroutine(SendRequest(requestString));
//     }

//     public void GetTopScores(int count)
//     {
//         string requestString = "getTopScores,null,null," + count;
//         StartCoroutine(SendRequest(requestString, responseString =>
//         {
//             string[] lines = responseString.Split('\n');
//             foreach (string line in lines)
//             {
//                 if (line.Trim() == "") continue;
//                 string[] parts = line.Split(',');
//                 string name = parts[0];
//                 int score = int.Parse(parts[1]);
//                 Debug.Log(name + ": " + score);
//             }
//         }));
//     }

//     private IEnumerator SendRequest(string requestString, System.Action<string> onResponse = null)
//     {
//         // byte[] requestData = Encoding.UTF8.GetBytes(requestString);
//         byte[] requestData = Encoding.Unicode.GetBytes(requestString);
//         HttpWebRequest request = (HttpWebRequest)WebRequest.Create(SERVER_URL);
//         request.Method = "POST";
//         request.ContentType = "text/plain";
//         request.ContentLength = requestData.Length;
//         Stream requestStream = request.GetRequestStream();

//         Debug.Log(requestData.ToString());

//         requestStream.Write(requestData, 0, requestData.Length);
//         requestStream.Close();

//         HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//         Stream responseStream = response.GetResponseStream();
//         StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
//         string responseString = reader.ReadToEnd();
//         reader.Close();
//         responseStream.Close();
//         response.Close();

//         if (onResponse != null)
//         {
//             onResponse(responseString);
//         }

//         yield return null;
//     }
// }






using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardClient : MonoBehaviour {

    private const string SERVER_URL = "http://localhost:8080/";

    public IEnumerator GetRequest( int count ) {
        string dataToPost = "GET, , ,"+count;
        var getRequest = CreateRequest( SERVER_URL, RequestType.GET, dataToPost);
        yield return getRequest.SendWebRequest();
        var deserializedGetData = JsonUtility.FromJson<Todo>(getRequest.downloadHandler.text);
    }

    public IEnumerator POSTRequest( string name, int score ) {
        // var dataToPost = new PostData(){name = "John Wick", score = 9001}.ToString();
        string dataToPost = "POST,"+name+","+score+", ";
        var postRequest = CreateRequest( SERVER_URL, RequestType.POST, dataToPost);
        yield return postRequest.SendWebRequest();
        var deserializedPostData = JsonUtility.FromJson<PostResult>(postRequest.downloadHandler.text);
    }


    private UnityWebRequest CreateRequest( string path, RequestType type , string data = null) {
        var request = new UnityWebRequest(path, type.ToString());

        var bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);

        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        return request;
    }

    private void AttachHeader(UnityWebRequest request,string key,string value)
    {
        request.SetRequestHeader(key, value);
    }
}

public enum RequestType {
    GET = 0,
    POST = 1,
    PUT = 2
}


public class Todo {
    // Ensure no getters / setters
    // Typecase has to match exactly
    public int userId;
    public int id;
    public string title;
    public bool completed;
}

[System.Serializable]
public class PostData {
    public string name;
    public int score;
}

public class PostResult
{
    public string success { get; set; }
}