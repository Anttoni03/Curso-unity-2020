using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    [Range(0,30)]
    public float floatForce;
    [Range(0,10)]
    public float gravityModifier = 1.5f;
    
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle, fireworksParticle;

    private AudioSource _audioSource;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    public float upperBound, lowerBound;

    public bool isOnBound;

    
    //====================================================================================================================

    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
        Physics.gravity *= gravityModifier;
        _audioSource = GetComponent<AudioSource>();
    }

    //====================================================================================================================

    
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce * Time.deltaTime, ForceMode.Impulse);
        }
        
        StopOnBounds();
    }

    
    //====================================================================================================================

    
    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            _audioSource.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            _audioSource.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }
    }
    
    
    //====================================================================================================================

/// <summary>
/// Stops when the gameObject is on a bound
/// </summary>
    private void StopOnBounds()
    {
        if (transform.position.y > upperBound)
        {
           transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
        }

        if ((transform.position.y < lowerBound) && !gameOver)
        {
            transform.position = new Vector3(transform.position.x, lowerBound, transform.position.z);
        }

        if ((transform.position.y == upperBound) || (transform.position.y == lowerBound))
        {
            isOnBound = true;
        }
        else
        {
            isOnBound = false;
        }

        if (isOnBound)
        {
            playerRb.velocity = new Vector3();
        }
    }
}
