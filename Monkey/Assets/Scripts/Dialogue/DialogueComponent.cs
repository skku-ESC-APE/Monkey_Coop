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
    public bool isFirst = true;
    public Sprite newSprite;
    public float playerx;
    public float playery;
    public float Camx;
    public float Camy;
    public CameraController CamCon;
    Dragger dragger;
    Dragger ND;

    public GameObject CCTV;
    public GameObject Glass;
    



    [SerializeField]
    public Vector2 CCC;
    [SerializeField]
    public Vector2 CCMS;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        DM = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        CamCon = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();
        dragger = this.gameObject.GetComponent<Dragger>();
        ND = GameObject.FindWithTag("Nippers").GetComponent<Dragger>();

    }

    public DialogueContainer GetContainer()
    {
        if (this.gameObject.name == "memo")
        {
            return dialogueContainers[0];
        }

        if (this.gameObject.name == "bookshelf")
        {
            return dialogueContainers[0];
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

            return dialogueContainers[0];

        }

        if (this.gameObject.name == "desk 1")
        {

            return dialogueContainers[0];

        }

        if (this.gameObject.name == "locker (1)")
        {

            return dialogueContainers[0];
            
        }

        if (this.gameObject.name == "Locker1")
        {


            return dialogueContainers[0];
            
        }

        if (this.gameObject.name == "Locker2")
        {


            return dialogueContainers[0];
            
        }

        if (this.gameObject.name == "Locker3")
        {

                return dialogueContainers[0];

        }


        

        if (this.gameObject.name == "Glass")
        {
            if (isFirst == true)
            {
                isFirst = false;
                return dialogueContainers[0];
                
            }

            else if (isFirst == false && ND.puzzleState != "clear")
            {
                return dialogueContainers[1];
            }

            else if (isFirst == false && ND.puzzleState == "clear")
            {
                return dialogueContainers[2];
            }




        }

        if (this.gameObject.name == "glass_empty")
        {

            return dialogueContainers[0];

        }

        if (this.gameObject.name == "yang")
        {

            
            return dialogueContainers[0];
            
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

            return dialogueContainers[0];
            
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

                return dialogueContainers[0];
            
        }

        if (this.gameObject.name == "door7")
        {

                return dialogueContainers[0];
            
        }



        if (this.gameObject.name == "book_nipper")
        {

                return dialogueContainers[0];
            
        }

        if (this.gameObject.name == "book_sissors")
        {

                return dialogueContainers[0];
            
        }

        if (this.gameObject.name == "book_wrench")
        {

                return dialogueContainers[0];
            
        }

        if (this.gameObject.name == "burlap_closed")
        {

                return dialogueContainers[0];
            
        }

        if (this.gameObject.name == "Yang")
        {

            return dialogueContainers[0];

        }

        if (this.gameObject.name == "CCTV normal")
        {
            if (isFirst == true)
            {
                isFirst = false;
                return dialogueContainers[0];

            }

            else if (isFirst == false)
            {
                
            }

        }


        if (this.gameObject.name == "Hammer")
        {
            SpriteRenderer spriteRenderer = CCTV.gameObject.GetComponent<SpriteRenderer>();
            

            if (spriteRenderer.sprite == dragger.cctvDamagedSprite)
            {
                return dialogueContainers[0];
            }
            if (spriteRenderer.sprite == dragger.cctvClearSprite)
            {
                return dialogueContainers[1];
            }
        }


        if (this.gameObject.name == "Nippers")
        {
            SpriteRenderer spriteRenderer = CCTV.gameObject.GetComponent<SpriteRenderer>();


            if (spriteRenderer.sprite == dragger.cctvDamagedSprite)
            {
                return dialogueContainers[0];
            }
            if (spriteRenderer.sprite == dragger.cctvClearSprite)
            {
                return dialogueContainers[1];
            }
        }

        if (this.gameObject.name == "Scissors")
        {
            SpriteRenderer spriteRenderer = CCTV.gameObject.GetComponent<SpriteRenderer>();


            if (spriteRenderer.sprite == dragger.cctvDamagedSprite)
            {
                return dialogueContainers[0];
            }
            if (spriteRenderer.sprite == dragger.cctvClearSprite)
            {
                return dialogueContainers[1];
            }
        }

        if (this.gameObject.name == "Wrench")
        {
            SpriteRenderer spriteRenderer = CCTV.gameObject.GetComponent<SpriteRenderer>();


            if (spriteRenderer.sprite == dragger.cctvDamagedSprite)
            {
                return dialogueContainers[0];
            }
            if (spriteRenderer.sprite == dragger.cctvClearSprite)
            {
                return dialogueContainers[1];
            }
        }

        if (this.gameObject.name == "tilefish")
        {
            if (GM.foodQuantity == 0 )
            {
                return dialogueContainers[0];
            }

            else if (GM.foodQuantity == 5)
            {
                return dialogueContainers[1];
            }
            else
            {
                return dialogueContainers[2];
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
