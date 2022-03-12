using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NewsHeadLines : MonoBehaviour
{
    public Article articlesData;
    public Text title;
    public Text description;
    public RawImage rawImage;    
    private Texture2D imageTexture;
    public Text authorName;
    public Text publishedDate;

    public Button newsClick;

    
    public void SetNewsHeadlines(Article data)
    {
        articlesData = data;
        title.text = articlesData.title;
        description.text = articlesData.description;
        StartCoroutine(getImages());
        newsClick.onClick.AddListener(delegate {FindObjectOfType<OpenNewsArticleData>().OnDisplayNews(articlesData.title,articlesData.description,
                                                                                                        imageTexture,articlesData.author, articlesData.publishedAt ); });
    }

    IEnumerator getImages()
    {
        UnityWebRequest getImage = UnityWebRequestTexture.GetTexture(articlesData.urlToImage);

        yield return getImage.SendWebRequest();
        if (getImage.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("CONNECTION ERROR");
            Debug.Log(getImage.error);
        }
        else if (getImage.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("PROTOCOL ERROR");
            Debug.Log(getImage.error);
        }
        else if (getImage.result == UnityWebRequest.Result.DataProcessingError)
        {
            Debug.Log("DATA PROCESSING ERROR");
            Debug.Log(getImage.error);
        }
        else if (getImage.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Success..");
            imageTexture = DownloadHandlerTexture.GetContent(getImage);
            rawImage.texture = imageTexture;
        }
        
        
        /*
        switch (getImage.result)
        {
            case UnityWebRequest.Result.ConnectionError:
                Debug.Log("Image Connection Error..." + getImage.error);
                break;

            case UnityWebRequest.Result.Success:
                Debug.Log("Success..");
                imageTexture = DownloadHandlerTexture.GetContent(getImage);
                rawImage.texture = imageTexture;
                break;
        }*/
    }
}
