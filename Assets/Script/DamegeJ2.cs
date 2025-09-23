using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DamageJ2 : MonoBehaviour
{
    private bool Shield;
    public float NormalDamage;
    public float KnockBackDamage;
    public bool KnockBack;
    public float knockbackForce = -8;
    public MonoBehaviour[] inputScripts;
    public DinoJugador1 ScriptJugador1;

    // StartGis called before the first frame update
    void Start()
    {
        ScriptJugador1 = FindAnyObjectByType<DinoJugador1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player1") && Shield == false)
        {
            if (KnockBack == false)
            {
                ScriptJugador1.VidaJ1 -= NormalDamage;
            }
            if (KnockBack == true)
            {
                ScriptJugador1.VidaJ1 -= KnockBackDamage;
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                // Calcula la dirección del knockback (45 grados arriba y hacia la derecha)
                Vector2 knockbackDirection = new Vector2(1, -1).normalized;
                
                // Aplica la fuerza de knockback
                rb.linearVelocity = Vector2.zero; // Resetea la velocidad actual
                rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                }
            }
        }
        
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Shield"))
        {
            Shield = true;
            if (KnockBack == false)
            {
                ScriptJugador1.VidaJ1 -= NormalDamage / 2;
            }
            if (KnockBack == true)
            {
                ScriptJugador1.VidaJ1 -= KnockBackDamage / 2;
            }
        }
        else
        {
            Shield = false;
        }
    }
    public void DisableInput()
    {
        foreach (MonoBehaviour script in inputScripts)
        {
            script.enabled = false;
        }
    }
    public void EnableInput()
    {
        foreach (MonoBehaviour script in inputScripts)
        {
            script.enabled = true;
        }
    }
}