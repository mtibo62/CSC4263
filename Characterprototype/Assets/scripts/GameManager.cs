using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> plants = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject sc;
    public int score;
    public Text scoreText;
    public Text levelProgress;
    public bool isAlive;
    private float numLevelAssets;
    private float assetsLeft;
    private float progress;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        numLevelAssets = plants.Count + enemies.Count; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
            sc.GetComponent<SceneControl>().Die();

        progress = (((plants.Count + enemies.Count) / numLevelAssets) * 100);
        levelProgress.text = progress.ToString();
        for (int i = 0; i < plants.Count; i++)
        {
            if (plants[i].GetComponent<IsHealed>().healed)
                plants.RemoveAt(i);
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
                enemies.RemoveAt(i);
        }
        scoreText.text = score.ToString();

    }
}
