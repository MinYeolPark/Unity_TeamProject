using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject SpawnPoint;

    public GameObject MeleePrefab;
    public GameObject RangePrefab;
    public GameObject CannonPrefab;
    public GameObject SuperPrefab;
    
    public int waveNumber = 0;
    public float waveTimer = 0;

    public GameObject Inhibitor;
    public bool MidInhibitor = false;


    private void Start()
    {
        waveTimer = GameConsts.MINION_WAVE_TIME;
    }
    void Update()
    {
        SpawnWave();
    }

    void SpawnWave()
    {
        if (InGameManager.Instance.gameTime < GameConsts.MINION_FIRST_SPAWN_TIME)
            return;
<<<<<<< HEAD
        if (waveNumber == 0&&waveTimer >= GameConsts.MINION_FIRST_SPAWN_TIME)            //First Minion Spawn after 45sec
        {    
            //First Spawn
            SpawnUnit(MeleePrefab, SpawnPoint);
=======
        if (waveTimer >= GameConsts.MINION_WAVE_TIME)       //일정 시간을 초과하면 미니언 나오기
        {
            ////Check minion spawn time
            //System.TimeSpan t = System.TimeSpan.FromSeconds(InGameManager.Instance.gameTime);

            //Debug.Log(string.Format("WaveNumber:{0}has sapwned at{1}",
            //    waveNumber, string.Format("{0:D2}:{1:D2}",
            //    t.Minutes, t.Seconds)));


            //////////////////
            ///MinionsSpawn///
            //////////////////
            //SpawnUnit(MeleePrefab, GameConsts.SPAWN_MID);


            //for(int i=0;i<SpawnPoints.Count;i++)                
            //{

            #region Wave Spawner
            //Add Melee Minion
            //for (int m = 0; m < GameConsts.MELEE_COUNT; m++)
            //{
            //    SpawnUnit(MeleePrefab, GameConsts.SPAWN_MID);
            //}

            ////Add Cast Minion
            //for (int r = 0; r < GameConsts.RANGE_COUNT; r++)
            //{
            //    SpawnUnit(RangePrefab, GameConsts.SPAWN_MID);
            //}

            ////Add Cannon Minion
            //if(waveNumber!=0&&waveNumber%3==0)          //Cannon Minion spawn every 3 waves
            //{
            //    for (int c = 0; c < GameConsts.CANNON_COUNT; c++)
            //    {
            //        SpawnUnit(CannonPrefab, GameConsts.SPAWN_MID);
            //    }
            //}

>>>>>>> 78e8db30eaf0cddb9bd88a0879750ab762656bb6

            waveTimer = 0;
            waveNumber++;
        }
        else if (waveTimer >= GameConsts.MINION_SPAWN_TIME)
        {
            SpawnUnit(MeleePrefab, SpawnPoint);

            waveTimer = 0;
            waveNumber++;
        }
        else
        {          
            waveTimer += Time.deltaTime;
        }
    }

    private void SpawnUnit(GameObject prefab,GameObject spawnLoc)
    {
        GameObject gameObject = Instantiate(prefab, SpawnPoint.transform.position, Quaternion.identity);

        Minion minion = gameObject.GetComponent<Minion>();
    }

}
               
