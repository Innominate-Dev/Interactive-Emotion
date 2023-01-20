using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    Camera cam;

    [Header("References")]

    public float DistanceX = 0.5f;
    public float DistanceY = 0.5f;

    public RawImage UICrosshair;
    public TextMeshProUGUI Interaction;

    [Header("Text References")]

    public GameObject Poem;

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
            if (hit.collider.name == "Poem")
            {
                InteractionActive();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Poem.SetActive(true);
                }
            }
            else
            {
                InteractionDeactive();
            }
        else
        {
            InteractionDeactive();
        }

        Debug.DrawLine(transform.position, hit.point, Color.blue);
    }

    public void InteractionActive()
    {
        UICrosshair.gameObject.SetActive(false);
        Interaction.gameObject.SetActive(true);
    }

    public void InteractionDeactive()
    {
        UICrosshair.gameObject.SetActive(true);
        Interaction.gameObject.SetActive(false);
    }
}
