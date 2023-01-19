using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Texture[] NewTexture;
    public int CurrentTexture;

    public bool ChangedTexture = false;

    public Renderer m_renderer;

    private void Awake()
    {
        
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
        
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "PaintCollision" && ChangedTexture == false)
        {
            StartCoroutine(TextureSwap());
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
