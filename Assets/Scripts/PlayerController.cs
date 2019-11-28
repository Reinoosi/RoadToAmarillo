using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;                 // Declare RigidBody playerRb.

    private Animator playerAnim;                // Declare Animator playerAnim.
    public ParticleSystem explosionParticle;    // Declare ParticleSystem explosionParticle and add explosionParticle to PlayerControllerScript in Unity.
    public ParticleSystem dirtParticle;         // Declare ParticleSystem dirtParticle and add dirtParticle to PlayerControllerScript in Unity.

    private AudioSource playerAudio;            // Declare AudioSource playerAudio and add compononent in Unity.
    public AudioClip jumpSound;                 // Declare AudioClip jumpSound and add sound in Unity.
    public AudioClip crashSound;                // Declare AudioClip crashSound and add sound in Unity.

    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;

    public GameManager theDeathScreen;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();       // Get RigidBody to playerRb.
        playerAnim = GetComponent<Animator>();      // Get Animator component to playerAnim.
        playerAudio = GetComponent<AudioSource>();  // Get AudioSource component to playerAudio.
        Physics.gravity *= gravityModifier;         // Applies gravity to all rigid bodies in the Scene.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)             // Player can jump if space, isOnGround and gameOver is not true. (Also gameOver == False or gameOver != true works)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);           // Making player to jump, using Vector3.up and ForceMode.Impulse.
            isOnGround = false;                                                     // Set isOnGround to false, so player can't jump again until isOnGround is true again.
            playerAnim.SetTrigger("Jump_trig");                                     // When player jump, set trigger for jump animation. It's named Jump_trig.
            dirtParticle.Stop();                                                    // If isOnGround is false, stop dirtParticle effect.
            playerAudio.PlayOneShot(jumpSound, 1.0f);                               // If player jumps, play jumpSound once.
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;                              // If player collide with gameObject where is Ground tag, isOnGround is true.
            dirtParticle.Play();                            // If player isOnGround play dirtParticle effect.
        } 
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");     
            gameOver = true;                                // If player collide with gameObject where is Obstacle tag, it's Game Over.
            playerAnim.SetBool("Death_b", true);            // Also set animation called Death_b to true
            playerAnim.SetInteger("DeathType_int", 1);      // And set animaton DeathType_int, 1 to get that death effect.
            explosionParticle.Play();                       // Call explosionParticle effect and play it.
            dirtParticle.Stop();                            // Stop playing dirtParticle effect if you die.
            playerAudio.PlayOneShot(crashSound, 1.0f);      // If player dies, play crashSound once.

            theDeathScreen.RestartGame();

        }
    }
}
