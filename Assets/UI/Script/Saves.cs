using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData
{
    public List<NeuroNet> Items = new List<NeuroNet>();
}

public class Saves : MonoBehaviour
{
    public string SaveLoadPath;
    public static Trainee manager;
    public string path;

    public static void Save()
    {
        for (int i = 0; i < manager.branches.Count; i++)
        {
            var branch = manager.branches[i];
            GameData gameData = new GameData();
            foreach (var creature in branch)
            {
                gameData.Items.Add(creature.GetComponent<ICreature>().net);
            }

            string json = JsonUtility.ToJson(gameData);
            using (StreamWriter sw = new StreamWriter($"branch{i}.json", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(json);
            }
            Debug.Log(json);
        }

    }


    void Start()
    {
        
    }


    void Update()
    {

    }
}

public class Buba {
    public int k = 12;
    public int[] stuka = { 1, 2, 3, 4, 6 };
}
