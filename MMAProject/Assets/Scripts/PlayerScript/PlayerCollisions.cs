using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] PlayerScript playerScript;
    [SerializeField] PlayerControls playerContr;
    [SerializeField] AudioManager audioManager;
    [SerializeField] GameManager gameManager;
    public Animator anim;
    public int isDeadHash;

    private void Start()
    {
        anim = GetComponent<Animator>();
        isDeadHash = Animator.StringToHash("isDead");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            audioManager.gameOverPlay();
            audioManager.deathPlay();
            gameManager.gameOver();
            anim.SetBool(isDeadHash, true);
        }
        else if (other.tag == "Finish")
        {
            audioManager.finishPlay();
            gameManager.levelClear();
        }
        else if (other.tag == "WaveUp")
        {
            if (other.transform.position.x <= -1)
            {
                playerScript.waveUpPos.x = -2.5f;
            }
            else if (other.transform.position.x >= 1)
            {
                playerScript.waveUpPos.x = 2.5f;
            }
            else
            {
                playerScript.waveUpPos.x = 0;
            }

            playerContr.WaveUpCollide();
        }
        else if (other.tag == "LastLvl")
        {
            gameManager.gameCleared();
            audioManager.finishPlay();
        }
    }

    public void DeadReset() 
    {
        anim.SetBool(isDeadHash, false);
        Vector3 rotationVector = new Vector3(0, 0, 0);
        Quaternion rotation = Quaternion.Euler(rotationVector);
        gameObject.transform.rotation = rotation;
    }
}
