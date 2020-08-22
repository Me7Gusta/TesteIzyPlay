using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    //private PlayerInput input;
    //public GameManager gm;
    private HUDSettings reset;

    public float knifeMaxSpeed = 50f;     //velocidade da faca
    private float speed = 0f;       //velocidade instantânea da faca
    private bool used = false;      //boleana para verificar se a faca já foi usada pelo jogador

    private void Awake()
    {
        used = false; //forçar booleana quando instanciada
        //input = GameObject.Find("PlayerStats").GetComponent<PlayerInput>();
        //gm = GameObject.Find("GameManagement").GetComponent<GameManager>();
        reset = GameObject.Find("HUD").GetComponent<HUDSettings>();
    }

    private void Update()
    {
        OnPlayerClick();
    }

    private void FixedUpdate()
    {
        //OnPlayerClick(); //Comando do jogador
        transform.Translate(Vector2.up * speed * Time.deltaTime);   //muda a velocidade da faca
    }

    public void OnPlayerClick()
    {
        if (!used)
        {
            if (Input.GetButtonDown("Fire1")) //quando jogador clicar o botão esquerdo e a faca ainda não foi usada
            {
                speed = knifeMaxSpeed;  //setar a vel instantânea com a vel. máxima
                used = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //quando bater no tronco sua velocidade zera e se transforma em child do tronco
        if (other.CompareTag("Trunk")) 
        {
            speed = 0f;
            gameObject.transform.parent = other.transform;
            gameObject.GetComponent<KnifeScript>().enabled = false;
        }

        if (other.CompareTag("Knife"))
        {
            reset.ResetQuestion();
        }
    }

}