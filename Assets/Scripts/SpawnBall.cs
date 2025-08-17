using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnBall : MonoBehaviour
{

    public GameObject ballPrefab;
    
    void Awake()
    {

    }

    void OnEnable() => Ball.OnCollide += OnBallCollide;
    void OnDisable() => Ball.OnCollide -= OnBallCollide;


    void OnBallCollide()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-3f, 3f);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0);
        Instantiate(ballPrefab, randomPosition, Quaternion.identity);
        Debug.Log("Instatiated at position" + randomPosition); 
    }
}
