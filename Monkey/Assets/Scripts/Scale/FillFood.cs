using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillFood : MonoBehaviour
{
    public Sprite sprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "CUP")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().mass = 5f;
            collision.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
        }

    }
}
