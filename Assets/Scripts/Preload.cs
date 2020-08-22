using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preload : MonoBehaviour
{
    public GameObject gm;

    void Start() //Aqui eu instancio o Game Manager antes do jogo para não haver conflito
    {
        Instantiate(gm);
        SceneManager.LoadScene(1);
    }
}
