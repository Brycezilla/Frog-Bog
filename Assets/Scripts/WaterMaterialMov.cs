using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMaterialMov : MonoBehaviour
{
    public Transform Frog;  // Reference to the frog's Transform
    public GameObject Water_Sprite;
    public float offSetFrog = 0.0f;
    private Vector3 initialPosition;
    private void Update() {
        //player follow only
        Water_Sprite.transform.position = new Vector3(Frog.position.x + offSetFrog, transform.position.y, transform.position.z);
    }
    /*private void Start()
    {
        initialPosition = transform.position;
    }*/

}