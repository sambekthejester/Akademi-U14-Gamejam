using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    Animator image;
    private void Awake()
    {

        image = GameObject.Find("Finisher").GetComponent<Animator>();
    }
    public void ButonaBas()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void R_ButonaBas()
    {
        SceneManager.LoadScene(0);
    }
    public void ButonaBasKaydir()
    {
        image.SetTrigger("Do");
    }
}
