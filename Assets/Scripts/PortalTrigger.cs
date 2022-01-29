using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    public Transform Portal;
    public Transform Player;
    public float Radius;
    public string SceneName;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Player.position, Portal.position);

        if (dist <= Radius)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
