using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            Extinguish();
        }
    }

    void Extinguish()
    {
        Debug.Log("Fire extinguished.");
        Destroy(gameObject);  // Destrói o objeto de fogo
    }
}
