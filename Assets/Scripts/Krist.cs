using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krist : MonoBehaviour
{
    
    public void ColorAtivation()
    {
        ColorMgr CM = FindObjectOfType<ColorMgr>();
        CM.Colored = true;
    }
}
