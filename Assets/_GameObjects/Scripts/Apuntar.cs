using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puntos
{
    public static int p = 0;
}

public class municionDisponible
{
    public static int balas = 50;
}

public class Apuntar : MonoBehaviour {

    public GameObject Cadera;
    public GameObject Apuntando;
    float tiempo1 = 0;
    float tiempo2 = 0;
    public int vidaJugador = 50;
    public Slider texto;

    // Use this for initialization
    void Start()
    {
        Cadera.SetActive(true);
        Apuntando.SetActive(false);
        //texto.text = vidaJugador.ToString();
        int parsed = int.Parse(vidaJugador.ToString());
        texto.maxValue = parsed;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButton(1))
        {
            Cadera.SetActive(false);
            Apuntando.SetActive(true);
        }
        else
        {
            Cadera.SetActive(true);
            Apuntando.SetActive(false);
        }
        int parsed = int.Parse(vidaJugador.ToString());
        texto.value = parsed;

        if (vidaJugador <= 0)
        {
            Cadera.SetActive(false);
            Apuntando.SetActive(false);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Zombie1")
        {
            tiempo1 += Time.deltaTime/2;
            if (tiempo1 >= 2)
            {
                vidaJugador--;
                tiempo1 = 0;
            }
        }

        if (col.gameObject.tag == "Zombie2")
        {
            tiempo1 += Time.deltaTime;
            if (tiempo1 >= 2)
            {
                vidaJugador--;
                tiempo1 = 0;
            }
        }

        if (col.gameObject.tag == "Zombie3")
        {
            tiempo1 += Time.deltaTime / 3;
            if (tiempo1 >= 2)
            {
                vidaJugador--;
                tiempo1 = 0;
            }
        }

        if (col.gameObject.tag == "Zombie4")
        {
            tiempo2 += Time.deltaTime;
            if (tiempo2 >= 2)
            {
                vidaJugador--;
                tiempo2 = 0;
            }
        }

        if (col.gameObject.tag == "Zombie5")
        {
            tiempo2 += Time.deltaTime / 4;
            if (tiempo2 >= 2)
            {
                vidaJugador--;
                tiempo2 = 0;
            }
        }

    }
}
