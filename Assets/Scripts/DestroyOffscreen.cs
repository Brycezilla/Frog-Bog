//Bryce Curson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour
{

    public float offset = 16f;
    public delegate void ONDestroy();
    public event ONDestroy DestroyCallback;

    private bool offscreen;
    private float offscreenX = 0;
    private Rigidbody2D body2d;


    private void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        //offscreenX = (Screen.width / PixelPerfectCamera.pixelsToUnits) / 2 + offset;
        offscreenX = (Screen.width / playercam.pixelsToUnits) / 2 + offset;
    }

    // Update is called once per frame
    void Update()
    {
        var posX = transform.position.x;
        var dirX = body2d.velocity.x;

        if (Mathf.Abs(posX) > offscreenX)
        {
            if (dirX < 0 && posX < -offscreenX)
            {
                offscreen = true;
            }
            else if (dirX > 0 && posX > offscreenX)
            {
                offscreen = true;
            }
        }
        else
        {
            offscreen = false;
        }

        if (offscreen)
        {
            OnOutOfBounds();
        }
    }


    /*public void OnBecameInvisible()
    {
        GameObjectUtil.Destroy(gameObject);
    }*/
    public void OnOutOfBounds()
    {
        offscreen = false;
        GameObjectUtil.Destroy(gameObject);

        if (DestroyCallback != null)
        {
            DestroyCallback();


        }
    }
}
