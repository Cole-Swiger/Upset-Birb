using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _dustPrefab;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.GetComponent<Birb>() != null) {
            Instantiate(_dustPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null) {
            return;
        }

        if (collision.contacts[0].normal.y < -0.5) {
            Instantiate(_dustPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
