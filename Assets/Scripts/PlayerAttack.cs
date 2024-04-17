using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float cooldown = 1.0f;
    private PlayerController playerController;
    private float timer;
    public GameObject waterPrefab;
    public Transform projectileSpawn;
    public float projectileDist = 0.1f;  // Distância do projétil em relação ao jogador
    private GameObject currentWaterProjectile; // Referência ao projétil atual
    public int waterQty = 5;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && timer <= 0 && playerController.canAttack() && waterQty > 0)
        {
            Attack();
            waterQty--;
        }
        else if (currentWaterProjectile != null)
        {
            // Ajusta a posição do projétil para que fique sempre a mesma distância do jogador, considerando a direção que ele está virado
            float direction = Mathf.Sign(playerController.transform.localScale.x);
            currentWaterProjectile.transform.position = projectileSpawn.position + (transform.right * projectileDist * direction);
        }
        timer -= Time.deltaTime;
    }
    private void Attack()
    {
        timer = cooldown;
        if (waterPrefab && projectileSpawn)
        {
            float direction = Mathf.Sign(playerController.transform.localScale.x);
            Vector3 spawnPosition = projectileSpawn.position + (transform.right * projectileDist * direction);
            
            // Determinar a rotação do projétil baseada na direção do jogador
            Quaternion rotation = Quaternion.Euler(0, direction == 1 ? 0 : 180, 0); // Rotaciona o sprite 180 graus se estiver virado para a esquerda

            currentWaterProjectile = Instantiate(waterPrefab, spawnPosition, rotation);
            currentWaterProjectile.transform.SetParent(transform);  // Faz o projétil seguir o jogador
        }
    }
}
