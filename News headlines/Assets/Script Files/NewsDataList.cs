using System.Collections.Generic;

[System.Serializable]
public class NewsDataList
{
    public string status;
    public int totalResult;
    public List<Article> articles;
}

[System.Serializable]
public class Article 
{
    public Source source;
    public string author;
    public string title;
    public string description;
    public string url;
    public string urlToImage;
    public string publishedAt;
    public string content;
}

[System.Serializable]
public class Source
{
    public string id;
    public string name;
}


