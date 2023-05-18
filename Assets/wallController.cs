using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using System;


public class wallController : MonoBehaviour
{
    //public List<GameObject> Prefabcards = new List<GameObject>();
    public GameObject Prefabcard;
    [SerializeField] private GameObject animal1;
    [SerializeField] private GameObject animal2;
    public GameObject Cards;
    public float spacing = 1f;
    public int row, col;
    public int randomChild1;
    List<int> childList = new List<int>();
    List<GameObject> cardsList = new List<GameObject>();
    private List<int> usedNumbers = new List<int>();
    private System.Random random = new System.Random();
    float spaceWall = 0.25f;


    public void CreateCards(int row, int col)
    {
        if (row > col)
        {
            Camera.main.transform.position = new Vector3(Cards.transform.position.x, Cards.transform.position.y, row * 2);
        }
        else if (col > row)
        {
            Camera.main.transform.position = new Vector3(Cards.transform.position.x, Cards.transform.position.y, col * 2);
        }


        if (row % 2 == 0 || col % 2 == 0)
        {

            if (row % 2 == 0)
            {
                row /= 2;

            }
            else if (col % 2 == 0)
            {
                col /= 2;

            }
            float animal1Start = 0;
            float animal2Start = 0f;
            float animal1yStart = 0;
            float animal2yStart = 0f;
                //-Prefabcard.transform.localScale.y - 0.25f;

            Debug.Log(col);

            Debug.Log(row);


            for (int i = 0; i < col; i++)
            {
                Debug.Log("test");
                for (int j = 0; j < row; j++)
                {


                    GameObject animal1 = Instantiate(Prefabcard, new Vector3(animal1Start, animal1yStart, 0), Quaternion.identity);
                    cardsList.Add(animal1);
                    animal2Start=animal1Start + 2*spaceWall ;
                    GameObject animal2 = Instantiate(Prefabcard, new Vector3(animal2Start, animal2yStart, 0), Quaternion.identity);
                    cardsList.Add(animal2);
                    animal1Start= animal2Start + 2*spaceWall ;

                    animal1.transform.SetParent(Cards.transform);
                    animal2.transform.SetParent(Cards.transform);
                   



                    //animal1Start += animal1.transform.localScale.x + spaceWall;
                    //animal2Start += animal2.transform.localScale.x + spaceWall;

                    //float cordx = (row * animal1.transform.localScale.x + row - 1 * spaceWall) / 2;
                    //float cordy = (col * animal2.transform.parent.localScale.y + col - 1 * spaceWall) / 2;

                    //Camera.main.transform.position = new Vector3(Cards.transform.position.x, Cards.transform.position.y, col*2);
                    GetUniqueRandom(0, animal1.transform.childCount - 2);



                }

                animal1Start = 0;
                animal1yStart += Prefabcard.transform.localScale.y + spaceWall;
                animal2Start = 0;
                animal2yStart -= Prefabcard.transform.localScale.y + spaceWall;

            }
        }
        foreach (var item in cardsList)
        {
            int b = UnityEngine.Random.Range(0, childList.Count - 2);
            item.transform.GetChild(childList[b]).gameObject.SetActive(true);
            childList.Remove(childList[b]);
        }
    }


    public int GetUniqueRandom(int minValue, int maxValue)
    {
        int number;
        do
        {
            number = random.Next(minValue, maxValue);
        } while (usedNumbers.Contains(number));

        usedNumbers.Add(number);

        if (usedNumbers.Count >= (maxValue - minValue))
        {
            usedNumbers.Clear();
        }
        childList.Add(number);
        childList.Add(number);
        return number;
    }

}
