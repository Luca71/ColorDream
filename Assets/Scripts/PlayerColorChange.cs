using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FateColor
{
    blue,
    red,
    green,
    white
}
public class PlayerColorChange : MonoBehaviour
{
    public FateColor FateColor;
    public bool Change;
    public Material[] MaterialList;
    
    MeshRenderer[] renderers;

    // Start is called before the first frame update
    private void Awake()
    {
        renderers = GetComponentsInChildren<MeshRenderer>();
    }
    void Start()
    {
        
    }

    private void Update()
    {
        if (Change)
        {
            Change = false;
            ChangeFateColor(FateColor);
        }
    }

    public void ChangeFateColor(FateColor color)
    {
        switch ((int)color)
        {
            case 0:
                IterateRenderers(0);
                Staticone.instance.BlueGemPicked = true;
                break;

            case 1:
                IterateRenderers(1);
                Staticone.instance.RedGemPicked = true;
                break;

            case 2:
                IterateRenderers(2);
                Staticone.instance.GreenGemPicked = true;
                break;

            case 3:
                IterateRenderers(3);
                break;
        }
    }

    private void IterateRenderers(int index)
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = MaterialList[index];
        }
    }



}
