using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAlfredo1 : MonoBehaviour
{
    public AlfredoJugador1 AlfredoJ1;
    public DinoJugador2 Dino2;
    public Animator AlfredoooJ1;
    public Animator Pantalla;
    private bool shield;
    void Start()
    {
        AlfredoJ1 = FindAnyObjectByType<AlfredoJugador1>();
    }
    void Update()
    {
        if (AlfredoJ1.Ultimate == true)
        {
            Invoke("Ultimate", 7.4f);
        }
        Invoke ("resetshoot", 1.1f);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.4f, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player2") && shield == false)
        {
            Dino2.VidaJ2 -= 20;
            AlfredoooJ1.SetBool("Shoot", false);
            Invoke("Jokerr", 0.5f);
            Pantalla.SetBool("Freddy", true);
            AlfredoJ1.NoMove = true;
            AlfredoJ1.Ultimate = true;
        }
        if (other.gameObject.CompareTag("Shield"))
        {
            shield = true;
        }
        else
        {
            shield = false;
        }
    }
    void Ultimate()
    {
        AlfredoJ1.NoMove = false;
        AlfredoJ1.Ultimate = false;
    }
    void resetshoot()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.4f, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    void Jokerr()
    {
        Pantalla.SetBool("Freddy", false);
    }
}