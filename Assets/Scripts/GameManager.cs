using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Aqui eu salvo as variaveis para não perdê-las quando cerregar uma cena
    public int stage = 1;
    public int apples = 0;
    public int knifes = 7;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
