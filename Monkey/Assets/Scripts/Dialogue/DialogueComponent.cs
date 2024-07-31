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
    public CameraController CamCon;

    [SerializeField]
    public Vector2 CCC;
    [SerializeField]
    public Vector2 CCMS;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        DM = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        CamCon = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();
    }

    public DialogueContainer GetContainer()
    {
        if (this.gameObject.name == "memo")
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

        if (this.gameObject.name == "vent")
        {
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == newSprite && GameObject.FindWithTag("Player").transform.GetChild(0).name != "Taipan(Clone)")
            {
                return dialogueContainers[1];
            }
            else if(!GM.SnakeMetamorphose)
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

        if (this.gameObject.name == "desk 1")
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

        if (this.gameObject.name == "locker (1)")
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

        if (this.gameObject.name == "Locker1")
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

        if (this.gameObject.name == "Locker2")
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

        if (this.gameObject.name == "glass_empty")
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

        if (this.gameObject.name == "yang")
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


        if (this.gameObject.name == "door1")
        {
            if (isSpriteChange)
            {
                return null;
            }

            if (isCPMove)
            {
                return null;
            }

            return null;
        }

        if (this.gameObject.name == "door2")
        {
            if (isSpriteChange)
            {
                return null;
            }

            if (isCPMove)
            {
                return null;
            }

            return null;
        }

        if (this.gameObject.name == "door3")
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

        if (this.gameObject.name == "door4")
        {
            if (isSpriteChange)
            {
                return null;
            }

            if (isCPMove)
            {
                return null;
            }

            return null;
        }

        if (this.gameObject.name == "door5")
        {
            if (isSpriteChange)
            {
                return null;
            }

            if (isCPMove)
            {
                return null;
            }

            return null;
        }

        if (this.gameObject.name == "door6")
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

        if (this.gameObject.name == "door7")
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
        GameObject.Find("Player").transform.position = new Vector3(playerx, playery, -5);
        CamCon.center = CCC;
        CamCon.mapSize = CCMS;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(CCC, CCMS * 2);
    }

}
