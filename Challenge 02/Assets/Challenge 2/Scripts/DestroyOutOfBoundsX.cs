using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    public float  fixedY, fixedX;

    private void Update()
    {
        if (this.transform.position.x < fixedX)
        {
            Destroy(this.gameObject);
        }

        if (this.transform.position.y < fixedY)
        {
            Destroy(this.gameObject);
            Debug.Log("GameOver!!!");
        }
    }
}
