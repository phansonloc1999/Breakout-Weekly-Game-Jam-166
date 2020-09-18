using System.Collections;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    IEnumerator DestroyOnCollisionWithBall()
    {
        yield return new WaitForEndOfFrame();

        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(DestroyOnCollisionWithBall());
    }
}