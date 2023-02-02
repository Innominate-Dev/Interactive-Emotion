using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingTexture : MonoBehaviour
{
    public Texture[] NewTexture;
    public int CurrentTexture;

    public bool ChangedTexture = false;

    public Renderer m_renderer;

    public static int paintedObjects = 0;

    private void Awake()
    {
        var myList = FindObjectsOfType<ChangingTexture>();
    }



    // Start is called before the first frame update
    void Start()
    {
        Material myMat = GetComponent<Renderer>().material;
        m_renderer = GetComponent<Renderer>();
        //myMat.SetTexture(1,NewTexture);
        //Debug.Log(myMat.mainTexture.ToString());

        ///////////////////////////////////////

    
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(paintedObjects);
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "PaintCollision" && ChangedTexture == false)
        {
            StartCoroutine(TextureSwap());
            paintedObjects++;
            ChangedTexture = true;
        }
    }

    IEnumerator TextureSwap()
    {
        yield return new WaitForSeconds(1f);
        CurrentTexture++;
        CurrentTexture %= NewTexture.Length;
        m_renderer.material.mainTexture = NewTexture[CurrentTexture];
    }
}
