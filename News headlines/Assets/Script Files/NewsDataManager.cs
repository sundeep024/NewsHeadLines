using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NewsDataManager : MonoBehaviour
{
    string url = "https://newsapi.org/v2/everything?q=Apple&from=2022-03-11&sortBy=popularity&apiKey=1aa064ea8e3c4648a320d6c053daa69f";
    
    [SerializeField]
    public GameObject scrollviewPoint;
    [SerializeField]
    private NewsHeadLines DataShow;
    NewsDataList getData;

    public GameObject[] canvasPanel;
    public InputField searchInputField;
    public string searchTextField;

    private void Start()
    {
        canvasPanel[0].SetActive(true);
        canvasPanel[1].SetActive(true);
        canvasPanel[2].SetActive(false);
        canvasPanel[3].SetActive(false);

        StartCoroutine(GetNews(url));
    }
   
    IEnumerator GetNews(string url)
    {
        Debug.Log("Loading Data......");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("CONNECTION ERROR");
                Debug.Log(webRequest.error);
            }
            else if (webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("PROTOCOL ERROR");
                Debug.Log(webRequest.error);
            }
            else if (webRequest.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.Log("DATA PROCESSING ERROR");
                Debug.Log(webRequest.error);
            }
            else if(webRequest.result == UnityWebRequest.Result.Success)
            {
                getData = JsonUtility.FromJson<NewsDataList>(webRequest.downloadHandler.text);

                for (int i = 0; i < getData.articles.Count; i++)
                {
                    NewsHeadLines headlines = Instantiate(DataShow);
                    headlines.SetNewsHeadlines(getData.articles[i]);
                    headlines.transform.SetParent(scrollviewPoint.transform, false);
                }
            }
            /*
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("Connection Error...." + webRequest.error);
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": [Error..] : " + webRequest.error);
                    //Debug.LogError(pages[page] + ": [Error..] : " +webRequest.error );
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP [Error...] : " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    getData = JsonUtility.FromJson<NewsDataList>(webRequest.downloadHandler.text);

                    for(int i=0; i<getData.articles.Count; i++)
                    {
                        NewsHeadLines headlines = Instantiate(DataShow);
                        headlines.SetNewsHeadlines(getData.articles[i]);
                        headlines.transform.SetParent(scrollviewPoint.transform, false);                       
                    }
                    //Debug.Log(getData.status);
                    //Debug.Log(pages[page] + "\n Received: " + webRequest.downloadHandler.text);
                    break;
            }*/

        }
    }
    
    public void ClickOnSearchButton()
    {
        canvasPanel[0].SetActive(false);
        canvasPanel[1].SetActive(false);
        canvasPanel[2].SetActive(false);
        canvasPanel[3].SetActive(true);
        searchTextField = searchInputField.text;
    }

}
