using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Class for taking input from keystrokes and outputting to the code "screen" the text read in from file.
/// Said text will be read in, in the *CodeReader* class and accessed here.
/// </summary>
public class KeystrokeHandler : MonoBehaviour 
{
    private CodeReader reader;
    private Text code;
    public string fileLocation;
    private string line;
    private int characterCounter;

    //for loading web files
    private WWW webReader;
    public string url;
    public string[] urls;
    bool done;

	// Use this for initialization
	void Start () 
    {
        ResetReader();
        code = GetComponent<Text>();
        //line = reader.ReadLine();
        characterCounter = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if( done && Input.anyKeyDown 
            && !Input.GetMouseButton(0)
            && !Input.GetMouseButton(1)
            && !Input.GetMouseButton(2))
        {
            KeystrokeManager.AddUserStroke();
            if(line != null && characterCounter < line.Length)
            {
                code.text += line[characterCounter];
                characterCounter++;
            }
            else
            {
                line = reader.ReadLine();
                if(line == null)
                {
                    done = false;
                    ResetReader();
                }
                code.text += "\n";
                characterCounter = 0;
            }
        }
        if(code.rectTransform.sizeDelta.y > 0)
        {
            //Debug.Log(code.text.IndexOf("\n", 3));
            int index = code.text.IndexOf("\n");
            code.text = code.text.Substring(index + 1);
        }
	
	}

    private void ResetReader()
    {
        /*
        //for non web
        if(reader != null)
        {
            reader.Close();
        }
        */
        reader = new CodeReader();
        //for web
        StartCoroutine("Download");
        //for download
        //reader.Initialize(Application.dataPath + "/CodeSnippets/" + fileLocation);
        //line = reader.ReadLine();
    }



    private IEnumerator Download()
    {
        webReader = new WWW(url + urls[Random.Range(0,urls.Length)]);
        yield return webReader;
        reader.Initialize(webReader);
        line = reader.ReadLine();
        done = true;

    }
}
