using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsciousnessMann : MonoBehaviour
{
    [Header("Atuadores")]
    [SerializeField] private ActChase chase;
    [SerializeField] private ActPatrol patrolling;
    [SerializeField] private ActPatrol.patrolType patrolType;

    [Header("Sensores")]
    [SerializeField] private SensorVision vision;

    [Header("Configuração")]
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject me;
    public bool statueMode;

    Animator anim;
    [SerializeField] private float speed;

    // Modo estátua
    private Camera cam;
    private MeshRenderer render;
    private Plane[] cameraFrustum;
    private Collider collisor;

    public Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();

        cam = Camera.main;
        render = GetComponent<MeshRenderer>();
        collisor = GetComponent<Collider>();

        Rigidbody rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        var bounds = collisor.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);

        if (vision.see(target))
        {
            if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
            {
                anim.SetBool("canWalk", false);
                GetComponent<Animator>().enabled = false;
                speed = 0f;
                //Debug.Log("To sendo visto, parei");

                rb.isKinematic = false;
            }

            else
            {
                anim.SetBool("canWalk", true);
                GetComponent<Animator>().enabled = true;
                chase.follow(speed, target);
                speed = 8f;
                //Debug.Log("Deu as costas... to te vendo");

                rb.isKinematic = true;
            }
        }
        else
        {
            if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
            {
                anim.SetBool("canWalk", false);
                GetComponent<Animator>().enabled = false;
                speed = 0f;
                //Debug.Log("Sei que eu to sendo visto...");

                rb.isKinematic = false;
            }

            else
            {
                anim.SetBool("canWalk", true);
                GetComponent<Animator>().enabled = true;
                chase.follow(speed, target);
                speed = 2f;
                //Debug.Log("Onde você tá...");

                rb.isKinematic = true;
            }
        }
    }
}
