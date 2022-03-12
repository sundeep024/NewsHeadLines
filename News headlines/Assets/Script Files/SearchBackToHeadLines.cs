using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchBackToHeadLines : MonoBehaviour
{
    public GameObject[] canvasPanel;
    public void BackToNews()
    {
        canvasPanel[0].SetActive(true);
        canvasPanel[1].SetActive(true);
        canvasPanel[2].SetActive(false);
        //canvasPanel[3].SetActive(false);

    }
}
