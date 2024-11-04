using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

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


    //El enemigo tiene que perseguir al player.

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim= GetComponent<Animator>();

        player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();
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
          for (int i = 0; i < collsDetectados.Length; i++) //para no hacer la lista de array
            {
                collsDetectados[i].GetComponent<Player>().RecibirDanho(danhoEnemigo);
            }
          puedoDanhar=false;
        }
    }
    private void Perseguir()
    {
        agent.SetDestination(player.transform.position);

        //Si el enemigo está a distancia de ataque de ti 
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            //Lanzar la animación de ataque 
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
    private void AbrirVentanaAtaque()
    {
        ventanaAbierta = true;
       
    }
    private void CerrarVentanaAtaque()
    {
        ventanaAbierta=false;
    }
}
