using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance;

    public float gameTime;
    public Text timeText;
    public List<WaveManager> Teams;

    private void Awake()
    {
        if (Instance != this)
            Instance = this;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        System.TimeSpan t = System.TimeSpan.FromSeconds(gameTime);
        timeText.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }

    public static List<GameObject> MakePath(int team,int lane)
    {
        List<GameObject> newPath = new List<GameObject>();

        return newPath;
    }
}
