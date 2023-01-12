using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    Camera cam;

    [Header("References")]

    public float DistanceX = 1f;
    public float DistanceY = 1f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(DistanceX, DistanceY, 0));
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
            print("I'm looking at" + hit.transform.name);
        else
            print("Im looking at nothing");

        Debug.DrawLine(transform.position, hit.point, Color.green);
    }
}
