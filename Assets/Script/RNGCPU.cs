using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RNGCPU : MonoBehaviour
{
    public int slot;
    [System.Serializable]
    public class Pj
    {
        public static RNGCPU instance;
        public string name;
        public GameObject Pesonaje;

    }
    public List<Pj> Pjs = new List<Pj>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slot = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Pjs[slot].Pesonaje.SetActive(true);
    }
}
