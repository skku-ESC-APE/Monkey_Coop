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

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        dialoguePanel.SetActive(false);
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
        if (dialogueContainer == null || dialogueText == null || characterNameText == null)
        {
            Debug.LogError("One or more references are null.");
            return;
        }

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

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        Debug.Log("Dialogue ended.");

        // 메모장 비활성화
        if (this.gameObject.name == "memo" && dialogueContainer == GM.GetComponent<DialogueComponent>().dialogueContainers[1])
        {
            GameObject Memo = GameObject.Find("memo");
            if (Memo != null)
            {
                Memo.SetActive(false);
            }
        }





        if (fadeManager != null)
        {
            fadeManager.LoadSceneWithFade("GameScene");
        }
    }
}
