using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resource : MonoBehaviour
{
    TextMeshPro resourceText;

    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        resourceText = GetComponent<TextMeshPro>();

        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        resourceText.text = GM.foodQuantity.ToString();
    }


}

