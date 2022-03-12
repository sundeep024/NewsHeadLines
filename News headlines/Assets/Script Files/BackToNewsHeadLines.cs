using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToNewsHeadLines : MonoBehaviour
{
    public GameObject[] canvasPanel;


    public void BackToNews()
    {
        canvasPanel[0].SetActive(false);
        canvasPanel[1].SetActive(true);
        canvasPanel[2].SetActive(true);
       // canvasPanel[3].SetActive(false);

    }
}
