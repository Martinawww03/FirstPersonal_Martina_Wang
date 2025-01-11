using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;
using UnityEngine.XR;

public class Enemigo : MonoBehaviour
{
    [Header("Sistema Combate")]
    private NavMeshAgent agent;
    private Animator anim;
    private Player player;
    
    bool ventanaAbierta;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform attackPoint2;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;
    [SerializeField] private float danhoEnemigo;
    [SerializeField] private float vida;
    private bool puedoDanhar = true;
    Rigidbody[] huesos; 

    int vidas;
    private Rigidbody rb;

    public float Vida { get => vida; set => vida = value; }


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
        //cambiarEstadoHuesos(true);
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

        //Si el enemigo está a distancia de ataque de ti 
        if (!agent.pathPending&&agent.remainingDistance <= agent.stoppingDistance) //pathPending= mira ver si el agente no tiene calculo pendiente
        {
            //Lanzar la animación de ataque 
            agent.isStopped = true; //Me paro
            anim.SetBool("Attack", true); //Lanzo el ataque
            

            EnfocarObjetivo();
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
       // vidas -= RecibirDanho;
        if(vidas<=0)
        {
            cambiarEstadoHuesos(false);
        }
    }
    
    private void EnfocarObjetivo()
    {
        //1. Calculo vector UNITARIO que mira hacia el player desde nuestra posición
        Vector3 direccionAObjetivo = (player.transform.position - transform.position).normalized;

        //1.5 Modifico la y del vector para prevenir que el enemigo se tumbe
        direccionAObjetivo.y = 0;

        //2. Calculo la rotacion para conseguir dicha direccion
       // Quaternion.rotacionAObjetivo = Quaternion.LookRotation(direccionAObjetivo);

         transform.rotation = Quaternion.LookRotation(direccionAObjetivo);
    }
    public void Morir()
    {
        agent.enabled = false;
        anim.enabled = false;
        cambiarEstadoHuesos(false);
        Destroy(gameObject, 3); //3= Segundos que tarda a desaparecer el enemigo.
    }
    private void cambiarEstadoHuesos(bool estado)
    {
        for(int i = 0; i<huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }
}
