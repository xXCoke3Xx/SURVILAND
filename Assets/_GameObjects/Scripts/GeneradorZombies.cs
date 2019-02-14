using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneradorZombies : MonoBehaviour {

    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;
    public GameObject enemigo4;
    public GameObject enemigo5;
    public float tiempo = 0f;
    public float segundosRespawn = 5f;

    List<GameObject> listaEnemigos = new List<GameObject>();
    System.Random rnd;
    void Start () {
        listaEnemigos.Add(enemigo1);
        listaEnemigos.Add(enemigo2);
        listaEnemigos.Add(enemigo3);
        listaEnemigos.Add(enemigo4);
        listaEnemigos.Add(enemigo5);
        
    }

    public void OnTriggerStay(Collider col)
    {
        rnd = new System.Random();
        if (col.tag == "Player")
        {
            tiempo += Time.deltaTime;
            if (tiempo >= segundosRespawn)
            {
                GameObject generador = Instantiate(listaEnemigos[rnd.Next(0, 6)], this.transform.position, Quaternion.identity);
                tiempo = 0;
            }
        }
    }
}
