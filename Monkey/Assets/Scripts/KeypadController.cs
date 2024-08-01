using UnityEngine;
using UnityEngine.UI; // Button 클래스를 사용하기 위한 네임스페이스
using TMPro;

public class KeypadController : MonoBehaviour
{
    public TextMeshProUGUI[] digitFields; // 각 자릿수별 TextMeshProUGUI 텍스트
    public TextMeshProUGUI inputField; // TextMeshProUGUI 텍스트
    public string correctAnswer = "56971"; // 정답

    public string currentInput = "";

    void Start()
    {
        // 각 버튼의 이벤트 핸들러를 추가합니다.
        for (int i = 0; i <= 9; i++)
        {
            string number = i.ToString();
            GameObject button = GameObject.Find("Button" + number);
            if (button != null)
            {
                button.GetComponent<Button>().onClick.AddListener(() => OnNumberButtonClicked(number));
            }
        }

        // Clear 버튼 이벤트 핸들러를 추가합니다.
        GameObject clearButton = GameObject.Find("ClearButton");
        if (clearButton != null)
        {
            clearButton.GetComponent<Button>().onClick.AddListener(ClearInput);
        }

        // Enter 버튼 이벤트 핸들러를 추가합니다.
        GameObject enterButton = GameObject.Find("EnterButton");
        if (enterButton != null)
        {
            enterButton.GetComponent<Button>().onClick.AddListener(CheckInput);
        }
    }

    void OnNumberButtonClicked(string number)
    {
        if (currentInput.Length < 5) // 최대 5자리 숫자만 입력
        {
            currentInput += number;
            UpdateDigitFields();
        }
    }

    public void ClearInput()
    {
        currentInput = "";
        UpdateDigitFields();
    }

    public void CheckInput()
    {
        if (currentInput == correctAnswer)
        {
            UnityEngine.Debug.Log("Correct!"); // UnityEngine.Debug 사용
            PuzzleClear();
        }
        else
        {
            UnityEngine.Debug.Log("Incorrect!"); // UnityEngine.Debug 사용
        }
    }

    private void UpdateDigitFields()
    {
        // 고정된 위치에서 숫자를 표시합니다.
        for (int i = 0; i < digitFields.Length; i++)
        {
            if (i < currentInput.Length)
            {
                digitFields[i].text = currentInput[i].ToString();
            }
            else
            {
                digitFields[i].text = "";
            }
        }
    }

    public void PuzzleClear()
    {
        GameObject CAGE = GameObject.Find("CAGE");
        if (CAGE != null)
        {
            CAGE.SetActive(false);
        }

        this.gameObject.SetActive(false);
    }
}
