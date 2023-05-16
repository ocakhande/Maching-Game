using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using static UnityEngine.Rendering.DebugUI.Table;


public class wallController : MonoBehaviour
{
    //public List<GameObject> Prefabcards = new List<GameObject>();
    public GameObject Prefabcard;
    [SerializeField] private GameObject animal1;
    [SerializeField] private GameObject animal2;
    public float spacing = 1f;
    public int row, col;
    public int randomChild1;
    List<int> childList = new List<int>();
    List<GameObject> cardsList = new List<GameObject>();



    public void CreateCards(int row, int col)
    {
        if (row % 2 == 0 || col % 2 == 0)
        {

         
            col = row % 2 == 0 ? row / 2 : col / 2;

            float animal1Start = 0;
            float animal2Start = 0f;
            float animal1yStart = 0;
            float animal2yStart = -Prefabcard.transform.localScale.y - 0.25f;
            float spaceWall = 0.25f;




            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {


                    GameObject animal1 = Instantiate(Prefabcard, new Vector3(animal1Start, animal1yStart, 0), Quaternion.identity);
                    cardsList.Add(animal1);

                    GameObject animal2 = Instantiate(Prefabcard, new Vector3(animal2Start, animal2yStart, 0), Quaternion.identity);
                    cardsList.Add(animal2);



                    animal1Start += animal1.transform.localScale.x + spaceWall;
                    animal2Start += animal2.transform.localScale.x + spaceWall;

                    int randomChild1 = Random.Range(0, animal1.transform.childCount - 2);

                    //while (childList.Contains(randomChild1))
                    //{ 
                    //    randomChild1 = Random.Range(0, animal1.transform.childCount - 2);

                    //    if (childList.Contains(randomChild1)== false)
                    //    {
                    //        break;
                    //    }
                    //}

                    childList.Add(randomChild1);

                    childList.Add(randomChild1);

                    Debug.Log(randomChild1);
                }

                animal1Start = 0;
                animal1yStart += Prefabcard.transform.localScale.y + spaceWall;
                animal2Start = 0;
                animal2yStart -= Prefabcard.transform.localScale.y + spaceWall;

            }
        }
        foreach (var item in cardsList)
        {
            int b = Random.Range(0, childList.Count - 2);
            item.transform.GetChild(childList[b]).gameObject.SetActive(true);
            childList.Remove(childList[b]);
        }
    }



}
