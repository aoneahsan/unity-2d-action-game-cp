using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionScript : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void LoadScene(int sceneNo)
    {
        StartCoroutine(Transition(sceneNo));
    }

    IEnumerator Transition(int sceneNo)
    {
        animator.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneNo);
    }
}
