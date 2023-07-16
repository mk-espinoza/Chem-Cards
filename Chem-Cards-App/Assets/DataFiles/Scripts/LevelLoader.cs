using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transitionAnimator;
    public float transitionTime = 1f;

    public void PlayGame()
    {
        StartCoroutine(LoadLevel("ARScene"));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        // Play animation
        transitionAnimator.SetTrigger("StartTransitionTrigger");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        SceneManager.LoadScene(sceneName);
    }
}
