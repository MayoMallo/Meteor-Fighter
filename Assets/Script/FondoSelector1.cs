using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FondoSelector1 : MonoBehaviour
{
    private RectTransform rectTransform;
    public float Slotx;
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
    public Sprite fondo9;
    public Sprite fondo10;
    public Sprite fondo11;
    public Sprite fondo12;
    public Sprite fondo13;
    public Sprite fondo14;
    public Sprite fondo15;
    public Sprite fondo16;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") && Sloty > 0 && enput == false)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + 200f);
            Sloty -= 1;
            StartCoroutine(DelayInput(0.3f));
        }
        if (Input.GetKey("s") && Sloty < 1 && enput == false)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - 200f);
            Sloty += 1;
            StartCoroutine(DelayInput(0.3f));
        }
        if (Input.GetKey("d") && Slotx < 7 && enput == false) //d
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + 200f, rectTransform.anchoredPosition.y);
            Slotx += 1;
            StartCoroutine(DelayInput(0.3f));
        }
        if (Input.GetKey("a") && Slotx > 0 && enput == false) //a
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x - 200f, rectTransform.anchoredPosition.y);
            Slotx -= 1;
            StartCoroutine(DelayInput(0.3f));
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
    }
    IEnumerator DelayInput(float tiempo)
    {
        enput = true;
        yield return new WaitForSeconds(tiempo);
        enput = false;
    }
}
