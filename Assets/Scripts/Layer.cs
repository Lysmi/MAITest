using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Layer
{
    public Layer prevLayer;
    public Neuron[] neurons;

    public Layer() { }

    public Layer(int count)
    {
        neurons = new Neuron[count];
        for (int i = 0; i < neurons.Length; i++)
        {
            neurons[i] = new Neuron();
        }
    }
    public Layer(Layer layer)
    {
        neurons = new Neuron[layer.neurons.Length];
        prevLayer = layer.prevLayer;
        for (int i = 0; i < neurons.Length; i++)
        {
            neurons[i] = new Neuron(layer.neurons[i]);
        }
    }

    public Layer(int count, Layer prev)
    {
        neurons = new Neuron[count];
        prevLayer = prev;
        for (int i = 0; i < neurons.Length; i++)
        {
            neurons[i] = new Neuron(prevLayer.neurons.Length);
        }
    }

    public void Gybrid(Layer layerA, Layer layerB)
    {
        for (int i = 0; i < neurons.Length; i++)
        {
            neurons[i] = new Neuron(layerA.neurons[i], layerB.neurons[i]);
        }
    }


    public void Calc()
    {
        for (int i = 0; i < neurons.Length; i++)
        {
            neurons[i].value = 0;
            for (int j = 0; j < prevLayer.neurons.Length; j++)
            {
                neurons[i].value += neurons[i].weight[j] * prevLayer.neurons[j].value;
            }
            neurons[i].value += neurons[i].byes;
            if (Mathf.Abs(neurons[i].value) > 1)
            {
                neurons[i].Activation();
            }
        }
    }

    public void Input(float[] inputs)
    {
        for (int i = 0; i < neurons.Length; i++)
        {
            neurons[i].value = inputs[i];
            if (Mathf.Abs(neurons[i].value) > 1)
            {
                neurons[i].Activation();
            }
        }
    }

    public float[] GetValues()
    {
        float[] result = new float[neurons.Length];
        for (int i = 0; i < neurons.Length; i++)
        {
            result[i] = neurons[i].value;
        }
        return result;
    }
}
