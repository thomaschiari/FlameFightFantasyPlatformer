using System.Collections;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private bool hit;
    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(DestroyAfterTime(1));  // Destrói o projétil após 1 segundo
    }

    void Update()
    {
        if (hit)
        {
            boxCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            hit = true;
        }
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
