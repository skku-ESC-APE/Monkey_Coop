using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool amugena = false;
    public bool SnakeMetamorphose = false;
    public bool Puzzle1Activate = false;
    
    public GameObject Player;
    public SpriteRenderer PlayerSpriteRenderer;
    public int foodQuantity = 0;

    private void Start()
    {
        PlayerSpriteRenderer=GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }
}
