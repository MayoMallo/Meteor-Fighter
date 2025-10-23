using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public GameObject J1;
    public GameObject J2;
    public Transform Position1;
    public Transform Position2;
    public Transform Camara;
    public Vector3 CamaraLocation;
    public GameObject CamaraObj;
    public Vector3 Location;
    public float Xmin;
    public float Xmax;
    public static BackgroundMusic instancia;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        J1 = GameObject.Find("Player1");
        Position1 = J1.GetComponent<Transform>();
        J2 = GameObject.Find("Player2");
        Position2 = J2.GetComponent<Transform>();
        CamaraObj = GameObject.Find("Main Camera");
        Camara = CamaraObj.GetComponent<Transform>();
        Location = new Vector3((J1.transform.position.x + J2.transform.position.x) / 2f, 0f, J1.transform.position.z);
        CamaraLocation = Camara.position;
        if (Location.x <= Xmin)
        {
            Location = new Vector3(Xmin, Location.y, Location.z);
        }
        if (Location.x >= Xmax)
        {
            Location = new Vector3(Xmax, Location.y, Location.z);
        }
        if (CamaraLocation != Location)
        {
            Camara.position = Location;
        }
    }
    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
