using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemode : MonoBehaviour
{
    private RectTransform rectTransform;
    private float entrada;
    public float Slot;
    public int mov;
    public bool enput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        entrada = Input.GetAxis("Vertical");
        if (entrada > 0 && Slot > 0 && enput == false)
        {
            Slot -= 1;
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + mov);
            StartCoroutine(DelayInput(0.3f));
        }
        if (entrada < 0 && Slot < 5 && enput == false)
        {
            Slot += 1;
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - mov);
            StartCoroutine(DelayInput(0.3f));
        }
        if (Input.GetKey("e") && Slot == 1)
        {
            SceneManager.LoadScene("1 Player");
        }
        if (Input.GetKey("e") && Slot == 0)
        {
            SceneManager.LoadScene("Story");
        }
        if (Input.GetKey("e") && Slot == 2)
        {
            SceneManager.LoadScene("2 Player");
        }
        if (Input.GetKey("e") && Slot == 3)
        {
            SceneManager.LoadScene("Credits");
        }
        if (Input.GetKey("e") && Slot == 4)
        {
            SceneManager.LoadScene("Tutorial");
        }
        if (Input.GetKey("e") && Slot == 5)
        {
            SceneManager.LoadScene("1 Player");
        }
    }
    IEnumerator DelayInput(float tiempo)
    {
        enput = true;
        yield return new WaitForSeconds(tiempo);
        enput = false;
    }

}
