using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkScript : MonoBehaviour
{
    public float rotSpeed = 100f;   // velocidade de rotação do tronco
    private float maxRotSpeed = 1f;    // velocidade máxima de rotação do tronco
    private bool dir = true;    // bool para o sentido da rotação
    private float rotZ;       //valor que calcula a rotação em Z
    private int num;    //número aleatório para sortear se vai aparecer maçã, faca ou nada

    public GameObject apple; //prefab da maçã
    public GameObject knife;    //prefab da faca
    public GameObject[] spawns; //var para obter as posições dos spawns do tronco
    
    private void Start()
    {
        maxRotSpeed = Random.Range(100f, 200f);

        foreach(GameObject i in spawns) //para cada spawn se sorteia o q irá aparecer
        {
            num = Random.Range(0, 3); //1/4 de chance pra maçã ou faca e 2/4 para aparecer nada

            switch (num)
            {
                case 0: Instantiate(knife, i.transform.position, i.transform.rotation); break;
                case 1: Instantiate(apple, i.transform.position, i.transform.rotation); break;
                default: break;
            }
        }
    }

    private void FixedUpdate()
    {
        ChangeRotSpeed();

        rotZ = rotSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotZ);
    }

    private void ChangeRotSpeed() // Aumentar e diminuir a rotação do tronco
    {
        if (rotSpeed > maxRotSpeed)
        {
            dir = false;
        }
        else if (rotSpeed < 0f)
        {
            dir = true;
        }

        if (dir)
        {
            rotSpeed += Time.deltaTime * 20;
        }
        else
        {
            rotSpeed -= Time.deltaTime * 20;
        }
    }
}
