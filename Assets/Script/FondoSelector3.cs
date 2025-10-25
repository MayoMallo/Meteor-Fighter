using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FondoSelector3 : MonoBehaviour
{
    private RectTransform rectTransform;
    public GameObject J2;
    public RectTransform J2P;
    public float Slotx;
    public float Slotx2;
    public float Sloty;
    public float Sloty2;
    public bool enput;
    public bool enput2;
    public Image image;
    public Image image2;
    public Sprite fondo1;
    public Sprite fondo2;
    public Sprite fondo3;
    public Sprite fondo4;
    public Sprite fondo5;
    public Sprite fondo6;
    public Sprite fondo7;
    public Sprite fondo8;
    public Sprite fondo9;
    public Sprite fondo10;
    public Sprite fondo11;
    public Sprite fondo12;
    public Sprite fondo13;
    public Sprite fondo14;
    public Sprite fondo15;
    public Sprite fondo16;
    public Sprite Solo1;
    public Sprite Solo2;
    public Sprite ambos;
    public bool J1S;
    public bool J2S;
    public int Slot;
    public int Slot2;
    public Image S;
    public Image a;
    [System.Serializable]
    public class Personajes
    {
        public static FondoSelector instance;
        public string name;
        public GameObject PJ;

    }
    public List<Personajes> PJ = new List<Personajes>();
    [System.Serializable]
    public class Personajes2
    {
        public static FondoSelector instance;
        public string name;
        public GameObject PJ;

    }
    public List<Personajes2> PJ2 = new List<Personajes2>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        J2 = GameObject.Find("Cuadrado2");
        J2P = J2.GetComponent<RectTransform>();
        Coco();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    // Update is called once per frame
    void Update()
    {
        if (J2P.anchoredPosition == rectTransform.anchoredPosition)
        {
            S.sprite = ambos;
            a.sprite = ambos;
        }
        else
        {
            S.sprite = Solo1;
            a.sprite = Solo2;
        }
        if (Input.GetKey("up") && Sloty2 > 0 && enput == false)
        {
            PJ2[Slot2].PJ.SetActive(false);
            J2P.anchoredPosition = new Vector2(J2P.anchoredPosition.x, J2P.anchoredPosition.y + 200f);
            Sloty2 -= 1;
            Slot2 -= 6;
            PJ2[Slot2].PJ.SetActive(true);
            StartCoroutine(DelayInput2(0.3f));
        }
        if (Input.GetKey("w") && Sloty > 0 && enput2 == false)
        {
            PJ[Slot].PJ.SetActive(false);
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + 200f);
            Sloty -= 1;
            Slot -= 6;
            PJ[Slot].PJ.SetActive(true);
            StartCoroutine(DelayInput(0.3f));
        }
        if (Input.GetKey("s") && Sloty < 1 && enput == false)
        {
            PJ[Slot].PJ.SetActive(false);
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - 200f);
            Sloty += 1;
            Slot += 6;
            PJ[Slot].PJ.SetActive(true);
            StartCoroutine(DelayInput(0.3f));
        }
        if (Input.GetKey("down") && Sloty2 < 1 && enput2 == false)
        {
            PJ2[Slot2].PJ.SetActive(false);
            J2P.anchoredPosition = new Vector2(J2P.anchoredPosition.x, J2P.anchoredPosition.y - 200f);
            Sloty2 += 1;
            Slot2 += 6;
            PJ2[Slot2].PJ.SetActive(true);
            StartCoroutine(DelayInput2(0.3f));
        }
        if (Input.GetKey("d") && Slotx < 5 && enput == false) //d
        {
            PJ[Slot].PJ.SetActive(false);
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + 200f, rectTransform.anchoredPosition.y);
            Slotx += 1;
            Slot += 1;
            PJ[Slot].PJ.SetActive(true);
            StartCoroutine(DelayInput(0.3f));
        }
        if (Input.GetKey("right") && Slotx2 < 5 && enput2 == false) //d
        {
            PJ2[Slot2].PJ.SetActive(false);
            J2P.anchoredPosition = new Vector2(J2P.anchoredPosition.x + 200f, J2P.anchoredPosition.y);
            Slotx2 += 1;
            Slot2 += 1;
            PJ2[Slot2].PJ.SetActive(true);
            StartCoroutine(DelayInput2(0.3f));
        }
        if (Input.GetKey("a") && Slotx > 0 && enput == false) //a
        {
            PJ[Slot].PJ.SetActive(false);
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x - 200f, rectTransform.anchoredPosition.y);
            Slotx -= 1;
            Slot -= 1;
            PJ[Slot].PJ.SetActive(true);
            StartCoroutine(DelayInput(0.3f));
        }
        if (Input.GetKey("left") && Slotx2 > 0 && enput2 == false) //a
        {
            PJ2[Slot2].PJ.SetActive(false);
            J2P.anchoredPosition = new Vector2(J2P.anchoredPosition.x - 200f, J2P.anchoredPosition.y);
            Slotx2 -= 1;
            Slot2 -= 1;
            PJ2[Slot2].PJ.SetActive(true);
            StartCoroutine(DelayInput2(0.3f));
        }

        if (Sloty == 1)
        {
            if (Slotx == 0)
            {

            }
            if (Slotx == 1)
            {

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
                if (Input.GetKey("e"))
                {

                }
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
        if (Sloty2 == 0)
        {
            if (Slotx2 == 0)
            {
                image2.sprite = fondo1;
                if (Input.GetKey("e"))
                {

                }
            }
            if (Slotx2 == 1)
            {
                image2.sprite = fondo2;
            }
            if (Slotx2 == 2)
            {
                image2.sprite = fondo3;
            }
            if (Slotx2 == 3)
            {
                image2.sprite = fondo4;
            }
        }
        if (Input.GetKey("q"))
        {
            enput = true;
            J1S = true;
        }
        if (Input.GetKey("p"))
        {
            enput2 = true;
            J2S = true;
        }
        if (J2S == true && J1S == true)
        {
            SceneManager.LoadScene("TestFight 1");
        }
    }
    IEnumerator DelayInput(float tiempo)
    {
        enput = true;
        yield return new WaitForSeconds(tiempo);
        enput = false;
    }
    IEnumerator DelayInput2(float tiempo)
    {
        enput2 = true;
        yield return new WaitForSeconds(tiempo);
        enput2 = false;
    }
    void Coco()
    {
        Slot += 1;
        Slot2 += 1;
        PJ[Slot].PJ.SetActive(true);
        PJ2[Slot2].PJ.SetActive(true);
    }
}
