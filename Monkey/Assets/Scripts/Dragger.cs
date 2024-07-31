using UnityEngine;
using UnityEngine.UI;

public class Dragger : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Vector3 _originalPosition;
    private Camera _cam;
    [SerializeField] private float _speed = 100f;
    private bool _isDragging = false;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody;
    private GameObject _currentHoverObject;
    [SerializeField] private GameObject clearUI; // Clear UI 오브젝트

    private string puzzleState = "incomplete"; // puzzle2 상태 관리

    [SerializeField] private Sprite cctvDamagedSprite; // CCTV 1차 파괴 스프라이트
    [SerializeField] private Sprite cctvClearSprite;   // CCTV 2차 파괴 (clear 상태) 스프라이트

    void Awake()
    {
        _cam = Camera.main;
        _originalPosition = transform.position;
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (_collider == null)
        {
            _collider = gameObject.AddComponent<BoxCollider2D>();
            _collider.isTrigger = true; // 트리거로 설정
            Debug.LogWarning("Collider2D가 없어서 BoxCollider2D를 추가했습니다.");
        }

        if (_rigidbody == null)
        {
            _rigidbody = gameObject.AddComponent<Rigidbody2D>();
            _rigidbody.isKinematic = true; // 중력의 영향을 받지 않도록 설정
            Debug.LogWarning("Rigidbody2D가 없어서 추가했습니다.");
        }

        if (clearUI != null)
        {
            clearUI.SetActive(false); // Clear UI를 비활성화
        }
    }

    void OnMouseDown()
    {
        if (puzzleState == "clear") return;

        Debug.Log("OnMouseDown 호출됨");
        if (!_isDragging)
        {
            StartDragging();
        }
    }

    void OnMouseUp()
    {
        if (puzzleState == "clear") return;

        Debug.Log("OnMouseUp 호출됨");
        if (_isDragging)
        {
            Interact();
            ReturnToOriginalPosition();
            StopDragging();
        }
    }

    void Update()
    {
        if (puzzleState == "clear") return;

        if (_isDragging)
        {
            DragObject();
        }

        if (_currentHoverObject != null)
        {
            Debug.Log("현재 호버 중인 오브젝트는: " + _currentHoverObject.name);
        }
    }

    void FixedUpdate()
    {
        if (puzzleState == "clear") return;

        CheckForHoverObject();
    }

    void CheckForHoverObject()
    {
        // 충돌하는 모든 콜라이더를 저장할 배열 생성
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, _collider.bounds.size, 0);

        // 현재 호버 중인 오브젝트 초기화
        _currentHoverObject = null;

        // 충돌하는 콜라이더 중 CCTV 태그를 가진 오브젝트를 찾음
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("CCTV"))
            {
                _currentHoverObject = hitCollider.gameObject;
                Debug.Log(hitCollider.tag + " 태그 오브젝트와 충돌 중: " + _currentHoverObject.name);
                break;
            }
        }
    }

    public void StartDragging()
    {
        Debug.Log("StartDragging 호출됨");
        _isDragging = true;
        _dragOffset = transform.position - GetMousePos();
        if (_rigidbody != null)
        {
            _rigidbody.isKinematic = true;
        }
        if (_collider != null)
        {
            _collider.enabled = false;
        }
    }

    public void StopDragging()
    {
        Debug.Log("StopDragging 호출됨");
        _isDragging = false;
        if (_rigidbody != null)
        {
            _rigidbody.isKinematic = false;
        }
        if (_collider != null)
        {
            _collider.enabled = true;
        }
    }

    public void ReturnToOriginalPosition()
    {
        Debug.Log("ReturnToOriginalPosition 호출됨");
        transform.position = _originalPosition;
    }

    void DragObject()
    {
        Debug.Log("DragObject 호출됨");
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
    }

    public void Interact()
    {
        Debug.Log("Interact 호출됨");
        if (_currentHoverObject != null)
        {
            Debug.Log("현재 호버 중인 오브젝트: " + _currentHoverObject.name);

            if (_currentHoverObject.CompareTag("CCTV"))
            {
                SpriteRenderer cctvSpriteRenderer = _currentHoverObject.GetComponent<SpriteRenderer>();
                if (cctvSpriteRenderer != null)
                {
                    if (gameObject.CompareTag("hammerwrench") && cctvSpriteRenderer.sprite != cctvClearSprite)
                    {
                        if (cctvSpriteRenderer.sprite != cctvDamagedSprite && cctvDamagedSprite != null)
                        {
                            cctvSpriteRenderer.sprite = cctvDamagedSprite;
                            Debug.Log("CCTV가 1차 파괴되었습니다.");
                        }
                        else if (cctvSpriteRenderer.sprite == cctvDamagedSprite && cctvClearSprite != null)
                        {
                            cctvSpriteRenderer.sprite = cctvClearSprite;
                            Debug.Log("CCTV가 2차 파괴(클리어 상태)되었습니다.");
                        }
                    }
                    else if (gameObject.CompareTag("Nippers") && cctvSpriteRenderer.sprite == cctvClearSprite)
                    {
                        ClearPuzzle();
                    }
                }
            }
        }
        else
        {
            Debug.Log("상호작용할 오브젝트가 없습니다.");
        }
    }

    void ClearPuzzle()
    {
        Debug.Log("모든 액션이 종료되었습니다. Puzzle2가 클리어되었습니다.");
        puzzleState = "clear"; // puzzle2 상태를 clear로 변경
        Time.timeScale = 0; // 게임 시간 멈춤

        if (clearUI != null)
        {
            clearUI.SetActive(true); // Clear UI 활성화
        }
    }

    Vector3 GetMousePos()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = _cam.WorldToScreenPoint(transform.position).z;
        return _cam.ScreenToWorldPoint(mousePos);
    }
}
