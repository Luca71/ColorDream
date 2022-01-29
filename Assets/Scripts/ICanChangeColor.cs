using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICanChangeColor : MonoBehaviour
{
    public Texture[] textures;

    Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    /// <summary>
    /// Chenge the texture
    /// </summary>
    /// <param name="index">0 for Color, 1 for BW</param>
    public void ChangeTextureInBW()
    {
        material.SetTexture("_MainTex", textures[1]);
    }
    public void ChangeTextureInColor()
    {
        material.SetTexture("_MainTex", textures[0]);
    }

    //public void ChangeTextureTotalWhite()
    //{
    //    material.SetTexture("_MainTex", null);
    //}
}
