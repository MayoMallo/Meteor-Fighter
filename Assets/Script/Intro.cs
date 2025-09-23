using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Intro1", 3f);
    }

    void Intro1()
    {
        SceneManager.LoadScene("Menu");
    }
}
