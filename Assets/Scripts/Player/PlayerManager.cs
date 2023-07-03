using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool shielded = false;
    public bool crashed { get; set; }
    private Animator playerAnimator;
    private PlayerMove playerMove;
    private AudioSource failAudio;
    private ParticleSystem playerParticles;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        failAudio = GetComponent<AudioSource>();
        playerParticles = GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    public void GetShield()
    {
        shielded = true;
        StartCoroutine(BrakeShield());
    }

    public IEnumerator BrakeShield()
    {
        yield return new WaitForSeconds(5);
        shielded = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle") && !shielded)
        {
            if (shielded == true)
            {
                Destroy(other.gameObject);
                shielded = false;

            }
            else
            {
                failAudio.Play();
                playerParticles.Stop();
                PlayerMove.canMove = false;
                GameManager.Instance.gameOver = true;
                playerAnimator.SetBool("isRunning", false);
                playerAnimator.SetBool("isDead", true);
                EndRunSequence.instance.enabled = true;
                Debug.Log(PlayerMove.canMove);
            }
        }
    }
}
