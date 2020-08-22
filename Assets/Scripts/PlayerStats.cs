using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
    //Variaveis com os estatus no inicio da cena
    public int knifes = 7;
    public int apples = 0;
    public int stage = 1;

    private float count;
    private float time = 1f;

    public GameManager gm;
    public HUDSettings settings;

    private void Start()
    {
        //passar as var do GameManager para os stats da cena
        apples = gm.apples;
        knifes = gm.knifes;
        stage = gm.stage;
        count = 0f;
    }

    private void FixedUpdate()
    {
        if(knifes < 1) //Quando chegar a 0 facas iniciar o contador para ir pro proximo estagio
        {
            count += Time.deltaTime;
            if (count > time)
            {
                gm.apples = apples;
                count = 0;
                settings.NextStage();
            }
        }
    }

}
