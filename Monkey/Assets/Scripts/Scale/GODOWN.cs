using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GODOWN : MonoBehaviour
{
    GameObject MC;
    private void Start()
    {
        MC = GameObject.FindWithTag("MainCamera");
    }
    void OnMouseDown()
    {
        MC.transform.position += new Vector3(0, -30, 0);
    }
}
