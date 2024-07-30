using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool amugena = false;
    public GameObject Player;
    public SpriteRenderer PlayerSpriteRenderer;
    

    private void Start()
    {
        PlayerSpriteRenderer=GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }
}
