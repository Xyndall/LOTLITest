using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]

public class NPCDialouge : MonoBehaviour
{
    public Transform ChatBackGround;
    public Transform NPCCharacter;

    public DialougeSystem dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;


    void Start()
    {
        dialogueSystem = FindObjectOfType<DialougeSystem>();
    }


    public void OnTriggerStay(Collider other)
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y += 10;
        ChatBackGround.position = Pos;
        this.gameObject.GetComponent<NPCDialouge>().enabled = true;

        if ((other.gameObject.tag == "Player")) 
        {


            this.gameObject.GetComponent<NPCDialouge>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialougeSystem>().NPCName();
        }
    }



    public void OnTriggerExit()
    {
        FindObjectOfType<DialougeSystem>().OutOfRange();
        this.gameObject.GetComponent<NPCDialouge>().enabled = false;
    }
}
