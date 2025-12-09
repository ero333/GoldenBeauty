using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amongasTrapRemix : MonoBehaviour
{
    public GameObject texto;
    public GameObject Yomismo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Aparecel()
    {
        texto.SetActive(true);
    }

    public void Desapalecel()
    {
        texto .SetActive(false);
    }

    public void Desapalecel2()
    {
        Yomismo.SetActive(false);
    }
}
