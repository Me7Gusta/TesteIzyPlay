using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject inicio;
    public GameObject creditos;

    //Script de interação com o menu
    private void Start()
    {
        inicio.SetActive(true);
        creditos.SetActive(false);
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene(2);
    }

    public void Credits()
    {
        inicio.SetActive(false);
        creditos.SetActive(true);
    }

    public void GoBack()
    {
        inicio.SetActive(true);
        creditos.SetActive(false);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
