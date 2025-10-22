using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    public bool Move = true;
    public float VidaJ2 = 100;
    public Image BarraDeVidaJ2;
    public Image BarraEnergiaJ2;
    public float EnergiaJ2;
    public bool gano;
    public GameObject obj;
    public GameObject obj2;
    public Animator Animator;
    public float speed = 12;
    public Rigidbody2D rb;
    private Vector2 posicion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        posicion = rb.position;
        obj = GameObject.Find("BarraDeVidaJ2");
        if (obj != null) { BarraDeVidaJ2 = obj.GetComponent<Image>(); }
        obj2 = GameObject.FindWithTag("BarraDeEnergiaJ2");
        if (obj2 != null) { BarraEnergiaJ2 = obj2.GetComponent<Image>(); }
        Animator = GetComponent<Animator>();
        BarraDeVidaJ2.fillAmount = VidaJ2 / 100;
        BarraEnergiaJ2.fillAmount = EnergiaJ2 / 100;

        if (Input.GetKey("left") && Move == true|| Input.GetKey("right") && Move == true)
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
        else { Animator.SetBool("Walk", false); }
    }
}
