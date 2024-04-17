using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollectible : MonoBehaviour
{
    public int waterAmount = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerAttack playerAttack = collision.gameObject.GetComponent<PlayerAttack>();
            playerAttack.waterQty = waterAmount;
            Destroy(gameObject);
        }
    }
}
