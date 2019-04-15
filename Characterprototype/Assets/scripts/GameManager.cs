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
    private float healed, killed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        numLevelAssets = plants.Count + enemies.Count;
        healed = killed = 0;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            Cursor.visible = true;
            sc.GetComponent<SceneControl>().Die();
        }

        progress = (((healed+killed) / numLevelAssets) * 100);
        levelProgress.text = progress.ToString();
        for (int i = 0; i < plants.Count; i++)
        {
            if (plants[i].GetComponent<IsHealed>().healed)
            {
                plants.RemoveAt(i);
                healed++;
            }
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].GetComponent<BoxCollider2D>().enabled)
            {
                enemies.RemoveAt(i);
                killed++;
            }
        }
        scoreText.text = score.ToString();

    }
}
