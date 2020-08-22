using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Controle do jogador no inicio do projeto mas descontiuado

    private bool now = false;

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1")) //quando jogador clicar o botão esquerdo e a faca ainda não foi usada
        {
            now = true;
        }
        else { 
            now = false;
        }
    }

    public bool OnClick()
    {
        return now;
    }
}
