using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class DamageJ1 : MonoBehaviour
{
    private bool Shield;
    public float NormalDamage;
    public float KnockBackDamage;
    public bool KnockBack;
    public float knockbackForce = 8;
    public GameObject P2;
    public GameObject P1;
    public GameObject BF;
    public Animator BFU;
    private GameObject obj2;
    public bool Shoot;
    private Player1 Player1;
    private Player2 Player2;
    private Vector3 Startu;
    private Animator BFAnimator;
    private bool CanDoUlti = true;
    void Start()
    {
        P2 = GameObject.Find("Player2");
        P1 = GameObject.Find("Player1");
        Player1 = P1.GetComponent<Player1>();
        Player2 = P2.GetComponent<Player2>();
        BF = GameObject.Find("BF");
        BFAnimator = BF.GetComponent<Animator>();
        obj2 = GameObject.Find("BFU");
        BFU = obj2.GetComponent<Animator>();
        Startu = new Vector3(100, 1000, 100);
    }

    // Update is called once per frame
    void Update()
    {
        P2 = GameObject.Find("Player2");
        P1 = GameObject.Find("Player1");
        Player1 = P1.GetComponent<Player1>();
        Player2 = P2.GetComponent<Player2>();
        BF = GameObject.Find("BF");
        BFAnimator = BF.GetComponent<Animator>();
        obj2 = GameObject.Find("BFU");
        BFU = obj2.GetComponent<Animator>();
        Startu = new Vector3(100, 1000, 100);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            if (KnockBack == false)
            {
                Player2.VidaJ2 -= NormalDamage;
                Player1.EnergiaJ1 += NormalDamage;
                Player2.Move = false;
            }
            if (KnockBack == true)
            {
                if (Input.GetKey("l") && Player2.EnergiaJ2 >= 10)
                {
                    Player1.VidaJ1 -= 10;
                    Player2.EnergiaJ2 -= 10;
                    BF.transform.position = gameObject.transform.position;
                    BFAnimator.SetBool("BK", true);
                    BFU.SetBool("BKU", true);
                    Invoke("BlackFlash", 0.5f);
                }
                else
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
                }
                if (Shoot == true && Input.GetKey("l") && Player2.EnergiaJ2 >= 10)
                {
                    Player2.EnergiaJ2 -= 10;
                    CanDoUlti = false;
                    BF.transform.position = gameObject.transform.position;
                    BFAnimator.SetBool("BK", true);
                    BFU.SetBool("BKU", true);
                    Invoke("BlackFlash", 0.5f);
                }
                if (Shoot == true && CanDoUlti == true)
                {
                    Player1.Ulti = true;
                    Player2.VidaJ2 -= 20f;
                    Player2.Move = false;
                    Invoke("NoMoveUlti", Player1.UltiTime);
                }
            }
        }
    }
    void BlackFlash()
    {
        BF.transform.position = Startu;
        BFAnimator.SetBool("BK", false);
        BFU.SetBool("BKU", false);
        CanDoUlti = true;
    }
    void NoMoveUlti()
    {
        Player2.Move = true;
    }
}
