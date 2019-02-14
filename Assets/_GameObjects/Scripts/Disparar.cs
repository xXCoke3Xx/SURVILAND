using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {

    public GameObject prefabProyectil;
    public Transform salidaBala;
    public ParticleSystem explosion;
    /*public Transform salidaCasquillo;
    public float fuerzaCasquillo = 0.1f;
    public GameObject prefabCasquillo;*/
    public float fuerzaDisparo = 0.1f;
    public AudioClip disparo;//El fichero de sonido
    private AudioSource audioSource;
    Animator anim;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        explosion.Stop();
    }

    void Update()
    {
        if (municionDisponible.balas > 0)
        {
            Debug.Log(municionDisponible.balas);
            if (Input.GetMouseButtonDown(0))
            {
                municionDisponible.balas -= 1;
                GameObject proyectil =
                    Instantiate(
                        prefabProyectil,
                        salidaBala.position,
                        Quaternion.identity);
                proyectil.GetComponent<Rigidbody>().AddForce(
                    transform.forward * fuerzaDisparo,
                    ForceMode.Impulse);
                explosion.Emit(10);
                explosion.Play();
                /*GameObject casquillo =
                    Instantiate(
                        prefabCasquillo,
                        salidaCasquillo.position,
                        Quaternion.identity);
                casquillo.GetComponent<Rigidbody>().AddForce(
                    transform.forward * fuerzaCasquillo,
                    ForceMode.Impulse);*/
                //anim.SetBool("Disparo", true);
                //Debug.Log(anim.GetBool("Disparo"));

                anim.Play("RetrocesoCadera");
                anim.Play("RetrocesoApuntandoChetada");
                audioSource.PlayOneShot(disparo);
                Destroy(proyectil, 4);

            }
            else
            {
                //explosion.Emit(0);
                explosion.Stop();

            }
        }
        else
        {
            explosion.Stop();
        }
        
    }
}
