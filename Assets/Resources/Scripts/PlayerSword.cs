using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    Vector3 position; // Add a semicolon here
    public int attackPower = 0;
    public int knockbackForce;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.localPosition;
    }

    void IsFacingRight(bool isFacingRight) // Fix the typo in method name (optional)
    {
        if (isFacingRight)
        {
            transform.localPosition = position;
        }
        else
        {
            transform.localPosition = new Vector3(-position.x, position.y, position.z); // Fix the typo here
        }
    }

    // Update is called once per frame /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Idamageable damageable = collider.GetComponent<Idamageable>();

        if(damageable != null){
            Vector3 _position = transform.parent.position;
            Vector2 direction = collider.transform.position - _position;

            
            damageable.OnHit(attackPower, direction * knockbackForce);
        }
        
    }
    void Update()
    {
        
    }
}
