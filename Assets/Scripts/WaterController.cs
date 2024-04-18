using System.Collections;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private bool hit;
    private BoxCollider2D boxCollider;
    private AudioSource waterFireSound;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        waterFireSound = GetComponent<AudioSource>();
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
            waterFireSound.Play();
        }
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
