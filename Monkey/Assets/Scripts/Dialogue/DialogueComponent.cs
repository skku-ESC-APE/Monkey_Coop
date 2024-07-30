using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DialogueComponent : MonoBehaviour
{
    private int index = 0;
    GameManager GM;
    DialogueManager DM;
    public List<DialogueContainer> dialogueContainers; // 대화 컨테이너 리스트

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        DM = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }
    public DialogueContainer GetContainer()
    {
        if (this.gameObject.name == "bookshelf")
        {
            if (GM.amugena)
            {
                return dialogueContainers[1];
            }
            else
            {
                return dialogueContainers[0];
            }
        }

        if (this.gameObject.name == "vent")
        {
            if (GM.amugena)
            {
                return dialogueContainers[1];
            }
            else
            {
                return dialogueContainers[0];
            }
        }

        if (this.gameObject.name == "door")
        {
            if (GM.amugena)
            {
                return dialogueContainers[1];
            }
            else
            {
                return dialogueContainers[0];
            }
        }

        if (this.gameObject.name == "bookshelf")
        {
            if (GM.amugena)
            {
                return dialogueContainers[1];
            }
            else
            {
                return dialogueContainers[0];
            }
        }

        return null;
    }




}
