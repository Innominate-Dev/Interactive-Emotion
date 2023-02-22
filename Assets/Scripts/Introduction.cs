using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Introduction : MonoBehaviour
{
    public GameObject UInterface;
    public GameObject introduction;
    public RawImage Crosshair;

    public VideoPlayer vc;

    public bool playing;

    private float len;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        len = (float)vc.length;
        if (vc.isPlaying == true)
        {
            UInterface.SetActive(false);
            Crosshair.gameObject.SetActive(false);
            playing = true;
        }
        if (playing == true && vc.isPlaying == false)
        {
            UInterface.SetActive(true);
            Crosshair.gameObject.SetActive(true);
            introduction.SetActive(false);
        }

        if ((ulong)vc.frame == vc.frameCount)
        {

        }
    }
}
