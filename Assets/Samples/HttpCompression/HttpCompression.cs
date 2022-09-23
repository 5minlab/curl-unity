using CurlUnity;
using System;
using System.IO;
using UnityEngine;

public class HttpCompression : MonoBehaviour
{
    public bool flag_gzip = true;

    void Start()
    {
        var easy = new CurlEasy();
        easy.uri = new Uri("https://www.google.com");
        easy.timeout = 5000;
        easy.debug = true;

        if (flag_gzip)
        {
            easy.SetHeader("Accept-Encoding", "gzip");
        }

        var result = easy.Perform();
        Debug.Log($"{result} status={easy.status}");
        Debug.Log($"inDataLength: {easy.inDataLength}");

        if (result == CURLE.OK)
        {
            Debug.Log($"inTextLength: {easy.inText.Length}");
            Debug.Log(easy.inText.Substring(0, 100));
        }
    }
}
