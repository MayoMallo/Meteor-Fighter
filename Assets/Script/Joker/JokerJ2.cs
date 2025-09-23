using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerJugador2 : MonoBehaviour
{
    public Animator JokerJ2;
    public Animator BarraRota;
    public Animator BarraRota2;
    public bool NoMove;
    private bool Despierto;
    public bool Carga;
    public bool escudo;
    public bool Ultimate;
    public DinoJugador2 ScriptJugador2;
    public GameObject J2;
    public bool fatal;
    // Start is called before the first frame update
    void Start()
    {
        ScriptJugador2 = FindAnyObjectByType<DinoJugador2>();
    }
    // Update is called once per frame
    void Update()
    {
        if (ScriptJugador2.gano == true && fatal == false)
        {
            if(Input.GetKey("o"))
            {
                if(Input.GetKey("k"))
                {
                    BarraRota2.SetBool("FatalJoker", true);
                    Invoke("ya", 0.2f);
                    fatal = true;
                }
            }
            Invoke("normalwin", 10f);
        }
        else
        {
        }
        if (ScriptJugador2.gano == true)
        {
            if(Input.GetKey("o"))
            {
                if(Input.GetKey("k"))
                {
                    
                }
            }
            Invoke("normalwin", 3f);
        }
        else
        {
        }
        if (Despierto == true && ScriptJugador2.EnergiaJ2 >= 0.15)
        {
            ScriptJugador2.EnergiaJ2 -= 0.15f;
        }
        else{Despierto = false;}
        if (Input.GetKey("k") && NoMove == false)
        {
            escudo = true;
            JokerJ2.SetBool("Shield", true);
        }
        else
        {
            JokerJ2.SetBool("Shield", false);
            escudo = false;
        }
        if (Input.GetKey("j") && NoMove == false)
        {
            Carga = true;
            ScriptJugador2.EnergiaJ2 += 0.3f;
            JokerJ2.SetBool("Carga", true);
            if(ScriptJugador2.EnergiaJ2 >= 100 && ScriptJugador2.VidaJ2 <= 35 && Despierto == false)
            {
                Invoke("Awk", 3f);

            }
            else{}
        }
        else
        {
            Carga = false;
            JokerJ2.SetBool("Carga", false);
        }
        if (Carga == false && escudo == false)
        {
            if (Input.GetKey("right") && NoMove == false)
            {
                J2.transform.position = new Vector3(J2.transform.position.x + 0.25f, J2.transform.position.y, J2.transform.position.z);
                //gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.25f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (Input.GetKey("left") && NoMove == false)
            {
                J2.transform.position = new Vector3(J2.transform.position.x - 0.25f, J2.transform.position.y, J2.transform.position.z);
                //gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.25f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (Input.GetKey("left") && NoMove == false|| Input.GetKey("right") && NoMove == false)
            {
                JokerJ2.SetBool("Walk", true);
            }
            else
            {
                JokerJ2.SetBool("Walk", false);
            }
            if (Input.GetKey("u") && NoMove == false && ScriptJugador2.EnergiaJ2>= 15)
            {
                ScriptJugador2.EnergiaJ2 -= 15;
                NoMove = true;
                JokerJ2.SetBool("Super", true);
                Invoke("JokerSuper2",1.6f);
            }
            if (Input.GetKey("i") && NoMove == false)
            {
                JokerJ2.SetBool("Punch", true);
                NoMove = true;
                Invoke("JokerPunch2" ,2.7f);
            }
            if (Input.GetKey("o") && NoMove == false && ScriptJugador2.EnergiaJ2 >= 25)
            {
                ScriptJugador2.EnergiaJ2 -= 25;
                JokerJ2.SetBool("Shoot", true);
                NoMove = true;
                Invoke ("JokerShoot", 1.3f);
            }
            if (ScriptJugador2.EnergiaJ2 <= 0.16 && Despierto == true)
            {
                BarraRota2.SetBool("Awkin", true);
                Invoke ("Dest", 0.1f);
                BarraRota.SetBool("AwkJ1", false);
                JokerJ2.SetBool("Awk", false);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("AttackJ1"))
        {
            NoMove = true;
            Invoke("NMTrue", 0.5f);
        }
    }
    void JokerSuper2()
    {
        JokerJ2.SetBool("Super", false);
        NoMove = false;
    }
    void JokerPunch2()
    {
        JokerJ2.SetBool("Punch", false);
        NoMove = false;
    }
    void JokerShoot()
    {
        if (Ultimate == false)
        {
            JokerJ2.SetBool("Shoot", false);
            NoMove = false;
        }
    }
    void NMTrue()
    {
        NoMove = true;
    }
    void Awk()
    {
        if(Input.GetKey("j"))
        {
            Despierto = true;
            BarraRota.SetBool("AwkJ1", true);
            Invoke ("Awk2", 3f);
        }
    }
    void Awk2()
    {
            BarraRota2.SetBool("Awkin", true);
            JokerJ2.SetBool("Awk", true);
            Invoke ("Dest", 0.1f);
    }
    void Dest()
    {
        BarraRota2.SetBool("Awkin", false);
    }
    void normalwin()
    {
        if (fatal == false){
        BarraRota2.SetBool("WinJoker", true);}
    }
    void ya()
    {
        BarraRota2.SetBool("FatalJoker", false);
    }
}
