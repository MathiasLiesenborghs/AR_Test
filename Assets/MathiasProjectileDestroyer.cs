using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathiasProjectileDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
