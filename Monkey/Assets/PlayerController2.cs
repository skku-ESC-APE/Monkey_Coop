using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float swimSpeed = 4f;

    public GameObject monkeyPrefab;
    public GameObject snakePrefab;
    public GameObject fishPrefab;

    private GameObject currentAnimal;
    private Animator animator;
    private string currentForm = "Monkey";

    void Start()
    {
        TransformToMonkey(); // 초기 상태는 원숭이
    }

    void Update()
    {
        Move();
        HandleTransformation();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (currentForm == "Monkey" || currentForm == "Snake")
        {
            float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            Vector3 move = new Vector3(moveInput * speed * Time.deltaTime, 0, 0);
            currentAnimal.transform.Translate(move);

            bool isWalking = moveInput != 0 && !Input.GetKey(KeyCode.LeftShift);
            bool isRunning = moveInput != 0 && Input.GetKey(KeyCode.LeftShift);

            animator.SetBool("isWalking", isWalking);
            animator.SetBool("isRunning", isRunning);
        }
        else if (currentForm == "Fish")
        {
            Vector3 move = new Vector3(moveInput * swimSpeed * Time.deltaTime, verticalInput * swimSpeed * Time.deltaTime, 0);
            currentAnimal.transform.Translate(move);

            bool isSwimming = moveInput != 0 || verticalInput != 0;
            animator.SetBool("isSwimming", isSwimming);
        }
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
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TransformToFish();
        }
    }

    void TransformToMonkey()
    {
        if (currentAnimal != null) Destroy(currentAnimal);
        currentAnimal = Instantiate(monkeyPrefab, transform.position, Quaternion.identity);
        currentForm = "Monkey";
        animator = currentAnimal.GetComponent<Animator>();
        ResetAnimatorParameters();
    }

    void TransformToSnake()
    {
        if (currentAnimal != null) Destroy(currentAnimal);
        currentAnimal = Instantiate(snakePrefab, transform.position, Quaternion.identity);
        currentForm = "Snake";
        animator = currentAnimal.GetComponent<Animator>();
        ResetAnimatorParameters();
    }

    void TransformToFish()
    {
        if (currentAnimal != null) Destroy(currentAnimal);
        currentAnimal = Instantiate(fishPrefab, transform.position, Quaternion.identity);
        currentForm = "Fish";
        animator = currentAnimal.GetComponent<Animator>();
        ResetAnimatorParameters();
    }

    void ResetAnimatorParameters()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isSwimming", false);
    }
}
