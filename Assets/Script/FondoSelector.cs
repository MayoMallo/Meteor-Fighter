using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FondoSelector : MonoBehaviour
{
    private RectTransform rectTransform;
    private float entradax;
    private float entraday;
    public float Slotx;
    public int Slot;
    public float Sloty;
    public bool enput;
    public Image image;
    public Sprite fondo1;
    public Sprite fondo2;
    public Sprite fondo3;
    public Sprite fondo4;
    public Sprite fondo5;
    public Sprite fondo6;
    public Sprite fondo7;
    public Sprite fondo8;
    [System.Serializable]
    public class Fondos
    {
        public static FondoSelector instance;
        public string name;
        public GameObject Map;

    }
    public List<Fondos> Maps = new List<Fondos>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Coco();
    }
    void Update()
    {
        entradax = Input.GetAxis("Horizontal");
        entraday = Input.GetAxis("Vertical");
        if (entraday > 0 && Sloty > 0 && enput == false)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + 157f);
            Maps[Slot].Map.SetActive(false);
            Slot -= 4;
            Sloty -= 1;
            Maps[Slot].Map.SetActive(true);
            StartCoroutine(DelayInput(0.3f));
        }
        if (entraday < 0 && Sloty < 1 && enput == false)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - 157f);
            Maps[Slot].Map.SetActive(false);
            Sloty += 1;
            Slot += 4;
            Maps[Slot].Map.SetActive(true);
            StartCoroutine(DelayInput(0.3f));
        }
        if (entradax > 0 && Slotx < 3 && enput == false) //d
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + 320f, rectTransform.anchoredPosition.y);
            Maps[Slot].Map.SetActive(false);
            Slotx += 1;
            Slot += 1;
            Maps[Slot].Map.SetActive(true);
            StartCoroutine(DelayInput(0.3f));
        }
        if (entradax < 0 && Slotx > 0 && enput == false) //a
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x - 320f, rectTransform.anchoredPosition.y);
            Maps[Slot].Map.SetActive(false);
            Slotx -= 1;
            Slot -= 1;
            Maps[Slot].Map.SetActive(true);
            StartCoroutine(DelayInput(0.3f));
        }

        if (Sloty == 1)
        {
            if (Slotx == 0)
            {
                image.sprite = fondo5;
            }
            if (Slotx == 1)
            {   
                image.sprite = fondo6;
            }
            if (Slotx == 2)
            {

            }
            if (Slotx == 3)
            {

            }
        }
        if (Sloty == 0)
        {
            if (Slotx == 0)
            {
                image.sprite = fondo1;
            }
            if (Slotx == 1)
            {
                image.sprite = fondo2;
            }
            if (Slotx == 2)
            {
                image.sprite = fondo3;
            }
            if (Slotx == 3)
            {
                image.sprite = fondo4;
            }
        }
        if (Input.GetKey("e"))
        {
            SceneManager.LoadScene("Selector");
        }
    }
    void Coco()
    {
        Slot += 1;
        Maps[Slot].Map.SetActive(true);  
    }
    IEnumerator DelayInput(float tiempo)
    {
        enput = true;
        yield return new WaitForSeconds(tiempo);
        enput = false;
    }
}
