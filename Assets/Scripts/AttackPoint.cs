using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GameOver");
        //SceneManager.LoadScene("GameOver");
    }
}
