using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public PlayerMovement playerScript;
    public int actualCoin;

    public void Update()
    {
        actualCoin = playerScript.allCoin;
    }
}
