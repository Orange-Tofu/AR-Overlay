using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class API : MonoBehaviour
{
    public string url = "http://127.0.0.1:5000/api/gallery";
    public string imagePath = "M:/CS/UnityPro/AR-Overlay/Assets/Resources/aniDurga.jpg"; // Set the path to your image here
    public Image imageElement;

    IEnumerator SendData()
    {
        // imagePath = "C:/Users/akash/Downloads/aniDurga.jpg";
        WWWForm form = new WWWForm();
        byte[] imgData = File.ReadAllBytes(imagePath);
        form.AddBinaryData("image", imgData, "screenshot.jpg", "image/jpg");
        using (var w = UnityEngine.Networking.UnityWebRequest.Post(url, form))
        {
            yield return w.SendWebRequest();
            if (w.result != UnityEngine.Networking.UnityWebRequest.Result.Success)
            {
                Debug.Log(w.error);
            }
            else
            {
                Debug.Log("Image upload complete!");
            }
        }
    }

    public void CallAPI()
    {
        Debug.Log("Button Pressed");
        StartCoroutine(SendData());
        Debug.Log("Ayeein");
    }

    public void TestButton()
    {
        Debug.Log("Button workings");
        CallAPI();
        // DisplayImage();
    }
    // public string imagePath;

    public void DisplayImage()
    {
        Texture2D texture = Resources.Load(imagePath) as Texture2D;
        if (texture != null)
        {
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
            imageElement.sprite = sprite;
        }
        else
        {
            Debug.LogError("Image not found at the specified path.");
        }
    }
}
