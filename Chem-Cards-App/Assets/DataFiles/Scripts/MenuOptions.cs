using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{

    private Animator _animator;

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveFromHomeToCreditScreen()
    {
        _animator.SetTrigger("HomeToCreditsTrigger");
    }

    public void MoveFromCreditsToHomeScreen()
    {
        _animator.SetTrigger("CreditsToHomeTrigger");
    }

    public void MoveFromHomeToModeSelectScreen()
    {
        _animator.SetTrigger("HomeToModeSelectTrigger");
    }

    public void MoveFromModeSelectToHomeScreen()
    {
        _animator.SetTrigger("ModeSelectToHomeTrigger");
    }

    public void LoadGame()
    {

    }
}
