using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class NeuroNet
{
    public static float mutationPower = 50f; //В класс-конфиг
    public static float mutationProb = 0.2f; //В класс-конфиг
    public int countInput, countOutput, countHidenLayer, countHidenNeuron;
    public Layer inputLayer;
    public Layer[] hidenLayers;
    public Layer outputLayer;

    public NeuroNet() { }

    public NeuroNet(int countInput, int countOutput, int countHidenLayer, int countHidenNeuron)
    {
        this.countInput = countInput;
        this.countOutput = countOutput;
        this.countHidenLayer = countHidenLayer;
        this.countHidenNeuron = countHidenNeuron;
        inputLayer = new Layer(countInput);
        hidenLayers = new Layer[countHidenLayer];
        hidenLayers[0] = new Layer(countHidenNeuron, inputLayer);
        for (int i = 1; i < countHidenLayer; i++)
        {
            hidenLayers[i] = new Layer(countHidenNeuron, hidenLayers[i - 1]);
        }
        outputLayer = new Layer(countOutput, hidenLayers[countHidenLayer - 1]);
    }

    public NeuroNet(NeuroNet netA, NeuroNet netB)
    {
        this.countInput = netA.countInput;
        this.countOutput = netA.countOutput;
        this.countHidenLayer = netA.countHidenLayer;
        this.countHidenNeuron = netA.countHidenNeuron;
        inputLayer = new Layer(countInput);
        hidenLayers = new Layer[countHidenLayer];
        hidenLayers[0] = new Layer(countHidenNeuron, inputLayer);
        for (int i = 1; i < countHidenLayer; i++)
        {
            hidenLayers[i] = new Layer(countHidenNeuron, hidenLayers[i - 1]);
        }
        outputLayer = new Layer(countOutput, hidenLayers[countHidenLayer - 1]);
        for (int i = 0; i < countHidenLayer; i++)
        {
            hidenLayers[i].Gybrid(netA.hidenLayers[i], netB.hidenLayers[i]);
        }
        outputLayer.Gybrid(netA.outputLayer, netB.outputLayer);
    }

    public NeuroNet(NeuroNet netA)
    {
        this.countInput = netA.countInput;
        this.countOutput = netA.countOutput;
        this.countHidenLayer = netA.countHidenLayer;
        this.countHidenNeuron = netA.countHidenNeuron;
        inputLayer = new Layer(countInput);
        hidenLayers = new Layer[countHidenLayer];
        for (int i = 0; i < countHidenLayer; i++)
        {
            hidenLayers[i] = new Layer(netA.hidenLayers[i]);
        }
        outputLayer = new Layer(netA.outputLayer);
    }

    public float[] GetOutput(float[] inputs)
    {
        inputLayer.Input(inputs);
        foreach (Layer currentLayer in hidenLayers)
        {
            currentLayer.Calc();
        }
        outputLayer.Calc();
        return outputLayer.GetValues();
    }
}