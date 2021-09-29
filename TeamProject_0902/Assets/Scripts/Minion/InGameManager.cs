using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameManager : MonoBehaviour
{
    [Header("FPS Check")]
    [Range(1, 100)]
    public int fFont_Size;
    [Range(0, 1)]
    public float Red, Green, Blue;

    float deltaTime = 0.0f;

    public static InGameManager Instance;

    public float gameTime;
    public Text timeText;
    public List<WaveManager> Teams;

    private void Awake()
    {
        if (Instance != this)
            Instance = this;
    }
    private void Start()
    {
        fFont_Size = fFont_Size == 0 ? 50 : fFont_Size;
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        gameTime += Time.deltaTime;
        System.TimeSpan t = System.TimeSpan.FromSeconds(gameTime);
        timeText.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);            
    }

    private void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}
