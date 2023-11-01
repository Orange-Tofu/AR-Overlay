using UnityEngine;
using System.Collections;

public class APIRequest : MonoBehaviour
{
    public string url = "http://127.0.0.1:5000/upload";

    IEnumerator SendData(string message)
    {
        Debug.Log("Next?");
        WWWForm form = new WWWForm();
        form.AddField("message", message);
        using (var w = UnityEngine.Networking.UnityWebRequest.Post(url, form))
        {
            w.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            yield return w.SendWebRequest();
            if (w.result != UnityEngine.Networking.UnityWebRequest.Result.Success)
            {
                Debug.Log(w.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }

    public void CallAPI()
    {
        Debug.Log("Button Pressed");
        StartCoroutine(SendData("Hello World"));
        Debug.Log("Ayeein");
    }

    public void TestButton()
    {
        Debug.Log("Button workings");
        CallAPI();
    }

    // void Start()
    // {
    //     CallAPI();
    // }
}
