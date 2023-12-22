using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogueBox;
    public Text dialogueText;
    public GameObject F;
    public int sceneToLoad;

    private string content = "EnterÌø×ª³¡¾°";
    private bool triggerKey;
    private bool dialogKey;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && triggerKey)
        {
            F.SetActive(false);
            dialogueBox.SetActive(true);
            dialogueText.text = content;
            dialogKey = true;
        }
        if(dialogKey == true && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            F.SetActive(true);
            triggerKey = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            F.SetActive(false);
            dialogueBox.SetActive(false);
            triggerKey = false;
            dialogKey = false;
        }
    }

}
