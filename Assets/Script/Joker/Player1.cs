using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    public float speed = 12f;
    private bool falta;
    public static Player1 instancia;
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
    public string FatalityName;
    public string WinName;
    public bool gano;
    public GameObject obj;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject Player;
    private bool ShootSi;
    private Rigidbody2D rb;
    private Vector2 posicion;
    private float speedbullet = 24f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        StartPositionBullet = new Vector3(100, 1000, 100);
        Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        posicion = rb.position;
        ShootObj = GameObject.Find("ShootJ1");
        obj = GameObject.Find("BarraDeVidaJ1");
        if (obj != null) { BarraDeVida = obj.GetComponent<Image>(); }
        obj2 = GameObject.FindWithTag("BarraDeEnergiaJ1");
        if (obj2 != null) { BarraEnergia = obj2.GetComponent<Image>(); }
        obj3 = GameObject.FindWithTag("Pantalla");
        Pantalla = obj3.GetComponent<Animator>();
        BarraDeVida.fillAmount = VidaJ1 / 100;
        BarraEnergia.fillAmount = EnergiaJ1 / 100;
        if (EnergiaJ1 >= 100)
        { EnergiaJ1 = 100; }
        if (EnergiaJ1 <= 0)
        { EnergiaJ1 = 0; }
        if (Input.GetKey("a") && Move == true || Input.GetKey("d") && Move == true)
        {
            Animator.SetBool("Walk", true);
            if (Input.GetKey("d"))
            {
                gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else
        {
            Animator.SetBool("Walk", false);
        }
        if (Input.GetKey("e") && Move == true && EnergiaJ1 >= 20)
        {
            Move = false;
            Animator.SetBool("Super", true);
            EnergiaJ1 -= 20;
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
            ShootObj.transform.position = gameObject.transform.position;
            Animator.SetBool("Shoot", true);
            ShootSi = true;
            Move = false;
            EnergiaJ1 -= 35;
            Invoke("Shoot", UltiShootTime);
        }
        if (Ulti == true)
        {
            ShootSi = false;
            Move = false;
            Pantalla.SetBool(UltiName, true);
            Animator.SetBool("Shoot", false);
            Invoke("Ultimate", UltiTime);
        }
        if (ShootSi == true)
        {
            ShootObj.transform.position += Vector3.right * speedbullet * Time.deltaTime;
        }
        if (ShootSi == false) { ShootObj.transform.position = StartPositionBullet; }
        if (gano == true && Input.GetKey("t") && Input.GetKey("e") && falta == false)
        {
            falta = true;
            Pantalla.SetBool(FatalityName, true);
            Invoke("Fata", 1f);
        }
        if (gano == true)
        {
            Invoke("Win", 5f);
            Invoke("Win2", 5.2f);
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
            ShootSi = false;
            Move = true;
        }
        else { }
    }
    void Ultimate()
    {
        Ulti = false;
        Move = true;
        Pantalla.SetBool(UltiName, false);
    }
    void Win()
    {   if (falta == false)
        {
            Pantalla.SetBool(WinName, true);
        }
    }
    void Win2()
    {
        if (falta == false)
        {
            Pantalla.SetBool(WinName, false);
        }
    }
    void Fata()
    {
        Pantalla.SetBool(FatalityName, false);
    }
}
