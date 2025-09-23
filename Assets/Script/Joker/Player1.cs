using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Player1 : MonoBehaviour
{
    public Image BarraDeVida;
    public Image BarraEnergia;
    public Animator Pantalla;
    public GameObject ShootObj;
    public float VidaJ1;
    public float EnergiaJ1;
    public bool Move = true;
    private Animator Animator;
    public float AttackTime;
    public float SuperTime;
    public float UltiShootTime;
    public float UltiTime;
    public bool Ulti;
    public Vector3 StartPositionBullet;
    public string UltiName;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator = GetComponent<Animator>();
        StartPositionBullet = ShootObj.transform.position;
        GameObject obj = GameObject.Find("BarraDeVidaJ1");
        BarraDeVida = obj.GetComponent<Image>();
        GameObject obj2 = GameObject.Find("BarraDeEnergiaJ2");
        BarraEnergia = obj2.GetComponent<Image>();
        GameObject obj3 = GameObject.Find("Pantalla");
        Pantalla = obj3.GetComponent<Animator>();
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
            Move = false;
            ShootObj.SetActive(true);
            ShootObj.transform.position = new Vector3(ShootObj.transform.position.x + 0.3f, ShootObj.transform.position.y, ShootObj.transform.position.z);
            Invoke("Shoot", 1.5f);
        }
        if (Ulti == true)
        {
            Move = false;
            Pantalla.SetBool(UltiName, true);
            Invoke("Ultimate", UltiTime);
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
        if (Ulti == false)
        {
            Animator.SetBool("Shoot", false);
            ShootObj.SetActive(false);
            Move = true;
            ShootObj.transform.position = StartPositionBullet;
        }
        else{}
    }
    void Ultimate()
    {
        Ulti = false;
        Move = true;
        Pantalla.SetBool(UltiName, false);
    }
}
