using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject knife; // prefab da faca
    public PlayerStats stats;    //var para armazenar o script GameStats
    private bool hasKnife = false;  //bool para detectar se o player tem uma faca em posição de arremesso

    private void Start()
    {
        stats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
    }

    private void FixedUpdate()
    {
        if (!hasKnife && stats.knifes > 0) //se não tem uma faca na posição e ainda tem facas para atirar
        {
            Instantiate(knife); //cria uma faca
            hasKnife = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Knife")){ //quando a faca sair desativa o bool e diminui 1 na munição
            hasKnife = false;
            stats.knifes -= 1;
        }
    }
}
