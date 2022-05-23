using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VerticalAttack : AbilityTemplate
{

    RaycastHit2D hit;
    public Vector2 lastDir;

    public float verticalDamage = 100f; 
    public float verticalAttackRange = 2f;
    public float verticalAttackSpeed = 1f;

    
   
    public override void Activate(GameObject parent)
    {
        if (AbilityHolder.instance.abilities[0].isActive)
        {
            //verticalAttack
            hit = Physics2D.Raycast(PlayerManager.instance.transform.position, new Vector2(0, PlayerManager.instance.lastDir.y), verticalAttackRange);
            //Debug.DrawLine(transform.position, new Vector2(lastDir.x, 0), Color.red, 5f);
            Debug.DrawRay(PlayerManager.instance.transform.position, new Vector2(0, PlayerManager.instance.lastDir.y) * 2, Color.red, 1f);
            //new Raycast(transform.position, lastDir.x, attackDistance, null, null);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Enemy"))
                    hit.collider.gameObject.GetComponent<Enemy>().getDamage(verticalDamage);
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
