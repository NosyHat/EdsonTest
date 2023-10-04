using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsciousnessFun : MonoBehaviour
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
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (vision.see(target))
        {
            anim.SetBool("canWalk", true);
            chase.follow(speed, target);
            speed = 2f;
        }
        else
        {
            anim.SetBool("canWalk", true);
            patrolling.patrol(speed, patrolType);
            speed = 1f;
        }
    }
}
