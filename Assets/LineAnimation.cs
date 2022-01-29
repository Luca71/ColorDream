using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAnimation : MonoBehaviour
{
    public Transform Spawn;
    LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, Spawn.position);
    }

    public void LineAnim(Vector3 objPos)
    {
        lr.SetPosition(1, objPos);
    }

    
}
