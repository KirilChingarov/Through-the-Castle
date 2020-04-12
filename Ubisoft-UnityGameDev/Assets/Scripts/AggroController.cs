using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroController : MonoBehaviour
{
    private bool inAggro = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inAggro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inAggro = false;
        }
    }

    public bool isPlayerInAggro()
    {
        return inAggro;
    }
}
