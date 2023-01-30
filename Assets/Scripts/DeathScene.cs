using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScene : MonoBehaviour
{
    public RawImage ChanginColour;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = ChanginColour.color;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ColourFading());
    }

    IEnumerator ColourFading()
    {
        if (color.a >= 0f)
        {
            color.a -= 0.5f * Time.deltaTime;
            ChanginColour.color = color;
            Debug.Log("Test");
        }
        yield return new WaitForSeconds(0.1f);
    }
}
