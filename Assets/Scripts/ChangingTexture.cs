using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangingTexture : MonoBehaviour
{
    public Material[] NewTexture;
    public int CurrentTexture;

    public bool ChangedTexture = false;

    public Renderer m_renderer;

    RectTransform fill;

    public static int paintedObjects = 0;
    public static int totalPaintedObjects;
    float startingScale;

    //ublic Slider Progress;
    float progress;
    int PercentageProgress;

    public RectTransform handle;
    public RectTransform splatPoint;
    public RectTransform PercentagePOS;
    public TextMeshProUGUI Percentage;

    private void Awake()
    {
        var myList = FindObjectsOfType<ChangingTexture>();
        totalPaintedObjects = myList.Length;
    }



    // Start is called before the first frame update
    void Start()
    {
        fill = GameObject.Find("Fill").GetComponent<RectTransform>();
        handle = GameObject.Find("Handle").GetComponent<RectTransform>();
        splatPoint = GameObject.Find("Splatpoint").GetComponent<RectTransform>();
        Percentage = GameObject.Find("CityPaintedPercentage").GetComponent<TextMeshProUGUI>();
        PercentagePOS = GameObject.Find("CityPaintedPercentage").GetComponent<RectTransform>();

        Material myMat = GetComponent<Renderer>().material;
        m_renderer = GetComponent<Renderer>();
        //myMat.SetTexture(1,NewTexture);
        //Debug.Log(myMat.mainTexture.ToString());

        startingScale = fill.transform.lossyScale.x;

        fill.transform.localScale = new Vector3(progress, fill.transform.localScale.y, fill.transform.localScale.z);
        handle.position = splatPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        progress = (float)paintedObjects / (float)totalPaintedObjects;

        //Debug.Log(paintedObjects);
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "PaintCollision" && ChangedTexture == false)
        {
            StartCoroutine(TextureSwap());
            paintedObjects++;

            fill.transform.localScale = new Vector3(progress, fill.transform.localScale.y, fill.transform.localScale.z);
            handle.position = splatPoint.position;
            PercentagePOS.position = splatPoint.position;

            PercentageProgress = ((int)progress);
            Percentage.text = (PercentageProgress + "%");

            ChangedTexture = true;
        }
    }

    IEnumerator TextureSwap()
    {
        yield return new WaitForSeconds(1f);
        CurrentTexture++;
        CurrentTexture %= NewTexture.Length;
        m_renderer.material = NewTexture[CurrentTexture];
    }
}
