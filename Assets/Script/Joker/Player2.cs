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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obj = GameObject.Find("BarraDeVidaJ2");
        if (obj != null) { BarraDeVidaJ2 = obj.GetComponent<Image>(); }
        obj2 = GameObject.FindWithTag("BarraDeEnergiaJ2");
        if (obj2 != null) { BarraEnergiaJ2 = obj2.GetComponent<Image>(); }
        Animator = GetComponent<Animator>();
        BarraDeVidaJ2.fillAmount = VidaJ2 / 100;
        BarraEnergiaJ2.fillAmount = EnergiaJ2 / 100;

        if (Input.GetKey("left") || Input.GetKey("right"))
        {
            Animator.SetBool("Walk", true);
            if (Input.GetKey("right"))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.25f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else {gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.25f, gameObject.transform.position.y, gameObject.transform.position.z);}
        }
        else { Animator.SetBool("Walk", false); }
    }
}
