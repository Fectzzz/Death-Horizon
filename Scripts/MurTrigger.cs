using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurTrigger : MonoBehaviour
{
    public PlayerMovement scriptPlayer;
    public GameObject player;

    void OnTriggerStay2D(Collider2D player)
    {
        scriptPlayer.TakeDamage(0.05f);
    }
}
