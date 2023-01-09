using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCompressionDemo : MonoBehaviour
{
    /*
     * This demo illustrates how to compress and save date with a single function 
     * and then load and decompress with another function. A sample 2D float array
     * is generated for the demonstration.
     */

    // Size of our array
    int arraySize2D = 1000;

    void Start()
    {
        // Sample array to be compressed
        float[,] dataset = new float[arraySize2D, arraySize2D];

        // Build a sample dataset to compress
        for (int i = 0; i < arraySize2D; i++)
            for (int j = 0; j < arraySize2D; j++)
                dataset[i, j] = -50.5f + (i * arraySize2D + j) * 2.3f;

        // Compress and save our dataset
        SDCompression.SaveCompressed<float>(dataset, "DataCompressed");

        // Load and decompress our dataset
        float[,] decompressedDataset = SDCompression.LoadCompressed<float>(arraySize2D, arraySize2D, "DataCompressed");

        // Compare arrays to check for errorss
        if (CompareArrays(dataset, decompressedDataset, arraySize2D, arraySize2D))
            Debug.Log("No errors found.");
        else
            Debug.LogError("Error found!");

        // Save uncompressed data also so we can compare file sizes
        SaveUncompressed(dataset);
        CompareFileSizes();

    }

    void SaveUncompressed(float[,] data)
    {
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        System.IO.FileStream file = System.IO.File.Create(Application.persistentDataPath + "/DataUncompressed.dat");
        bf.Serialize(file, data);
        file.Close();
    }

    void CompareFileSizes()
    {
        var fileInfo_uncompressed = new System.IO.FileInfo(Application.persistentDataPath + "/DataUncompressed.dat");
        var fileInfo_compressed = new System.IO.FileInfo(Application.persistentDataPath + "/DataCompressed.dat");

        Debug.Log("Uncompressed file size: " + fileInfo_uncompressed.Length);
        Debug.Log("Compressed file size: " + fileInfo_compressed.Length);
        Debug.Log("Compression ratio: " + (100 - (double)fileInfo_compressed.Length / (double)fileInfo_uncompressed.Length * (double)100f) + "%");
    }

    bool CompareArrays(float[,] array1, float[,] array2, int sizeA, int sizeB)
    {
        for (int i = 0; i < sizeA; i++)
            for (int j = 0; j < sizeB; j++)
                if (array1[i, j] != array2[i, j])
                    return false;
        return true;
    }
}
