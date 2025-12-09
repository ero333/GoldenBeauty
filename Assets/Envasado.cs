using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envasado : MonoBehaviour
{
    public GameObject MenuRaro;
    public GameObject MenuRaro2;
    public GameObject Tuto;
    public GameObject Yomismo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuRaro.activeInHierarchy && !MenuRaro2.activeInHierarchy)
        {
            Tuto.SetActive(true);
            Yomismo.SetActive(false);
        }
    }
}
