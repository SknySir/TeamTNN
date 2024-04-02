using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireLine : MonoBehaviour
{

    public GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        OnDrawGizmosSelected();
    }
    
    void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, target.transform.position);
        }
    }

}
