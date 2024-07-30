using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// TalkInteract 클래스는 플레이어가 특정 상호작용을 수행할 때 대화를 시작합니다.
/// 이 클래스는 DialogueManager와 DialogueComponent와 상호작용하여 대화를 시작합니다.
/// </summary>
public class TalkInteract : MonoBehaviour
{
    [SerializeField] private Image interactionImage; // 상호작용 아이콘 이미지
    [SerializeField] private DialogueComponent dialogueComponent; // DialogueComponent를 참조하여 대화 데이터를 가져옴
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
            interactionImage.gameObject.SetActive(false); // 초기에는 이미지 비활성화
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F key pressed and player is in range.");
            if (dialogueManager != null && dialogueComponent != null)
            {
                // 대화 시작
                dialogueManager.StartDialogue(dialogueComponent); // 0은 예시로 첫 번째 대화 컨테이너를 사용
            }
            else
            {
                Debug.LogError("DialogueManager or DialogueComponent is null.");
            }
        }

        // 상호작용 이미지 위치 업데이트
        if (isPlayerInRange && interactionImage != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            interactionImage.transform.position = screenPosition + new Vector3(0, 80, 0); // 오프셋 적용
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
                interactionImage.gameObject.SetActive(true); // 이미지 활성화
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
                interactionImage.gameObject.SetActive(false); // 이미지 비활성화
            }
        }
    }
}

