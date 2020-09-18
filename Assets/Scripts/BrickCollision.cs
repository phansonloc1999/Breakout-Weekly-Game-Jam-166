using System.Collections;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    [SerializeField] private int _hitPoint;

    IEnumerator DestroyOnCollisionWithBall()
    {
        yield return new WaitForEndOfFrame();

        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        _hitPoint--;

        if (_hitPoint <= 0)
        {
            StartCoroutine(DestroyOnCollisionWithBall());
        }
    }
}