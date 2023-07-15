using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{

    private Animator _animatior;

    public void Start()
    {
        _animatior = GetComponent<Animator>();
    }

    public void MoveFromHomeToCreditScreen()
    {
        _animatior.SetTrigger("HomeToCreditsTrigger");
    }

    public void MoveFromCreditsToHomeScreen()
    {

    }

    public void MoveFromHomeToModeSelectScreen()
    {

    }

    public void MoveFromModeSelectToHomeScreen()
    {

    }

    public void LoadGame()
    {

    }
}
