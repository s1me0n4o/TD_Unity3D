using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpowner : MonoBehaviour
{
    public static int enemyAliveCount = 0;

    public Waves[] waves;
    [SerializeField] Transform startSpownPoint;

    [Range (5f,40f)][SerializeField] float timeBetweenWaves = 5f;
    private float countDown = 2f;
    private int waveNumb = 0;

    [SerializeField] Text textTimer;

    void Update()
    {
        if (enemyAliveCount > 0)
        {
            return;
        }

        if (waveNumb == waves.Length)
        {
            print("Level Won");
            this.enabled = false;
        }

        if (countDown <= 0f)
        {
            StartCoroutine(SpownWave());
            countDown = timeBetweenWaves;
            return;
        }

//it will reduse countDown by 1 every second
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        textTimer.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpownWave()
    {
        PlayerStatistics.rounds++;

        Waves wave = waves[waveNumb];

        enemyAliveCount = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
           SpownEnemy(wave.enemy);
           yield return new WaitForSeconds(1f / wave.rate);
        }


        waveNumb++;
        print(waveNumb);
    }

    private void SpownEnemy(GameObject enemy)
    {
        Instantiate(enemy, startSpownPoint.position, startSpownPoint.rotation);
    }
}
