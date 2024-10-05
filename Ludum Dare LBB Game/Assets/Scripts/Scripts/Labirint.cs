using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labirint : MonoBehaviour
{
    public Transform playerLab;
    private Vector3 offset;

    void Start()
    {
        offset = playerLab.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        Vector3 mousePozition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePozition.z = 0;
        playerLab.position = mousePozition;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision Detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("You lose");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected with " + gameObject.name);

        if (other.CompareTag("Wall"))
        {
            Debug.Log("You lose");
        }
    }

}
