using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public Animator anim;
    public GameObject RoundManager;
    public int opcion = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RoundManager = GameObject.Find("RoundManager");
        Destroy(RoundManager);
        if (Input.GetKey("s") && opcion == 1) 
        {
            opcion += 1;
            anim.SetBool("1", true);

        }
        if (Input.GetKey("w") && opcion == 2)
        {
            opcion -= 1;
            anim.SetBool("1", false);
        } 
        if (opcion == 1 && Input.GetKey("f"))
        {
            SceneManager.LoadScene("TestFight");
        }
        if (opcion == 2 && Input.GetKey("f"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
