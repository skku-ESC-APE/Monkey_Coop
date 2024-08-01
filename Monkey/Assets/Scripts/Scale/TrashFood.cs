using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashFood : MonoBehaviour
{
    public Sprite sprite;
    GameManager GM;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "CUP")
        {
            if (this.gameObject.name == "pocket" && collision.gameObject.GetComponentInChildren<SpriteRenderer>().sprite != sprite)
            {
                GM.foodQuantity++;
            }
            collision.gameObject.GetComponent<Rigidbody2D>().mass = 1f;
            collision.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            
        }

    }
}
