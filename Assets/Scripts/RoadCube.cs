using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCube : MonoBehaviour
{

    public Renderer cubeRenderer;
    public Material roadColored;
    public bool isColored;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isColored)
        {
            isColored = true;
            cubeRenderer.material = roadColored;
            GameController.instance.CheckTile();
        }
    }
}
