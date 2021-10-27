using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Neuron
{
    public float[] weight { get; set; }
    public float value;
    public float byes;
    public Neuron(int countWeight)
    {
        value = 0;
        byes = Random.Range(-1f, 1f) * NeuroNet.mutationPower;
        weight = new float[countWeight];
        for (int i = 0; i < countWeight; i++)
        {
            weight[i] = Random.Range(-1f, 1f) * NeuroNet.mutationPower;
        }
    }

    public Neuron()
    {
        value = 0;
        byes = Random.Range(-1f, 1f) * NeuroNet.mutationPower;
        weight = null;
    }

    public Neuron(Neuron neuron)
    {
        value = neuron.value;
        byes = neuron.byes;
        weight = new float[neuron.weight.Length];
        for (int i = 0; i < weight.Length; i++)
        {
            weight[i] = neuron.weight[i];
        }
    }

    public Neuron(Neuron neuronA, Neuron neuronB)
    {
        weight = new float[neuronA.weight.Length];
        if (Random.Range(0f, 1f) > 0.5)
        {
            byes = neuronA.byes;
        }
        else
        {
            byes = neuronB.byes;
        }
        if (Random.Range(0f, 1f) < NeuroNet.mutationProb)
        {
            byes += Random.Range(-1f, 1f) * NeuroNet.mutationPower;
        }
        for (int i = 0; i < neuronA.weight.Length; i++)
        {
            if (Random.Range(0f, 1f) > 0.5)
            {
                weight[i] = neuronA.weight[i];
            }
            else
            {
                weight[i] = neuronB.weight[i];
            }
            if (Random.Range(0f, 1f) < NeuroNet.mutationProb)
            {
                weight[i] += Random.Range(-1f, 1f) * NeuroNet.mutationPower;
            }
        }
    }

    public void Activation()
    {
        float exp = Mathf.Exp(value / 40);
        value = (exp - 1) / (exp + 1);
    }
}

