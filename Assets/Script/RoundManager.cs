using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{

    public static RoundManager instancia;
    public Player1 Player1;
    public Player2 Player2;
    public GameObject Win1;
    public GameObject Win2;
    public GameObject Win1J2;
    public GameObject win2J2;
    public GameObject J1;
    public GameObject J2;
    public GameObject kill;
    public Animator pantalla;
    public Vector3 originalPosition;
    public Vector3 originalPosition2;
    public int VictoriaJ1;
    public int VictoriaJ2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        J1 = GameObject.Find("Player1");
        J2 = GameObject.Find("Player2");
        originalPosition = J1.transform.position;
        originalPosition2 = J2.transform.position;
        Player1 = FindAnyObjectByType<Player1>();
        Player2 = FindAnyObjectByType<Player2>();
    }
    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        J1 = GameObject.Find("Player1");
        J2 = GameObject.Find("Player2");
        Player1 = FindAnyObjectByType<Player1>();
        Player2 = FindAnyObjectByType<Player2>();
        if (Player1.VidaJ1 <= 0 && VictoriaJ2 == 0 && VictoriaJ1 == 0)
        {
            pantalla.SetBool("Round2", true);
            Invoke("reset", 2f);
            Invoke("NextRound", 2f);
            Invoke("gano2", 2f);
            Win1J2.SetActive(true);
        }
        if (Player2.VidaJ2 <= 0 && VictoriaJ1 == 0 && VictoriaJ2 == 0)
        {
            pantalla.SetBool("Round2", true);
            Invoke("reset", 2f);
            Invoke("NextRound", 2.01f);
            Invoke("gano1", 2f);
            Win1.SetActive(true);
        }
        if (Player1.VidaJ1 <= 0 && VictoriaJ2 == 0 && VictoriaJ1 >= 1)
        {
            pantalla.SetBool("Round3", true);
            Invoke("reset", 2f);
            Invoke("NextRound", 2f);
            Invoke("gano2", 2f);
            Win1J2.SetActive(true);
        }
        if (Player2.VidaJ2 <= 0 && VictoriaJ1 == 0 && VictoriaJ2 >= 1)
        {
            pantalla.SetBool("Round3", true);
            Invoke("gano1", 2f);
            Invoke("reset", 2f);
            Invoke("NextRound", 2f);
            Win1.SetActive(true);
        }

        if (Player2.VidaJ2 <=0 && VictoriaJ1 >= 1)
        {
            Player1.gano = true;
            J2.SetActive(false);
            Win2.SetActive(true);
        }
        if (Player1.VidaJ1 <=0 && VictoriaJ2 >= 1)
        {
            Player2.gano = true;
            J1.SetActive(false);
            win2J2.SetActive(true);
        }
        
    }
    void NextRound()
    {
        pantalla.SetBool("Round2", false);
        pantalla.SetBool("Round3", false);
        J1.SetActive(true);
        J2.SetActive(true);
        J1.transform.position = originalPosition;
        J2.transform.position = originalPosition2;
        Player1.VidaJ1 = 100;
        Player1.EnergiaJ1 = 100;
        Player2.VidaJ2 = 100;
        Player2.EnergiaJ2 = 100;
    }
    void Reset()
    {
        Destroy(J1);
        Destroy(J2);
        SceneManager.LoadScene("TestFight");
    }
    void gano1()
    {
        VictoriaJ1 += 1;
    }
    void gano2()
    {
        VictoriaJ2 += 1;
    }
}
