using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    private PlayerStats gameStat;
    private GameObject trunk;
    
    private void Awake()
    {
        //como é um prefab tive que procurar o script e o game object
        gameStat = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
        trunk = GameObject.Find("Trunk");
        gameObject.transform.parent = trunk.transform;  //quando intanciado já se transformar em child do tronco
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife")) // caso acerte somar mais um nas maçãs coletadas
        {
            gameStat.apples += 1;
            Destroy(gameObject);
        }
    }
}
