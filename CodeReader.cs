using System.Collections;
using System.IO;
using System;
using UnityEngine;

public class CodeReader 
{
    private string line;

    /*
    //for non web use
    private StreamReader reader;
    public void Initialize(string fileName)
    {
        reader = new StreamReader(fileName);
        line = reader.ReadLine();
    }

    public void Close()
    {
        //reader.Close();
    }
     * */

    //for web use
    private WWW webReader;
    private string file;
    public void Initialize(WWW wReader)
    {
        webReader = wReader;
        file = webReader.text;
    }

    public string ReadLine()
    {
        int index = file.IndexOf("\n");
        if (index > 0)
        {
            line = file.Substring(0, index);
            file = file.Substring(index + 1);
        }
        else
            line = null;
        return line;
    }


};
