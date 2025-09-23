using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DamageJ1 : MonoBehaviour
{
    private bool Shield;
    public float NormalDamage;
    public float KnockBackDamage;
    public bool KnockBack;
    public float knockbackForce = 8;
    public GameObject Player2;
    public GameObject Player1;
    public bool Shoot;

    // StartGis called before the first frame update
    void Start()
    {
        Player2 = GameObject.Find("Player2");
        Player1 = GameObject.Find("Player1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            if (KnockBack == false)
            {
                Player2.Player2.VidaJ2 -= NormalDamage;
                Player1.EnergiaJ1 += NormalDamage;
                Player2.Move = false;
            }
            if (KnockBack == true)
            {
                Player2.VidaJ2 -= KnockBackDamage;
                Player1.EnergiaJ1 += KnockBackDamage;
                Player2.Move = false;
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 knockbackDirection = new Vector2(1, 1).normalized;
                    rb.linearVelocity = Vector2.zero;
                    rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                }
                if (Shoot == true)
                {

                }
            }
        }
        
    }
}
