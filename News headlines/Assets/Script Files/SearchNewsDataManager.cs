using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SearchNewsDataManager : MonoBehaviour
{
    //private string url = "https://newsapi.org/v2/everything?q=";
   // private string key = "1aa064ea8e3c4648a320d6c053daa69f";
    public GameObject searchScrollBar;   
    
    [SerializeField]
    private SearchNewsHeadLines dataShow;
    NewsDataList getData;

    public NewsDataManager getSearchData;

    private string text_Search;
    private void Start()
    {
        text_Search = getSearchData.searchTextField;

        StartCoroutine(SearchNewsInfo());
    }

    IEnumerator SearchNewsInfo()
    {

        UnityWebRequest webSearch =new UnityWebRequest("https://newsapi.org/v2/everything?q=" + text_Search + "&apiKey=1aa064ea8e3c4648a320d6c053daa69f")
        {
            downloadHandler = new DownloadHandlerBuffer()
        };

        yield return webSearch.SendWebRequest();
        if (webSearch.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("CONNECTION ERROR");
            Debug.Log(webSearch.error);
        }
        else if (webSearch.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("PROTOCOL ERROR");
            Debug.Log(webSearch.error);
        }
        else if (webSearch.result == UnityWebRequest.Result.DataProcessingError)
        {
            Debug.Log("DATA PROCESSING ERROR");
            Debug.Log(webSearch.error);
        }
        else if(webSearch.result == UnityWebRequest.Result.Success)
        {
            getData = JsonUtility.FromJson<NewsDataList>(webSearch.downloadHandler.text);

            for (int i = 0; i < getData.articles.Count; i++)
            {
                SearchNewsHeadLines headlines = Instantiate(dataShow);
                headlines.SetNewsHeadlines(getData.articles[i]);
                headlines.transform.SetParent(searchScrollBar.transform, false);
            }
        }
       
        

        //This not work properly... 
        /*
        switch (webSearch.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("Connection Error...." + webSearch.error);
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": [Error..] : " + webSearch.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP [Error...] : " + webSearch.error);
                    break;
                case UnityWebRequest.Result.Success:
                    getData = JsonUtility.FromJson<NewsDataList>(webSearch.downloadHandler.text);

                    for (int i = 0; i < getData.articles.Count; i++)
                    {
                        SearchNewsHeadLines headlines = Instantiate(dataShow);
                        headlines.SetNewsHeadlines(getData.articles[i]);
                        headlines.transform.SetParent(searchScrollBar.transform, false);
                    }
                    break;
            }*/
        }
}
