using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Introduction : MonoBehaviour
{
    public GameObject UInterface;
    public GameObject introduction;
    public VideoPlayer vc;

    private float len;
    // Start is called before the first frame update
    void Start()
    {
        UInterface.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        len = (float)vc.length;
        if (vc.isPlaying == false)
        {
            UInterface.SetActive(true);
            introduction.SetActive(false);
        }
    }
}
