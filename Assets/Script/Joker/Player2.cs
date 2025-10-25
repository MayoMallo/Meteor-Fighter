using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public float speed = 12f;
    private bool falta;
    public static Player2 instancia;
    public Image BarraDeVida;
    public Image BarraEnergia;
    public Animator Pantalla;
    public GameObject ShootObj;
    public float VidaJ2;
    public float EnergiaJ2;
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
    public GameObject Objetive;
    public Player1 Objetivee;
    private bool ShootSi;
    private Rigidbody2D rb;
    private Vector2 posicion;
    private float speedbullet = 24f;
    public bool cpu;
    public int AccionCpu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        InvokeRepeating("CpuAc", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Objetive = GameObject.Find("Player1");
        Objetivee = Objetive.GetComponent<Player1>();
        StartPositionBullet = new Vector3(100, 1000, 100);
        Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        posicion = rb.position;
        ShootObj = GameObject.Find("ShootJ2");
        obj = GameObject.Find("BarraDeVidaJ2");
        if (obj != null) { BarraDeVida = obj.GetComponent<Image>(); }
        obj2 = GameObject.FindWithTag("BarraDeEnergiaJ2");
        if (obj2 != null) { BarraEnergia = obj2.GetComponent<Image>(); }
        obj3 = GameObject.FindWithTag("Pantalla");
        Pantalla = obj3.GetComponent<Animator>();
        BarraDeVida.fillAmount = VidaJ2 / 100;
        BarraEnergia.fillAmount = EnergiaJ2 / 100;
        if (EnergiaJ2 >= 100)
        { EnergiaJ2 = 100; }
        if (EnergiaJ2 <= 0)
        { EnergiaJ2 = 0; }
        if (Input.GetKey("left") && Move == true && cpu == false || Input.GetKey("right") && Move == true && cpu == false)
        {
            Animator.SetBool("Walk", true);
            if (Input.GetKey("right"))
            {
                gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey("left"))
            {
                gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else
        {
            Animator.SetBool("Walk", false);
        }
        if (cpu == false)
        {
            if (Input.GetKey("i") && Move == true && EnergiaJ2 >= 20)
            {
                Move = false;
                Animator.SetBool("Super", true);
                EnergiaJ2 -= 20;
                Invoke("Super", SuperTime);
            }
            if (Input.GetKey("o") && Move == true)
            {
                Animator.SetBool("Attack", true);
                Move = false;
                Invoke("Attack", AttackTime);
            }
            if (Input.GetKey("p") && Move == true && EnergiaJ2 >= 35)
            {
                ShootObj.transform.position = gameObject.transform.position;
                Animator.SetBool("Shoot", true);
                ShootSi = true;
                Move = false;
                EnergiaJ2 -= 35;
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
                ShootObj.transform.position += Vector3.left * speedbullet * Time.deltaTime;
            }
            if (ShootSi == false) { ShootObj.transform.position = StartPositionBullet; }
            if (gano == true && Input.GetKey("p") && Input.GetKey("i") && falta == false)
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
        if (cpu == true && Move == true)
        {
            if (AccionCpu == 0)
            {
                if (gameObject.transform.position.x > Objetive.transform.position.x + 6.5f && gameObject.transform.position.x < Objetive.transform.position.x + 9.5f && Move == true && EnergiaJ2 >= 20f)
                {
                    Move = false;
                    Animator.SetBool("Super", true);
                    EnergiaJ2 -= 20;
                    Invoke("Super", SuperTime);
                    Invoke("CpuAc", SuperTime);
                }
                if (gameObject.transform.position.x < Objetive.transform.position.x + 6.5f && Move == true)
                {
                    Animator.SetBool("Walk", true);
                    gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
                }
                if (gameObject.transform.position.x > Objetive.transform.position.x + 9.5f && Move == true)
                {
                    Animator.SetBool("Walk", true);
                    gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
                }
                else { Animator.SetBool("Walk", false); }
            }
            if (AccionCpu == 1 && Move == true)
            {
                if (gameObject.transform.position.x < Objetive.transform.position.x + 5f && Move == true)
                {
                    Animator.SetBool("Attack", true);
                    Move = false;
                    Invoke("Attack", AttackTime);
                    Invoke("CpuAc", AttackTime);
                }
                if (gameObject.transform.position.x > Objetive.transform.position.x + 5f && Move == true)
                {
                    Animator.SetBool("Walk", true);
                    gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
                }
                else { Animator.SetBool("Walk", false); }
            }
            if (AccionCpu == 2)
            {
                if (gameObject.transform.position.x > Objetive.transform.position.x + 9.5f && Move == true && EnergiaJ2 >= 35)
                {
                    Move = false;
                    ShootObj.transform.position = gameObject.transform.position;
                    Animator.SetBool("Shoot", true);
                    ShootSi = true;
                    Move = false;
                    EnergiaJ2 -= 35;
                    Invoke("Shoot", UltiShootTime);
                    Invoke("CpuAc", UltiShootTime);
                }
                if (gameObject.transform.position.x < Objetive.transform.position.x + 9.5f && Move == true)
                {
                    Animator.SetBool("Walk", true);
                    gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
                }
                else { Animator.SetBool("Walk", false); }
            }
            if (AccionCpu == 3)
            {
                if (gameObject.transform.position.x > Objetive.transform.position.x + 9.5f && Move == true && EnergiaJ2 >= 35)
                {
                    ShootObj.transform.position = gameObject.transform.position;
                    Animator.SetBool("Shoot", true);
                    ShootSi = true;
                    Move = false;
                    EnergiaJ2 -= 35;
                    Invoke("Shoot", UltiShootTime);
                    Invoke("CpuAc", UltiShootTime);
                }
                if (gameObject.transform.position.x < Objetive.transform.position.x + 5f && Move == true)
                {
                    Animator.SetBool("Attack", true);
                    Move = false;
                    Invoke("Attack", AttackTime);
                    Invoke("CpuAc", AttackTime);
                }
                if (gameObject.transform.position.x > Objetive.transform.position.x + 6.5f && gameObject.transform.position.x < Objetive.transform.position.x + 9.5f && Move == true && EnergiaJ2 >= 20f)
                {
                    Move = false;
                    Animator.SetBool("Super", true);
                    EnergiaJ2 -= 20;
                    Invoke("Super", SuperTime);
                    Invoke("CpuAc", SuperTime);
                }
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
                ShootObj.transform.position += Vector3.left * speedbullet * Time.deltaTime;
            }
            if (ShootSi == false) { ShootObj.transform.position = StartPositionBullet; }
            if (gano == true && Input.GetKey("p") && Input.GetKey("i") && falta == false)
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
    }
    void Attack()
    {Animator.SetBool("Attack", false);
        if (Objetivee.Ulti == false){
            
            Move = true;
        }
    }
    void Super()
    {Animator.SetBool("Super", false);
        if (Objetivee.Ulti == false){
        
        Move = true;}
    }
    void Shoot()
    {
        if (Ulti == false)
        {
            Animator.SetBool("Shoot", false);
            ShootSi = false;
            if (Objetivee.Ulti == false){
            Move = true;
        }
            
        }
        
    }
    void Ultimate()
    {
        Ulti = false;
        Pantalla.SetBool(UltiName, false);
        if (Objetivee.Ulti == false){
        
        Move = true;
        }
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
    void CpuAc()
    {
        if(EnergiaJ2 >= 35 && Move == true)
        {
            AccionCpu = Random.Range(0, 4);
        }
        if (EnergiaJ2 >= 20 && EnergiaJ2 < 35 && Move == true)
        {
            AccionCpu = Random.Range(0, 2);
        }
        if (EnergiaJ2 < 20 && Move == true)
        {
            AccionCpu = Random.Range(1, 2);
        }
    }
}
