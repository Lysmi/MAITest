using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Data
{
    public int branchCount;
    public List<List<NeuroNet>> branches;

    public Data(List<List<GameObject>> creatures)
    {
        this.branchCount = creatures.Count;
        this.branches = new List<List<NeuroNet>>();
        for (int i = 0; i < this.branchCount; i++)
        {
            List<GameObject> branch = creatures[i];
            this.branches.Add(new List<NeuroNet>());
            for (int j = 0; j < branch.Count; j++)
            {
                this.branches[i].Add(branch[j].GetComponent<ICreature>().net);
            }
        }
    }
}
