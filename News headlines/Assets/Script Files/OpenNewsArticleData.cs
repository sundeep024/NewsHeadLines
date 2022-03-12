using UnityEngine;
using UnityEngine.UI;


public class OpenNewsArticleData : MonoBehaviour
{
    public Text articleTitle;
    public Text articleDescription;
    public RawImage articleRawImage;
    public Text articleAuthorName;
    public Text articlePublishedDate;

    public GameObject[] canvas;

    public void OnDisplayNews(string articleTitle, string articleDescription, Texture2D articleTexture, string articleAuthorName, string articlePublishedDate)
    {
        canvas[0].SetActive(false);
        canvas[1].SetActive(false);
        canvas[2].SetActive(true);
        this.articleTitle.text = articleTitle;
        this.articleDescription.text = articleDescription;
        this.articleRawImage.texture = articleTexture;
        this.articleAuthorName.text = articleAuthorName;
        this.articlePublishedDate.text = articlePublishedDate;
    }
}
