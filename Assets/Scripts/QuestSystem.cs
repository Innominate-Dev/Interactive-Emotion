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

    public GameObject Objective;
    public GameObject OfferButtons;

    public GameObject ExclamationMark;

    [Header("Dialogue Object")]
    public GameObject Dialogue1;
    public GameObject Dialogue2;

    [Header("Text Writer")]

    [SerializeField] private TextWriter textWriter;
    [SerializeField] private TextWriter textWriter2;


    [Header("Text References")]

    public TextMeshProUGUI DialogueText1;
    public TextMeshProUGUI DialogueText2;

    public TextMeshProUGUI FindMemory;
    public TextMeshProUGUI PaintTheWall;

    [Header("Interactables")]

    public GameObject Poem;

    public GameObject AshQuest;
    public GameObject QuynhQuest;

    public GameObject AshPaintingWall;

    [Header("States")]

    public bool AshMemoryCollected = false;
    public bool QuynhMemoryCollected = false;

    public bool AshQuestStarted = false;
    public bool QuynhQuestStarted = false;

    public bool AshPaintWallQuest = false;
    public bool QuynhPaintWallQuest = false;

    public bool AshTalking = false;
    public bool QuynhTalking = false;

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

        ///Checking what the Raycast is hitting 
        
        if (Physics.Raycast(ray, out hit))
            if(hit.collider.CompareTag("NPC"))
            {
                InteractionActive();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;

                    ////////////////// Ash Interaction ///////////////
                    
                    if (hit.transform.name == "Ash" && AshMemoryCollected == false)
                    {
                        Dialogue1.SetActive(true);
                        textWriter.AddWriter(DialogueText1, "Ash Hi I am Ash! I've heard a lot about you. Can you do me a favour? Find this memory for me I'll pay you! It is very dear to me.", .1f, true);
                        //StartCoroutine(AshTalkingDialogue());
                        AshTalking = true;
                        FindMemory.gameObject.SetActive(true);
                    }

                    else if(AshMemoryCollected == true)
                    {
                        Dialogue1.SetActive(true);
                        textWriter.AddWriter(DialogueText1,"WOW You found it thanks! Could you just paint it on the wall for me.",.1f,true);
                        FindMemory.text = "- <s>Find the memory</s>";
                        PaintTheWall.gameObject.SetActive(true);
                        AshPaintingWall.SetActive(true);
                    }

                    ////////////////////// Quynh Interaction //////////////////////
                    if(hit.transform.name == "Quynh" && QuynhMemoryCollected == false)
                    {
                        Dialogue2.SetActive(true);
                        textWriter2.AddWriter(DialogueText2, "Hi I am Quynh! I've heard a lot about you. Can you do me a favour? Find this memory for me I'll pay you! It is very dear to me.", .1f, true);
                        QuynhTalking = true;
                        FindMemory.gameObject.SetActive(true);
                    }

                    else if (QuynhMemoryCollected == true)
                    {
                        Dialogue2.SetActive(true);
                        textWriter2.AddWriter(DialogueText2, "WOW You found it thanks! Could you just paint it on the wall for me.", .1f, true);
                        FindMemory.text = "- <s>Find the memory</s>";


                    }
                }
            }

            else if(hit.collider.name == "Poem")
            {
                InteractionActive();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //// Poem Letter ///
                    
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Poem.SetActive(true);
                    Destroy(ExclamationMark);
                }
            }

            ////////////// INTERACTABLES //////////////
            
            else if (hit.transform.tag == "Interactable")
            {
                ///////////////// MEMORY QUEST /////////////////
                if (hit.transform.name == "Ash Memory")
                {
                    if(AshQuestStarted == true)
                    {
                        InteractionActive();
                        if(Input.GetKeyDown(KeyCode.E))
                        {
                            AshMemoryCollected = true;
                            Destroy(hit.collider.gameObject);
                        }
                    }
                }
                else if(hit.transform.name == "Quynh Memory")
                {
                    if (QuynhQuestStarted == true)
                    {
                        InteractionActive();
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            QuynhMemoryCollected = true;
                            Destroy(hit.collider.gameObject);
                        }
                    }
                }
            }
            else
            {
                InteractionDeactive();
            }
        else
        {
            InteractionDeactive(); /// In case the player isn't looking at anything the interaction text disables
        }

        Debug.DrawLine(transform.position, hit.point, Color.blue);
    }

    /////////////////////////////// ENABLES/DISABLES Crosshair and Interactions Text////////////////////////////

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

    //////////////////////////////// ACCEPT OR DECLINE BUTTONS FUNCTION ///////////////////////////////

    public void AcceptOffer()
    {
        Objective.SetActive(true);
        Dialogue1.SetActive(false); 
        Dialogue2.SetActive(false);
        OfferButtons.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if(AshTalking == true)
        {
            AshQuest.SetActive(true);
            AshQuestStarted = true;
}
        else if(QuynhTalking == true)
        {
            QuynhQuest.SetActive(true);
            QuynhQuestStarted = true;
        }
        if(AshPaintWallQuest == true)
        {
            PaintTheWall.gameObject.SetActive(true);
            AshPaintingWall.SetActive(true);
        }
        else if(QuynhMemoryCollected == true)
        {
            PaintTheWall.gameObject.SetActive(true);
        }

        //if(AshMemoryCollected == true)
        //{
        //    PaintTheWall.gameObject.SetActive(true);
        //}

    }

    public void DeclineOffer()
    {
        Objective.SetActive(false);
        Dialogue1.SetActive(false);
        Dialogue2.SetActive(false);
        OfferButtons.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void AshSkip()
    {
        if(AshMemoryCollected == true)
        {
            textWriter.AddWriter(DialogueText1, "WOW You found it thanks! Could you just paint it on the wall for me.", 0f, true);
        }
        else if(AshMemoryCollected == false)
        {
            textWriter.AddWriter(DialogueText1, "Ash Hi I am Ash! I've heard a lot about you. Can you do me a favour? Find this memory for me I'll pay you! It is very dear to me.", 0f, true);
        }
    }

    public void QuynhSkip()
    {
        if (QuynhMemoryCollected == true)
        {
            textWriter2.AddWriter(DialogueText2, "WOW You found it thanks! Could you just paint it on the wall for me.", 0f, true);
            Debug.Log("Running Skip");
        }
        else if (QuynhMemoryCollected == false)
        {
            textWriter2.AddWriter(DialogueText2, "Hi I am Quynh! I've heard a lot about you. Can you do me a favour? Find this memory for me I'll pay you! It is very dear to me.", 0f, true);
            Debug.Log("Skipped");
        }
    }

    //IEnumerator AshTalkingDialogue()
    //{
    //    yield return new WaitForSeconds(1f);
    //    if (AshTalkingPart1 == true)
    //        textWriter.AddWriter(DialogueText1, "Ash Hi I am Ash! I've heard a lot about you. Can you do me a favour? Find this memory for me I'll pay you! It is very dear to me.", .1f, true);
    //    else if(AshTalkingPart2 == true)
    //    {
    //        textWriter.AddWriter(DialogueText1, "Test.", .1f, true);
    //    }
    //    else if( AshTalkingPart3 == true)
    //    {
    //        textWriter.AddWriter(DialogueText1, "Tester.", .1f, true);
    //    }

    //}

}
