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
        TransformToMonkey(); // 초기 상태는 원숭이
        transform.position = new Vector3(0, 2.5f, 0); // 게임 시작 시 위치 초기화(직접 지정해두셈ㅇㅇ)
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
        transform.position += move; // 빈 오브젝트를 이동

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
        Vector3 currentPosition = transform.position; // 빈 오브젝트의 위치 가져오기
        if (currentAnimal != null) Destroy(currentAnimal);
        currentAnimal = Instantiate(monkeyPrefab, currentPosition, Quaternion.identity);
        currentAnimal.transform.localScale = monkeyScale; // 원숭이 크기 조정
        currentAnimal.transform.SetParent(transform); // 빈 오브젝트의 자식으로 설정
        animator = currentAnimal.GetComponent<Animator>();
        ResetAnimatorParameters();
    }

    void TransformToSnake()
    {
        Vector3 currentPosition = transform.position; // 빈 오브젝트의 위치 가져오기
        if (currentAnimal != null) Destroy(currentAnimal);
        currentAnimal = Instantiate(snakePrefab, currentPosition, Quaternion.identity);
        currentAnimal.transform.localScale = snakeScale; // 뱀 크기 조정
        currentAnimal.transform.SetParent(transform); // 빈 오브젝트의 자식으로 설정
        animator = currentAnimal.GetComponent<Animator>();
        ResetAnimatorParameters();
    }

    void ResetAnimatorParameters()
    {
        animator.SetBool("isWalking", false);
    }
}
