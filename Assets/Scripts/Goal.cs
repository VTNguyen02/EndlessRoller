using UnityEngine;
using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController component = GetComponent<PlayerController>();
        if (component != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
