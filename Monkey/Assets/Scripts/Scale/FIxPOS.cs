using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIxPOS : MonoBehaviour
{
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = pos;
    }
}
