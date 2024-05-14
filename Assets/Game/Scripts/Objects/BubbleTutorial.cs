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
                _text.text = "����� W,A,S,D, ��� ������� �� ��� � ���";
            }

            if (i == 1)
            {
                _text.text = "������� ���� �� ����� � �� ��������, ����� ���� �������";
            }

            if (i == 2)
            {
                _text.text = "����������, � � �������� ���� �����";
            }

            if(i == 3)
            {
                gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(4f);
        }
    }
}
