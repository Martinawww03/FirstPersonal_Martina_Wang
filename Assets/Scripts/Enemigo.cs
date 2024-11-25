using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public class Enemigo : MonoBehaviour
{
    [Header("Sistema Combate")]
    private NavMeshAgent agent;
    private Animator anim;
    private Player player;
    bool ventanaAbierta;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;
    [SerializeField] private float danhoEnemigo;
    private bool puedoDanhar = true;
    Rigidbody[] huesos; 

    int vidas;


    //El enemigo tiene que perseguir al player.

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim= GetComponent<Animator>();
        player = GameObject.FindObjectOfType<Player>();
        huesos = GetComponentsInChildren<Rigidbody>(); //si pongo solo "componenT" sin la s, coge solo un childre y da error
        
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.enabled)
        {
         Perseguir();

        }



        if(ventanaAbierta && puedoDanhar)
        {
          DetectarImpacto();

        }



    }
    private void DetectarImpacto()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(attackPoint.position, radioAtaque, queEsDanhable);
        
        //Si hemos detectado algo en nuestro "radar" (OverlapSphere)
        if(collsDetectados.Length > 0 )
        {
            //
          for (int i = 0; i < collsDetectados.Length; i++) //para no hacer la lista de array
            {
                collsDetectados[i].GetComponent<Player>().RecibirDanho(danhoEnemigo); // [i] es un array 
            }
          puedoDanhar=false;
        }
    }
    private void Perseguir()
    {
        agent.SetDestination(player.transform.position);

        //Si el enemigo est� a distancia de ataque de ti 
        if (agent.pathPending==agent.remainingDistance <= agent.stoppingDistance) //pathPending= mira ver si el agente no tiene calculo pendiente
        {
            //Lanzar la animaci�n de ataque 
            agent.isStopped = true; //Me paro
            anim.SetBool("Attack", true); //Lanzo el ataque
        }
    }
    private void FinAtaque()
    {
        agent. isStopped = false; // sigo moviendome
        anim.SetBool("Attack", false); //Dejo de atacar
        puedoDanhar = false;
    }
    private void cambiarEstadoHuesos()
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = true;
        }
    }
    private void AbrirVentanaAtaque()
    {
        ventanaAbierta = true;
       
    }
    private void CerrarVentanaAtaque()
    {
        ventanaAbierta=false;
    }
    public void RecibirDanho(float RecibirDanho) //hay solo una parada de entrada, es decir Float, y el nombre puede ser cualquiera
    {
        //vidas -= RecibirDanho;
        if(vidas<=0)
        {
            //cambiarEstadoHuesos(false);
        }
    }
}
