using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAnimated : MonoBehaviour
{

    public Animator anim;
    public Animator Diario;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Anim1()
    {
        Diario.SetBool("Amongas",true);
    }

    public void Anim2() 
    {
        Diario.SetBool("Amongas2", true);
    }

    public void Pasar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
