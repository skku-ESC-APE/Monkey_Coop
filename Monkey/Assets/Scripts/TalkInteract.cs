using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// TalkInteract Ŭ������ �÷��̾ Ư�� ��ȣ�ۿ��� ������ �� ��ȭ�� �����մϴ�.
/// �� Ŭ������ DialogueManager�� DialogueComponent�� ��ȣ�ۿ��Ͽ� ��ȭ�� �����մϴ�.
/// </summary>
public class TalkInteract : MonoBehaviour
{
    [SerializeField] private Image interactionImage; // ��ȣ�ۿ� ������ �̹���
    [SerializeField] private DialogueComponent dialogueComponent; // DialogueComponent�� �����Ͽ� ��ȭ �����͸� ������
    private DialogueManager dialogueManager;
    private bool isPlayerInRange = false;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager not found in the scene.");
        }

        if (interactionImage != null)
        {
            interactionImage.gameObject.SetActive(false); // �ʱ⿡�� �̹��� ��Ȱ��ȭ
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F key pressed and player is in range.");
            if (dialogueManager != null && dialogueComponent != null)
            {
                // ��ȭ ����
                dialogueManager.StartDialogue(dialogueComponent); // 0�� ���÷� ù ��° ��ȭ �����̳ʸ� ���
            }
            else
            {
                Debug.LogError("DialogueManager or DialogueComponent is null.");
            }
        }

        // ��ȣ�ۿ� �̹��� ��ġ ������Ʈ
        if (isPlayerInRange && interactionImage != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            interactionImage.transform.position = screenPosition + new Vector3(0, 80, 0); // ������ ����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered interaction range.");
            isPlayerInRange = true;
            if (interactionImage != null)
            {
                interactionImage.gameObject.SetActive(true); // �̹��� Ȱ��ȭ
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player exited interaction range.");
            isPlayerInRange = false;
            if (interactionImage != null)
            {
                interactionImage.gameObject.SetActive(false); // �̹��� ��Ȱ��ȭ
            }
        }
    }
}

