using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageChar : MonoBehaviour, Idamageable
{
    Rigidbody2D rb;

    Collider2D phyCollider;

    public int health;

    public int Health{
        get{
            return health;
        }
        set{
            health = value;
            if(health <= 0){
                gameObject.BroadcastMessage("OnDie");
                Targetable = false;
            }
            else{
                gameObject.BroadcastMessage("OnDamage");
            }
        }
    }

    bool targetable;

    public bool Targetable{
        get{
            return targetable;
        }
        set{
            targetable = value;
            if(!targetable){
                rb.simulated = false;
            }
            
        }
    }


    public void OnHit(int damage, Vector2 knockback){
        rb.AddForce(knockback);
        Health -= damage;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        phyCollider = GetComponent<Collider2D>();
        
    }

}
