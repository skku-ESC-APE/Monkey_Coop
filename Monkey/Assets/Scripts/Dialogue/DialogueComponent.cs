using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.Mathematics;

public class DialogueComponent : MonoBehaviour
{
    private int index = 0;
    GameManager GM;
    DialogueManager DM;
    public List<DialogueContainer> dialogueContainers; // 대화 컨테이너 리스트
    public bool isSpriteChange = false;
    public bool isCPMove = false;
    public Sprite newSprite;
    public float playerx;
    public float playery;
    public float Camx;
    public float Camy;

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
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == newSprite)
            {
                isCPMove = true;
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

        if (this.gameObject.name == "CAGE")
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

        if (this.gameObject.name == "door (1)")
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

        if (this.gameObject.name == "door (2)")
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

        if (this.gameObject.name == "door (3)")
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

        if (this.gameObject.name == "book_nipper")
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

        if (this.gameObject.name == "book_sissors")
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

        if (this.gameObject.name == "book_wrench")
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

        if (this.gameObject.name == "burlap_closed")
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

    public void SpriteChange()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
    public void CamPlayerMove()
    {

    }



}
