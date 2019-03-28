using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpowner : MonoBehaviour
{
    [SerializeField] Transform enemyPrefab;
    [SerializeField] Transform startSpownPoint;

    [Range (5f,40f)][SerializeField] float timeBetweenWaves = 5f;
    private float countDown = 2f;
    private int waveNumb = 0;

    [SerializeField] Text textTimer;

    void Update()
    {
        if (countDown <= 0f)
        {
            print(countDown);
            StartCoroutine(SpownWave());
            countDown = timeBetweenWaves;
        }

//it will reduse countDown by 1 every second
        countDown -= Time.deltaTime;
        textTimer.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpownWave()
    {
        waveNumb++;

        for (int i = 0; i < waveNumb; i++)
        {
        SpownEnemy();
// it will spown enemy after 0,2 sec
        yield return new WaitForSeconds(0.2f);
        }
    }

    private void SpownEnemy()
    {
        Instantiate(enemyPrefab, startSpownPoint.position, startSpownPoint.rotation);
    }
}
