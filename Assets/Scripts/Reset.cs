using UnityEngine;
using UnityEngine.SceneManagement;
public class NewMonoBehaviourScript : MonoBehaviour
{
    public float threshold = -25f;

    void Update()
    {
        if(transform.position.y < threshold)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
