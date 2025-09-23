using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DinoJugador2 : MonoBehaviour
{
    public bool gano;
    public float VidaJ2 = 100;
    public float EnergiaJ2 = 100;
    public Image VidaUI2;
    public Image EnergiaUI2;
    public bool infinitee;
    public bool infinitev;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (infinitev == true)
        {
            VidaJ2 += 100;
        } 
        if (infinitee == true)
        {
            EnergiaJ2 += 100;
        }
        if (VidaJ2 < 0)
        {
            VidaJ2 = 0;
        }
        if (VidaJ2 > 100)
        {
            VidaJ2 = 100;
        }
        if (EnergiaJ2 < 0)
        {
            EnergiaJ2 = 0;
        }
        if (EnergiaJ2 > 100)
        {
            EnergiaJ2 = 100;
        }
        VidaUI2.fillAmount = VidaJ2 / 100;
        EnergiaUI2.fillAmount = EnergiaJ2 / 100;
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

