using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Texture NewTexture;

    // Start is called before the first frame update
    void Start()
    {
        Material myMat = GetComponent<Renderer>().material;
        Renderer m_renderer = GetComponent<Renderer>();
        myMat.SetTexture("MainTex",NewTexture);
        //Debug.Log(myMat.mainTexture.ToString());
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
