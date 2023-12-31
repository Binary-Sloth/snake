using System.Collections;
using TMPro;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    private Animator animator;
    TextMeshProUGUI textMeshProUGUI;
    private float deltaTime = 1.34f;
    private string[] words = {"On Your Marks", "Get Set", "Go!"};

    private int currentWordIndex;
    
    private void Start()
    {
        gameController.gameActive = false;

        // deltaTime = 1f;

        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        animator = this.GetComponentInChildren<Animator>();
        currentWordIndex = 0;

        StartCoroutine(DisplayWords());
    }

    IEnumerator DisplayWords()
    {
        while (currentWordIndex < words.Length)
        {
            textMeshProUGUI.text = words[currentWordIndex];
            currentWordIndex++;

            yield return new WaitForSeconds(deltaTime);
        }
        
        gameObject.SetActive(false);
        gameController.gameActive = true;

    }

}
        // index = 0;
        // textbox.text = wordList[index];
        
//         nextUpdate = Time.time + deltaTime;
//     }

//     void FixedUpdate()
//     {
        
//         if (Time.time < nextUpdate){
//             return;
//         }

//         if (index < wordList.Count) {
//             textbox.text = wordList[index];
//             nextUpdate = Time.time + deltaTime;
//             index += 1;
//         }

//         else {
//             gameObject.SetActive(false);
//             gameController.gameActive = true;
//         }
//     }

// }