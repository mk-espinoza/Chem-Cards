using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

public class MoleculeController : MonoBehaviour
{

    public Texture2D[] ImageMarkers;

    public bool CheckImageName(string targetName)
    {
        foreach (Texture2D texture2D in ImageMarkers)
        {
            if (string.Equals(targetName, texture2D.name))
                return true;

        }

        return false;
    }
}


