using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IRecycle
{
    public Sprite[] sprites;
   static public int bugsEaten = 0;

    public Vector2 colliderOffset = Vector2.zero;
    public void Restart()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];

        var collider = GetComponent<BoxCollider2D>();
        var size = renderer.bounds.size;
        size.y += colliderOffset.y;

        collider.size = size;
        collider.offset = new Vector2(-colliderOffset.x, collider.size.y / 2 - colliderOffset.y);


    }

     public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "bug")
        {
            Debug.Log("collides");
            bugsEaten++;
            Destroy(gameObject);
            

        }
        Destroy(gameObject);
    }
    public void Shutdown()
    {

    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        bugsEaten++;
        Destroy(gameObject);
        
    }

    
}
