using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Observer : MonoBehaviour
{

    public Transform target;
    public GameEnding gameEnding;

    private bool isTargetInRange;
    
    //==============================================================================================================

    // Start is called before the first frame update
    void Update()
    {
        if (isTargetInRange)
        {
            Vector3 direction = target.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);

            Debug.DrawRay(transform.position, direction, Color.green, Time.deltaTime, true);
            
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == target)
                {
                    gameEnding.CatchPlayer();
                }
            }
        }
    }

    //==============================================================================================================

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == target)
        {
            isTargetInRange = true;
        }
    }

    //==============================================================================================================

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == target)
        {
            isTargetInRange = false;
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color=Color.black;
        Gizmos.DrawSphere(transform.position, 1f);
        Gizmos.color=Color.magenta;
        Gizmos.DrawLine(transform.position, target.position);
    }*/
}