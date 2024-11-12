using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    internal void HandleDestroy()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        transform.parent.GetComponent<MathiasSound>().PlayDestroySound();
        Destroy(transform.parent.gameObject,3);
    }
}