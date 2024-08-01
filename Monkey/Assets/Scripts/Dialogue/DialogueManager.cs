using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Text characterNameText;
    [SerializeField] private Image characterImage1;
    [SerializeField] private Image characterImage2;
    [SerializeField] private FadeManager fadeManager;
    private DialogueContainer dialogueContainer;
    private int currentLineIndex = 0;
    GameManager GM;
    public GameObject PUZZLE1;
    GameObject CAGE;
    GameObject Memo;
    GameObject Glass;
    GameObject Yang;
    CameraController CC;
    GameObject mainCamera;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        dialoguePanel.SetActive(false);
        PUZZLE1 = GameObject.Find("Keypad");
        PUZZLE1.SetActive(false);
        CAGE = GameObject.Find("CAGE");
        Memo = GameObject.Find("memo");
        Glass = GameObject.Find("Glass");
        Yang = GameObject.Find("Yang");
        CC = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    private void Update()
    {
        if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            ShowNextLine();
        }
    }

    public void StartDialogue(DialogueComponent dialogueComponent)
    {
        dialogueContainer = dialogueComponent.GetContainer();

        if (dialogueContainer != null)
        {
            Debug.Log("Starting dialogue with container: " + dialogueContainer.name);
            currentLineIndex = 0;
            dialoguePanel.SetActive(true);
            if (characterImage1 != null)
            {
                characterImage1.enabled = true;
            }
            ShowNextLine();
        }
        else
        {
            Debug.LogError("No suitable Dialogue Container found for the given index.");
        }
    }

    private void ShowNextLine()
    {

        if (currentLineIndex < dialogueContainer.lines.Count)
        {
            DialogueLine line = dialogueContainer.lines[currentLineIndex];
            if (line == null)
            {
                Debug.LogError($"Dialogue Line at index {currentLineIndex} is null.");
                return;
            }

            characterNameText.text = line.characterName;
            dialogueText.text = line.text;

            if (characterImage1 != null)
            {
                characterImage1.sprite = GM.PlayerSpriteRenderer.sprite;
                characterImage1.enabled = true;
            }

            if (characterImage2 != null)
            {
                characterImage2.sprite = line.characterImage2;
                characterImage2.enabled = line.characterImage2 != null;
            }

            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        
        if (Memo)
        {
            if (dialogueContainer == Memo.GetComponent<DialogueComponent>().dialogueContainers[0])
            {

                Memo.SetActive(false);
            }
        }
        

        if (CAGE)
        {
            if (dialogueContainer == CAGE.GetComponent<DialogueComponent>().dialogueContainers[0])
                    {

                        if (PUZZLE1.activeSelf == false)
                        {
                            PUZZLE1.SetActive(true);
                        }
                    }
        }

        if (Glass)
        {
            if (dialogueContainer == Glass.GetComponent<DialogueComponent>().dialogueContainers[2])
            {
                GM.SnakeMetamorphose = true;
            }
        }

        if (Yang)
        {
            if (dialogueContainer == Yang.GetComponent<DialogueComponent>().dialogueContainers[0])
            {
                CC.enabled = false;
                mainCamera.transform.position = new Vector3(0f, 30f, -10f);
                
            }
        }






        dialoguePanel.SetActive(false);
        Debug.Log("Dialogue ended.");

 
        







        if (fadeManager != null)
        {
            fadeManager.LoadSceneWithFade("GameScene");
        }
    }
}
