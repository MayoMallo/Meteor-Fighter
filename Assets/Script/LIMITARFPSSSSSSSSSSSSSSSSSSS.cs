using UnityEngine;
using UnityEngine.SceneManagement;

public class LIMITARFPSSSSSSSSSSSSSSSSSSS : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 60;
    }
}
