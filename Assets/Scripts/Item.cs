using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
    public ItemData data;

     public Rigidbody2D rb2d;
    public Rigidbody2D rb2d1;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d1 = GetComponent<Rigidbody2D>();
    }
}
