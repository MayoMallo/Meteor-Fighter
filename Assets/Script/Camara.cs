using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform Position1;
    public Transform Position2;
    public GameObject J1;
    public GameObject J2;
    public Vector3 Location;
    public Vector3 CamaraLocation;
    public Transform Camaraa;
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
        Camaraa = GetComponent<Transform>();
        CamaraLocation = new Vector3(Camaraa.position.x, Camaraa.position.y, Camaraa.position.z);
        Location = new Vector3((J1.transform.position.x + J2.transform.position.x) / 2f, 0f, J1.transform.position.z);
        if (CamaraLocation != Location)
        {
            CamaraLocation = Location;
            Camaraa.position = CamaraLocation;
        }
    }
}
