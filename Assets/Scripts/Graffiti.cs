using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graffiti : MonoBehaviour
{
    public Material PaintingWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Color color = PaintingWall.color;
            color.a += 1f * Time.deltaTime;
            PaintingWall.color = color;
            Debug.Log("Test");
        }
        Debug.Log("Tester");
    }
}
