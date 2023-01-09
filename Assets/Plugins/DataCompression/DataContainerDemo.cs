using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/* 
 * This demo shows how to collect different data types im a custom class,
 * compress them, and then save them to a binary file. Finally, the file is 
 * loaded, decompressed, and the data is retrieved.
 */ 

public class DataContainerDemo : MonoBehaviour
{

    // Custom class for storing compressed data arrays
    [System.Serializable]
    public class Container
    {
        public SDCompression.SingleByteArray floatArray2D_compressed;
        public SDCompression.ShortByteArray ushortArray1D_compressed;
        public SDCompression.LongByteArray ulongArray2D_compressed;
        public byte[] boolArray1D_compressed;
    }

    // Sample dataset arrays
    float[,] floatArray2D = new float[2000, 200];
    ushort[] ushortArray = new ushort[3000];
    ulong[,] ulongArray2D = new ulong[750, 3000];
    bool[] boolArray = new bool[1200];


    // Container for storing compressed data
    Container container = new Container();

    void Start()
    {
        // Populate dataset
        Debug.Log("Building Dataset");
        BuildDataset();

        // Compress data and store in container
        Debug.Log("Compressing Dataset");
        CompressData();

        // Save the data container
        Debug.Log("Saving Container");
        SaveContainer();

        // Load data container
        Debug.Log("Loading Container");
        Container loadedCompressedContainer = LoadContainer();

        // Decompress data container and retrive data
        Debug.Log("Decompressing Container");
        float[,] dcmpr_floatArray2D = SDCompression.DecompressArray<float>(loadedCompressedContainer.floatArray2D_compressed, 2000, 200);
        ushort[] dcmpr_ushortArray = SDCompression.DecompressArray<ushort>(loadedCompressedContainer.ushortArray1D_compressed, 3000);
        ulong[,] dcmpr_ulongArray2D = SDCompression.DecompressArray<ulong>(loadedCompressedContainer.ulongArray2D_compressed, 750, 3000);
        bool[] dcmpr_boolArray = SDCompression.DecompressArray<bool>(loadedCompressedContainer.boolArray1D_compressed, 1200);

        // Compare decompressed arrays with originals and check for errors
        Debug.Log("Checking For Errors");
        if (!CompareArrays(floatArray2D, dcmpr_floatArray2D, 2000, 200))
            Debug.LogError("float Array Mismach!");
        else
            Debug.Log("No errors found.");
        if (!CompareArrays(ushortArray, dcmpr_ushortArray, 3000))
            Debug.LogError("ushort Array Mismach!");
        else
            Debug.Log("No errors found.");
        if (!CompareArrays(ulongArray2D, dcmpr_ulongArray2D, 750, 3000))
            Debug.LogError("ulong Array Mismach!");
        else
            Debug.Log("No errors found.");
        if (!CompareArrays(boolArray, dcmpr_boolArray, 1200))
            Debug.LogError("bool Array Mismach!");
        else
            Debug.Log("No errors found.");

    }

    void BuildDataset()
    {
        for (int i = 0; i < 2000; i++)
            for (int j = 0; j < 200; j++)
                floatArray2D[i, j] = (j % 10) * 5 * i;
        for (int i = 1; i < 3000; i++)
            ushortArray[i] = (ushort)(4 + ushortArray[i - 1]);
        for (int i = 0; i < 750; i++)
            for (int j = 0; j < 3000; j++)
                ulongArray2D[i, j] = (ulong)((j - i) * 3);
        for (int i = 1; i < 1200; i++)
        {
            if (i % 4 == 0)
                boolArray[i] = true;
            else
                boolArray[i] = false;
        }
    }

    void CompressData()
    {
        container.floatArray2D_compressed = SDCompression.CompressArraySingle<float>(floatArray2D, 2000, 200);
        container.ushortArray1D_compressed = SDCompression.CompressArrayShort<ushort>(ushortArray, 3000);
        container.ulongArray2D_compressed = SDCompression.CompressArrayLong<ulong>(ulongArray2D, 750, 3000);
        container.boolArray1D_compressed = SDCompression.CompressArrayByte<bool>(boolArray, 1200);
    }

    void SaveContainer()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "DataContainerCompression.dat");
        bf.Serialize(file, container);
        file.Close();
    }

    Container LoadContainer()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "DataContainerCompression.dat", FileMode.Open);
        Container loadedContainer_compressed = (Container)bf.Deserialize(file);
        file.Close();
        return loadedContainer_compressed;
    }

    bool CompareArrays(float[,] array1, float[,] array2, int sizeA, int sizeB)
    {
        for (int i = 0; i < sizeA; i++)
            for (int j = 0; j < sizeB; j++)
                if (array1[i, j] != array2[i, j])
                    return false;
        return true;
    }

    bool CompareArrays(ulong[,] array1, ulong[,] array2, int sizeA, int sizeB)
    {
        for (int i = 0; i < sizeA; i++)
            for (int j = 0; j < sizeB; j++)
                if (array1[i, j] != array2[i, j])
                    return false;
        return true;
    }

    bool CompareArrays(ushort[] array1, ushort[] array2, int size)
    {
        for (int i = 0; i < size; i++)
            if (array1[i] != array2[i])
                return false;
        return true;
    }

    bool CompareArrays(bool[] array1, bool[] array2, int size)
    {
        for (int i = 0; i < size; i++)
            if (array1[i] != array2[i])
                return false;
        return true;
    }

}
