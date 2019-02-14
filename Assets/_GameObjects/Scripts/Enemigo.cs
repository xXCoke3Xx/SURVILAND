using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;
    Animator anim;
    public int vida = 50;
    public int restarVida = 5;
    float aumento;
    public TextMesh texto;
    public int puntuacion = 0;
    public float velocidadDeCaida = 1.5f;
    // Use this for initialization
    void Start()
    {
        texto.text = vida.ToString();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        this.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= 1f )
        {
            aumento += Time.deltaTime/2;
            this.transform.localScale = new Vector3(aumento, aumento, aumento);
        }
       
        
        if (vida <= 0)
        {
            
            texto.text = "";
            
           
            this.transform.Translate(Vector3.down * Time.deltaTime * velocidadDeCaida);
            nav.enabled = false;
            Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length+1);

        }
        else
        {
            nav.SetDestination(player.position);
        }
        
    }

    public void OnDestroy()
    {
        puntos.p = puntos.p + 1;
        Debug.Log("La puntuacion es: " + puntos.p);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Contains("Bala"))
        {
            vida -= restarVida;
            if (vida <= 0)
            {
                
                anim.SetBool("Muerto", true);
                
            }
            texto.text = vida.ToString();
            Destroy(col.gameObject);

        }
        if (col.gameObject.tag == "MainCamera")
        {
            anim.SetBool("Ataca", true);
        }
        
    }

    public void OnTriggerExit(Collider col)
    {
        anim.SetBool("Ataca", false);
    }

    

}
