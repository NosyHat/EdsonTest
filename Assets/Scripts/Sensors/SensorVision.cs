using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EyeData
{
    public bool found { get; set; }
    public Vector3 position { get; set; }

}

public class SensorVision : MonoBehaviour
{
    [SerializeField] private float visionField;
    [SerializeField] private float visionLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detecção do jogador
    public bool see(GameObject target)
    {
        bool found = false;
        Vector3 direction =
          (target.transform.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.forward, direction);

        if(angle < visionField)
        {
            // Dentro do campo de visão do agente
            RaycastHit thing;
            Physics.Raycast(transform.position, direction, out thing, visionLimit);

            if (thing.collider.name == target.name)
            {
                found = true;
            }
        }

        return found;
    }

    // Variante 1: Objeto transparente
    /*public bool see(GameObject target, GameObject transparentObject)
    {
        bool found = false;
        Vector3 direction =
          (target.transform.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.forward, direction);

        if (angulo < campoVisao)
        {
            // Dentro do campo de visão do agente
            var lista = Physics.RaycastAll(transform.position, direction, visionLimit);

            if (lista[0].collider.name == target.name)
            {
                found = true;
            }

            else
            {
                if (lista[0].collider.name == transparentObject.name)
                {
                    if (lista[1].collider.name == found.name)
                    {
                        found = true;
                    }
                }
            }
        }

        return found;
        
    }*/

    // Variante 2: Retornando posição do jogador
    /*public EyeData seePosition(GameObject target)
    {
        EyeData data = new EyeData();
        data.found = false;
        Vector3 direction =
          (target.transform.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.forward, direction);

        if (angle < visionField)
        {
            // Dentro do campo de visão do agente
            RaycastHit thing;
            Physics.Raycast(transform.position, direction, out thing, visionLimit);

            if (thing.collider.name == thing.name)
            {
                data.found = true;
                data.position = thing.collider.transform.position;
            }
        }

        return data;
    }*/
}
