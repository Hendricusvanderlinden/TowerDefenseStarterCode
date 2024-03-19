using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackRange = 1f;
    public float attackRate = 1f;
    public int attackDamage = 1;
    public float attackSize = 1f;
    public GameObject bulletPrefab;
    public TowerType type;

    float attackCooldown = 0f;

    void Update()
    {
        if (attackCooldown <= 0f)
        {
            // Zoek naar vijanden binnen het aanvalsgebied
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

            // Schiet op een van de gevonden vijanden
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    Shoot(collider.transform);
                    break; // Schiet slechts op één vijand per keer
                }
            }

            attackCooldown = 1f / attackRate; // Reset de aanvalskoeltijd
        }

        attackCooldown -= Time.deltaTime; // Verminder de aanvalskoeltijd
    }

    void Shoot(Transform target)
    {
        // Schiet een projectiel naar het doelwit
        GameObject bulletGO = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Projectile bullet = bulletGO.GetComponent<Projectile>();
        if (bullet != null)
        {
            // Stel de variabelen van het projectiel in
            bullet.target = target;
            bullet.speed = 10f; // Stel de snelheid van het projectiel in
            bullet.damage = attackDamage;
            bullet.transform.localScale = new Vector3(attackSize, attackSize, 1f);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Teken de aanvalsrange in de editor voor eenvoudiger debuggen
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}