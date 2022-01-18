using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //Adjustable Varibles, array divided by levels
    //Diffrent waves of enemies seperated by null varibles
    [SerializeField ]
    private GameObject[] enemyWaves;
    //percent of enemies that need to die until new wave spawns in
    [SerializeField]
    private float[] enemyDeathThreshHold;
    [SerializeField]
    private float[] rangeOfEnemySpawnXMin;
    [SerializeField]
    private float[] rangeOfEnemySpawnXMax;
    [SerializeField]
    private float[] rangeOfEnemySpawnYMin;
    [SerializeField]
    private float[] rangeOfEnemySpawnYMax;
    //Non adjustable
    [SerializeField]
    public int Level = 0;
    //Switches background image based on Stage varible
    [SerializeField]
    private static int Stage = 0;
    [SerializeField]
    private GameObject[] EnemiesOnField;
    public int LevelGet()
    {
        return Level;
    }
    public void addEnemy(GameObject enemyAdded)
    {
        EnemiesOnField = ShortcutFunctions.addArrays(EnemiesOnField, enemyAdded);
    }
    public void addEnemy(GameObject[] enemiesAdded)
    {
        EnemiesOnField = ShortcutFunctions.addArrays(EnemiesOnField, enemiesAdded);
    }
    private void SpawnEnemies(int L)
    {
        int currentLevelOn = 0;
        int amountOfEnemies = 0;
        GameObject[] tempEnemies = new GameObject[50];
        for (int i = 0; i < enemyWaves.Length; i++)
        {
            if (enemyWaves[i] == null)
            {
                currentLevelOn++;
            }
            else if (currentLevelOn == L)
            {
                tempEnemies[amountOfEnemies] = Instantiate(enemyWaves[i], new Vector2(Random.Range(rangeOfEnemySpawnXMin[L], rangeOfEnemySpawnXMax[L]), Random.Range(rangeOfEnemySpawnYMin[L], rangeOfEnemySpawnYMax[L])), Quaternion.identity.normalized);
            }
        }
        GameObject[] oldEnemies = ShortcutFunctions.compactGameObjectArray(EnemiesOnField);
        tempEnemies = ShortcutFunctions.compactGameObjectArray(tempEnemies);
        EnemiesOnField = ShortcutFunctions.addArrays(oldEnemies, tempEnemies);
    }
    private void SwitchStage(int NewStage)
    {
        if (NewStage != Stage)
        {
            //Change stage background
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(Level);
    }

    // Update is called once per frame
    void Update()
    {
        int amountOfDeadEnemies = 0;
        for (int i = 0; i < EnemiesOnField.Length; i++)
        {
            if (EnemiesOnField[i] == null)
            {
                amountOfDeadEnemies++;
            }
        }
        if (((float)amountOfDeadEnemies / (float)EnemiesOnField.Length) * (float)100 > enemyDeathThreshHold[Level])
        {
            Level++;
            SpawnEnemies(Level);
        }
    }
}
