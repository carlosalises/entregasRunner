using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VaixellController : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(3, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ChMovimiento")
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = rb.velocity * -1;

            if (rb.velocity.x < 0)
                GetComponent<SpriteRenderer>().flipX = true;
            else
                GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
