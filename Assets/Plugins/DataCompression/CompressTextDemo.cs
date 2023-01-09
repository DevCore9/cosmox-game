using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompressTextDemo : MonoBehaviour
{
    /*
     * This demo illustrates how to take a string (or char array) and compress it 
     * into a binary file with a single function. The data is then loaded, decompressed
     * and displayed.
     */ 


    public UnityEngine.UI.Text outputText;

    void Start()
    {
        // Load text and convert to char array
        string sourceText = HamletText.Hamlet;
        char[] sourceArray = sourceText.ToCharArray();
        int size = sourceArray.Length;

        // Compress char array and save to file
        bool status = SDCompression.SaveCompressed<char>(sourceArray, "Hamlet_compressed");
        if (status)
            Debug.Log("Compression successful");
        else
            Debug.LogError("Compression failed");

        // Load and decompress char array
        char[] decompressedArray = SDCompression.LoadCompressed<char>(size, "Hamlet_compressed");

        // Test Decompressed data
        string testString = "";
        for (int i = 500; i < 1000; i++)
            testString += decompressedArray[i];
        outputText.text = testString;

        // Save uncompressed data to compare file sizes
        SaveUncompressed(sourceArray);
        CompareFileSizes();
    }


    void SaveUncompressed(char[] data)
    {
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        System.IO.FileStream file = System.IO.File.Create(Application.persistentDataPath + "/Hamlet_uncompressed.dat");
        bf.Serialize(file, data);
        file.Close();
    }

    void CompareFileSizes()
    {
        var fileInfo_uncompressed = new System.IO.FileInfo(Application.persistentDataPath + "/Hamlet_uncompressed.dat");
        var fileInfo_compressed = new System.IO.FileInfo(Application.persistentDataPath + "/Hamlet_compressed.dat");

        Debug.Log("Uncompressed file size: " + fileInfo_uncompressed.Length);
        Debug.Log("Compressed file size: " + fileInfo_compressed.Length);
        Debug.Log("Compression ratio: " + (100 - (double)fileInfo_compressed.Length / (double)fileInfo_uncompressed.Length * (double)100f) + "%");
    }


}
