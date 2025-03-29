using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Tube> tubes = new List<Tube>();
    public List<Tube> tubes2 = new List<Tube>();

    public GameObject prefabTube;
    public GameObject ListTubeGO;
    public GameObject ListTubeGO2;
    public GameObject prefabBall;
    public Sprite[] spriteBalls;
    public LevelData[] levelGame;
    public Tube currentTube;
    public GameObject winPanel;
    public Button nextLevelButton;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        levelGame[currentLevel].CreateLevel(ref tubes);
        levelGame[currentLevel].CreateLevell(ref tubes2);
        winPanel.SetActive(false);
        nextLevelButton.gameObject.SetActive(false);
        nextLevelButton.onClick.AddListener(nextlv);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckWin()
    {
        if (IsWin())
        {
            Debug.Log("win");
            ListTubeGO.SetActive(false);
            ListTubeGO2.SetActive(false);
            winPanel.SetActive(true);
            nextLevelButton.gameObject.SetActive(true);
            ListTubeGO2.SetActive(false);
        }
    }
    bool IsWin()
    {
        for (int i = 0; i < tubes.Count; i++)
        {
            if (tubes[i].isTubeNull)
            {
                continue;
            }
            if (!tubes[i].isFullTube)
            {
                Debug.Log("chua win");
                return false;
            }
            else
            {
                Sprite spriteCompare = tubes[i].balls[0].GetComponent<Image>().sprite;
                for (int j = 1; j < tubes[i].balls.Count; j++)
                {
                    if (tubes[i].balls[j].GetComponent<Image>().sprite != spriteCompare)
                    {
                        Debug.Log("chua win");
                        return false;
                    }
                }
            }
        }
        Debug.Log("win");
        return true;
    }
    public int currentLevel = 0;
    public void nextlv()
    {

        if (currentLevel < levelGame.Length && levelGame[currentLevel])
        {
            foreach (var tube in tubes)
            {
                Destroy(tube.gameObject);
            }
            foreach (var tubee in tubes2)
            {
                Destroy(tubee.gameObject);
            }
            tubes.Clear();
            tubes2.Clear();

            currentLevel++;
            if (currentLevel <= levelGame.Length)
            {
                levelGame[currentLevel].CreateLevel(ref tubes);
                levelGame[currentLevel].CreateLevell(ref tubes2);

                winPanel.SetActive(false);
                nextLevelButton.gameObject.SetActive(false);

                ListTubeGO.SetActive(true);
                ListTubeGO2.SetActive(true);
                
                
                
            }
            else
            {
                Debug.Log("Game đã hoàn thành.");
            }
        }
    }
}
