using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DinoJugador1 : MonoBehaviour
{
    public float VidaJ1 = 100;
    public float EnergiaJ1 = 100;
    public Image VidaUI1;
    public bool infinitev;
    public bool NoMoverse;
    public bool infinitee;
    public Image EnergiaUI1;
    public bool gano;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (infinitee == true)
        {
            EnergiaJ1 += 100;
        }
        if (infinitev == true)
        {
            VidaJ1 += 100;
        }
        if (VidaJ1 < 0)
        {
            VidaJ1 = 0;
        }
        if (VidaJ1 > 100)
        {
            VidaJ1 = 100;
        }
        if (EnergiaJ1 < 0)
        {
            EnergiaJ1 = 0;
        }
        if (EnergiaJ1 > 100)
        {
            EnergiaJ1 = 100;
        }
        VidaUI1.fillAmount = VidaJ1 / 100;
        EnergiaUI1.fillAmount = EnergiaJ1 / 100;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player2") || other.gameObject.CompareTag("Pared"))
        {
            if (Input.GetKey("a"))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.25f, gameObject.transform.position.y, gameObject.transform.position.z);

            }
            if (Input.GetKey("d"))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.25f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }
    }
}
