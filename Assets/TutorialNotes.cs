using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class TutorialNotes : MonoBehaviour
{

    public GameObject Tutorial;
    public GameObject RecuadroA;
    public GameObject RecuadroB;
    public GameObject RecuadroC;
    public GameObject RecuadroD;

    public GameObject Pausa;
    public GameObject MenuGanar;
    public GameObject MenuPerder;
    public GameObject Yomismo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Chichon());
    }

    // Update is called once per frame
    void Update()
    {
        if (Pausa.activeInHierarchy || MenuGanar.activeInHierarchy || MenuPerder.activeInHierarchy)
        {
            Yomismo.SetActive(false);
        }
    }

    public void Desaparecel()
    {
        Tutorial.SetActive(false);
    }

    private IEnumerator Chichon()
    {
        yield return new WaitForSeconds(1f);
        if (RecuadroA.activeInHierarchy || RecuadroB.activeInHierarchy || RecuadroC.activeInHierarchy || RecuadroD.activeInHierarchy)
        {
            Tutorial.SetActive(true);
        }
    }
}
