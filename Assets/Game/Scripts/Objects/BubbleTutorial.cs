using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BubbleTutorial : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void Start()
    {
        StartCoroutine(StartTutorial());
    }

    private IEnumerator StartTutorial()
    {
        for (int i = 0; i < 4; i++)
        {

            if (i == 0)
            {
                _text.text = "Бегай W,A,S,D, бей лопатой по ЛКМ и ПКМ";
            }

            if (i == 1)
            {
                _text.text = "Защищай меня от жуков и не допускай, чтобы меня сожрали";
            }

            if (i == 2)
            {
                _text.text = "Справишься, и я отправлю тебя домой";
            }

            if(i == 3)
            {
                gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(4f);
        }
    }
}
