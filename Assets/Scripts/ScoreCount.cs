using UnityEngine;
using System;

public class ScoreCount : MonoBehaviour
{

    TMPro.TMP_Text text;
    int count;
    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void OnEnable() => Ball.OnCollide += OnBallCollide;
    // void OnDisable() => Ball.OnCollide -= OnBallCollide;
    

    void OnBallCollide()
    {
        text.text = (++count).ToString();
    }
}
