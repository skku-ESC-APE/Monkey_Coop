using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;

    public GameObject monkeyPrefab;
    public GameObject snakePrefab;

    private GameObject currentAnimal;
    private Animator animator;

    // 크기 조정 변수
    public Vector3 monkeyScale = new Vector3(1f, 1f, 1f);
    public Vector3 snakeScale = new Vector3(1f, 1f, 1f);

    void Start()
    {
        // 게임 시작 시 원숭이로 변신하며 초기 위치 설정
        TransformToMonkey();
        // 플레이어 위치를 화면의 중앙으로 조정 (필요에 따라 수정 가능)
        currentAnimal.transform.position = new Vector3(0, -5f, 0);
        currentAnimal.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    void Update()
    {
        Move();
        HandleTransformation();
    }

    void Move()
    {
        float moveInput = 0;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1;
            // 왼쪽 방향으로 회전
            currentAnimal.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1;
            // 오른쪽 방향으로 회전
            currentAnimal.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        Vector3 move = new Vector3(moveInput * walkSpeed * Time.deltaTime, 0, 0);
        currentAnimal.transform.position += move;

        bool isWalking = moveInput != 0;
        animator.SetBool("isWalking", isWalking);
    }

    void HandleTransformation()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TransformToMonkey();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TransformToSnake();
        }
    }

    void TransformToMonkey()
    {
        Vector3 currentPosition = currentAnimal != null ? currentAnimal.transform.position : new Vector3(0, 2.51f, 0);
        if (currentAnimal != null) Destroy(currentAnimal);
        currentAnimal = Instantiate(monkeyPrefab, currentPosition, Quaternion.identity);
        currentAnimal.transform.localScale = monkeyScale; // 원숭이 크기 조정
        currentAnimal.transform.position = new Vector3(currentPosition.x, -5f, currentPosition.z); // 원숭이 높이 설정
        animator = currentAnimal.GetComponent<Animator>();
        ResetAnimatorParameters();
    }

    void TransformToSnake()
    {
        Vector3 currentPosition = currentAnimal != null ? currentAnimal.transform.position : new Vector3(0, 2.0f, 0);
        if (currentAnimal != null) Destroy(currentAnimal);
        currentAnimal = Instantiate(snakePrefab, currentPosition, Quaternion.identity);
        currentAnimal.transform.localScale = snakeScale; // 뱀 크기 조정
        currentAnimal.transform.position = new Vector3(currentPosition.x, -6.5f, currentPosition.z); // 뱀 높이 설정
        animator = currentAnimal.GetComponent<Animator>();
        ResetAnimatorParameters();
    }

    void ResetAnimatorParameters()
    {
        animator.SetBool("isWalking", false);
    }
}
