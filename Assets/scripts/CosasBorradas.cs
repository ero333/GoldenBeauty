using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosasBorradas : MonoBehaviour
{

    public GameObject borrar1;
    public GameObject borrar2;
    public GameObject borrar3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Amongas2());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Amongas2()
    {
        yield return new WaitForSeconds(8);
        borrar1.SetActive(false);
        borrar2.SetActive(false);
        borrar3.SetActive(false);
    }
}
