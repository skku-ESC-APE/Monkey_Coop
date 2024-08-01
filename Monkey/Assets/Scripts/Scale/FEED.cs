using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    GameManager GM;
    CameraController CC;
    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        CC = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();
    }
    void OnMouseDown()
    {
        CC.enabled = true;
    }
}
