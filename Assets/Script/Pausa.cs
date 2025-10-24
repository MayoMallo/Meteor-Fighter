using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject Panel;
    public RectTransform Option;
    public int Slot;
    public bool PausaM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape") && PausaM == false)
        {
            PausaM = true;
            Slot = 0;
            Option.anchoredPosition = new Vector2(-2, -74);
            Time.timeScale = 0;
            Panel.SetActive(true);
        }
        if (PausaM == true)
        {
            if (Input.GetKey("w") && Slot == 1)
            {
                Slot -= 1;
                Option.anchoredPosition = new Vector2(-2, -74);
            }
            if (Input.GetKey("s") && Slot == 0)
            {
                Slot += 1;
                Option.anchoredPosition = new Vector2(-2, -174);
            }
            if (Slot == 0 && Input.GetKey("q"))
            {
                PausaM = false;
                Slot = 0;
                Option.anchoredPosition = new Vector2(-2, -74);
                Time.timeScale = 1;
                Panel.SetActive(false);
            }
            if (Slot == 1 && Input.GetKey("q"))
            {
                Time.timeScale = 1;
                foreach (GameObject obj in FindObjectsOfType<GameObject>())
                {
                    Destroy(obj);
                }
                SceneManager.LoadScene("Menu");
            }
        }
    }
    void Imput()
    {
    }
}
