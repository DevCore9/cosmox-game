using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageRandomizer : MonoBehaviour
{
    public Image Background;

    public Sprite[] Sprites;

    public int x;

    void Start()
    {
        x = Random.Range(0,4);

        Background.sprite = Sprites[x];
    }


    void Update()
    {
        
    }
}
