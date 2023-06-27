using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltoDetector : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "fondo")
        {
            Debug.Log("Colision");
        }
    }
}
