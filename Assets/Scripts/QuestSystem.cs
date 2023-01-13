using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestSystem : MonoBehaviour
{
    Camera cam;

    [Header("References")]

    public float DistanceX = 1f;
    public float DistanceY = 1f;

    public RawImage UICrosshair;
    public TextMeshProUGUI Interaction;
    public GameObject Dialogue1;

    [SerializeField] private TextWriter textWriter;
    public TextMeshProUGUI DialogueText1;

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
            if(hit.collider.CompareTag("NPC"))
            {
                InteractionActive();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Dialogue1.SetActive(true);
                    textWriter.AddWriter(DialogueText1, "Ash Hi I am Ash! I've heard a lot about you. Can you do me a favour? Find this memory for me I'll pay you! It is very dear to me.", .1f, true);
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
