using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{

    public static RoundManager instancia;
    public DinoJugador1 ScriptJugador1;
    public DinoJugador2 ScriptJugador2;
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
        originalPosition = J1.transform.position;
        originalPosition2 = J2.transform.position;
        ScriptJugador1 = FindAnyObjectByType<DinoJugador1>();
        ScriptJugador2 = FindAnyObjectByType<DinoJugador2>();
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
        J1 = GameObject.FindWithTag("Player1");
        J2 = GameObject.FindWithTag("Player2");
        ScriptJugador1 = FindAnyObjectByType<DinoJugador1>();
        ScriptJugador2 = FindAnyObjectByType<DinoJugador2>();
        if (ScriptJugador1.VidaJ1 <= 0 && VictoriaJ2 == 0 && VictoriaJ1 == 0)
        {
            pantalla.SetBool("Round2", true);
            Invoke("reset", 2f);
            Invoke("RoundEnd", 0f);
            Invoke("NextRound", 2f);
            Invoke("gano2", 2f);
            Win1J2.SetActive(true);
        }
        if (ScriptJugador2.VidaJ2 <= 0 && VictoriaJ1 == 0 && VictoriaJ2 == 0)
        {
            pantalla.SetBool("Round2", true);
            Invoke("reset", 2f);
            Invoke("RoundEnd", 0f);
            Invoke("NextRound", 2f);
            Invoke("gano1", 2f);
            Win1.SetActive(true);
        }
        if (ScriptJugador1.VidaJ1 <= 0 && VictoriaJ2 == 0 && VictoriaJ1 == 1)
        {
            pantalla.SetBool("Round3", true);
            Invoke("reset", 2f);
            Invoke("RoundEnd", 0f);
            Invoke("NextRound", 2f);
            Invoke("gano2", 2f);
            Win1J2.SetActive(true);
        }
        if (ScriptJugador2.VidaJ2 <= 0 && VictoriaJ1 == 0 && VictoriaJ2 == 1)
        {
            pantalla.SetBool("Round3", true);
            Invoke("gano1", 2f);
            Invoke("reset", 2f);
            Invoke("RoundEnd", 0f);
            Invoke("NextRound", 2f);
            Win1.SetActive(true);
        }

        if (ScriptJugador2.VidaJ2 <=0 && VictoriaJ1 == 1)
        {
            ScriptJugador1.gano = true;
            J2.SetActive(false);
            Win2.SetActive(true);
        }
        if (ScriptJugador1.VidaJ1 <=0 && VictoriaJ2 == 1)
        {
            ScriptJugador2.gano = true;
            J1.SetActive(false);
            win2J2.SetActive(true);
        }
        
    }
    void RoundEnd()
    {
        J1.SetActive(false);
        J2.SetActive(false);
    }
    void NextRound()
    {
        pantalla.SetBool("Round2", false);
        pantalla.SetBool("Round3", false);
        J1.SetActive(true);
        J2.SetActive(true);
        J1.transform.position = originalPosition;
        J2.transform.position = originalPosition2;
        ScriptJugador1.VidaJ1 = 100;
        ScriptJugador1.EnergiaJ1 = 100;
        ScriptJugador2.VidaJ2 = 100;
        ScriptJugador2.EnergiaJ2 = 100;
    }
    void Reset()
    {
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
