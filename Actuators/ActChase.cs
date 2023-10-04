using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActChase : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void follow(float speed, GameObject target)
    {
        Vector3 direction = 
            (target.transform.position - transform.position).normalized;
        Quaternion rotate = Quaternion.LookRotation(direction);
        rotate.x = 0;
        rotate.z = 0;
        transform.rotation = rotate;
        transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
