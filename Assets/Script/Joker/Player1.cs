using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Player1 : MonoBehaviour
{
    public Image BarraDeVida;
    public Image BarraEnergia;
    public GameObject Shoot;
    public float VidaJ1;
    public float EnergiaJ1;
    public bool Move = true;
    private Animator Animator;
    public float AttackTime;
    public float SuperTime;
    public float UltiShootTime;
    public float UltiTime;
    public Vector3 StartPositionBullet;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator = GetComponent<Animator>();
        StartPositionBullet = Shoot.transform.position;
        GameObject obj = GameObject.Find("BarraDeVida");
        BarraDeVida = obj.GetComponent<Image>();
        GameObject obj2 = GameObject.Find("BarraDeEnergia");
        BarraEnergia = obj2.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        BarraDeVida.fillAmount = VidaJ1 / 100;
        BarraEnergia.fillAmount = EnergiaJ1 / 100;
        if (EnergiaJ1 > 100)
        { EnergiaJ1 = 100; }
        if (EnergiaJ1 < 0)
        { EnergiaJ1 = 0; }
        if (Input.GetKey("a") && Move == true || Input.GetKey("d") && Move == true)
        {
            Animator.SetBool("Walk", false);
            if (Input.GetKey("a"))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.25f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (Input.GetKey("d"))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.25f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }
        else { Animator.SetBool("Walk", false); }
        if (Input.GetKey("e") && Move == true && EnergiaJ1 >= 20)
        {
            EnergiaJ1 -= 20;
            Animator.SetBool("Super", true);
            Move = false;
            Invoke("Super", SuperTime);
        }
        if (Input.GetKey("r") && Move == true)
        {
            Animator.SetBool("Attack", true);
            Move = false;
            Invoke("Attack", AttackTime);
        }
        if (Input.GetKey("t") && Move == true && EnergiaJ1 >= 35)
        {
            Animator.SetBool("Shoot", true);
            Shoot.SetActive(true);
            Shoot.transform.position = new Vector3(Shoot.transform.position.x + 0.3f, Shoot.transform.position.y, Shoot.transform.position.z);

        }
    }
    void Attack()
    {
        Animator.SetBool("Attack", false);
        Move = true;
    }
    void Super()
    {
        Animator.SetBool("Super", false);
        Move = true;
    }
    void Shoot()
    {
        
    }
}
