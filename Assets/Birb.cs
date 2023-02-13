using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Birb : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdLaunched;
    private float _timeSitting;

    [SerializeField] private float _launchSpeed = 500;

    private void Awake() {
        _initialPosition = transform.position;
    }

    private void Update() {
        GetComponent<LineRenderer>().SetPosition(0, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(1, transform.position);

        if (_birdLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1) {
            _timeSitting += Time.deltaTime;
        }

        if (transform.position.y > 20 ||
            transform.position.y < -10 ||
            transform.position.x > 20 ||
            transform.position.x < -20 ||
            _timeSitting >= 3) 
        {
            String currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }

    private void OnMouseDown() {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp() {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchSpeed);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag() {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
