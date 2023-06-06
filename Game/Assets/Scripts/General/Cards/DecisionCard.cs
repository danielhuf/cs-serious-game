using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.IO;

[System.Serializable]
public class DecisionCard
{
    public string id;
    public List<Dependency> dependency;
    public string actor;
    public float prob;
    public string content;
    public List<Answer> answers;
}

