using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderHcr : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "enemy")
        {
            Destroy(col.gameObject);
        }
    }
}

