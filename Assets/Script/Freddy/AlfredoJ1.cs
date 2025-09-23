using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlfredoJugador1 : MonoBehaviour
{
    public Animator AlfredoJ1;
    public Animator BarraRota;
    public Animator BarraRota1;
    public bool NoMove;
    private bool Despierto;
    public bool Carga;
    public bool escudo;
    public bool Ultimate;
    public DinoJugador1 ScriptJugador1;
    public bool fatal;
    public GameObject J1;
    // Start is called before the first frame update
    void Start()
    {
        ScriptJugador1 = FindAnyObjectByType<DinoJugador1>();
    }
    // Update is called once per frame
    void Update()
    {
        if (ScriptJugador1.gano == true && fatal == false)
        {
            if(Input.GetKey("f"))
            {
                if(Input.GetKey("g"))
                {
                    BarraRota1.SetBool("FatalAlfredo", true);
                    Invoke("ya", 0.2f);
                    fatal = true;
                }
            }
            Invoke("normalwin", 10f);
        }
        else
        {
        }
        if (Despierto == true && ScriptJugador1.EnergiaJ1 >= 0.15)
        {
            ScriptJugador1.EnergiaJ1 -= 0.15f;
        }
        else{Despierto = false;}
        if (Input.GetKey("g") && NoMove == false)
        {
            escudo = true;
            AlfredoJ1.SetBool("Shield", true);
        }
        else
        {
            AlfredoJ1.SetBool("Shield", false);
            escudo = false;
        }
        if (Input.GetKey("r") && NoMove == false)
        {
            Carga = true;
            ScriptJugador1.EnergiaJ1 += 0.3f;
            AlfredoJ1.SetBool("Carga", true);
            if(ScriptJugador1.EnergiaJ1 >= 100 && ScriptJugador1.VidaJ1 <= 35 && Despierto == false)
            {
                Invoke("Awk", 3f);

            }
            else{}
        }
        else
        {
            Carga = false;
            AlfredoJ1.SetBool("Carga", false);
        }
        if (Carga == false && escudo == false)
        {
            if (Input.GetKey("d") && NoMove == false)
            {
                J1.transform.position = new Vector3(J1.transform.position.x + 0.25f, J1.transform.position.y, J1.transform.position.z);
                //gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.25f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (Input.GetKey("a") && NoMove == false)
            {
                J1.transform.position = new Vector3(J1.transform.position.x - 0.25f, J1.transform.position.y, J1.transform.position.z);
                //gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.25f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (Input.GetKey("a") && NoMove == false|| Input.GetKey("d") && NoMove == false)
            {
                AlfredoJ1.SetBool("Walk", true);
            }
            else
            {
                AlfredoJ1.SetBool("Walk", false);
            }
            if (Input.GetKey("e") && NoMove == false && ScriptJugador1.EnergiaJ1 >= 15)
            {
                ScriptJugador1.EnergiaJ1 -= 15;
                NoMove = true;
                AlfredoJ1.SetBool("Super", true);
                Invoke("AlfredoSuper1",1.6f);
            }
            if (Input.GetKey("t") && NoMove == false)
            {
                AlfredoJ1.SetBool("Punch", true);
                NoMove = true;
                Invoke("AlfredoPunch1" ,2.7f);
            }
            if (Input.GetKey("f") && NoMove == false && ScriptJugador1.EnergiaJ1 >= 25)
            {
                ScriptJugador1.EnergiaJ1 -= 25;
                AlfredoJ1.SetBool("Shoot", true);
                NoMove = true;
                Invoke ("AlfredoShoot", 1.3f);
            }
            if (ScriptJugador1.EnergiaJ1 <= 0.16 && Despierto == true)
            {
                BarraRota1.SetBool("Awkin", true);
                Invoke ("Dest", 0.1f);
                BarraRota.SetBool("AwkJ1", false);
                AlfredoJ1.SetBool("Awk", false);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("AttackJ2"))
        {
            NoMove = true;
            Invoke("NMTrue", 0.5f);
        }
    }
    void AlfredoSuper1()
    {
        AlfredoJ1.SetBool("Super", false);
        NoMove = false;
    }
    void AlfredoPunch1()
    {
        AlfredoJ1.SetBool("Punch", false);
        NoMove = false;
    }
    void AlfredoShoot()
    {
        if (Ultimate == false)
        {
            AlfredoJ1.SetBool("Shoot", false);
            NoMove = false;
        }
    }
    void NMTrue()
    {
        NoMove = true;
    }
    void Awk()
    {
        if(Input.GetKey("r"))
        {
            Despierto = true;
            BarraRota.SetBool("AwkJ1", true);
            Invoke ("Awk2", 3f);
        }
    }
    void Awk2()
    {
            BarraRota1.SetBool("Awkin", true);
            AlfredoJ1.SetBool("Awk", true);
            Invoke ("Dest", 0.1f);
    }
    void Dest()
    {
        BarraRota1.SetBool("Awkin", false);
    }
    void normalwin()
    {
        if (fatal == false){
        BarraRota1.SetBool("WinAlfredo", true);}
    }
    void ya()
    {
        BarraRota1.SetBool("FatalAlfredo", false);
    }
}
