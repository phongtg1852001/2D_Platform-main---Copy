using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public Vector2 knockback = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
        {
            Vector2 deliveredKnockback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, -knockback.y);

            bool gotHit = damageable.Hit(attackDamage, deliveredKnockback);
            if (gotHit)
            {
                Debug.Log(collision.name + " hit for " + attackDamage);
                PlayerController playerController = GetComponentInParent<PlayerController>();
                if (!damageable.IsAlive && playerController != null)
                {
                    playerController.OnEnemyDefeated();
                }
            }
        }
    }
}