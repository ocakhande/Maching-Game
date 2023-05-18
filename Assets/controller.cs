using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    [SerializeField] wallController value;
    int openedCount = 0;
    int childindex, childindex2;
    [SerializeField] private GameObject animationPrefab;
    [SerializeField] private GameObject smokePrefab;

    GameObject firstOpenObject;
    GameObject secondOpenObject;
    // [SerializeField] private Congrats _congrats;
    bool control = true;

    private void Start()
    {
       
        value.CreateCards(8, 6);
      //  StartCoroutine(EndGameAfterDelay(10f));

    }

    void Update()
    {
       


            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.CompareTag("Wall") && control == true)
                        {

                            hit.transform.DORotate(new Vector3(0, 180, 0), 0.5f);





                            openedCount++;
                            if (openedCount == 1)
                            {
                                hit.transform.gameObject.GetComponent<Collider>().enabled = false;
                                firstOpenObject = hit.transform.gameObject;

                                for (int i = 0; i < firstOpenObject.transform.childCount - 2; i++)
                                {
                                    if (firstOpenObject.transform.GetChild(i).gameObject.activeSelf == true)
                                    {
                                        childindex = i;
                                    }

                                }

                                Debug.Log("first " + firstOpenObject.tag);
                                Debug.Log(childindex);

                            }
                            else if (openedCount == 2)
                            {

                                control = false;
                                secondOpenObject = hit.transform.gameObject;

                                for (int i = 0; i < secondOpenObject.transform.childCount - 2; i++)
                                {
                                    if (secondOpenObject.transform.GetChild(i).gameObject.activeSelf == true)
                                    {
                                        childindex2 = i;
                                    }

                                }
                                Debug.Log(childindex2);
                                Debug.Log("second" + secondOpenObject.tag);

                                if (firstOpenObject.transform.GetChild(childindex).gameObject.tag == secondOpenObject.transform.GetChild(childindex2).gameObject.tag)
                                {
                                    var animation = Instantiate(animationPrefab, firstOpenObject.gameObject.transform.position, firstOpenObject.gameObject.transform.rotation);
                                    var animation2 = Instantiate(animationPrefab, secondOpenObject.gameObject.transform.position, secondOpenObject.gameObject.transform.rotation);
                                    ParticleSystem ps = animation.GetComponent<ParticleSystem>();
                                    var main = ps.main;
                                    StartCoroutine(DestroyWalls());

                                }
                                else
                                {
                                    var smoke = Instantiate(smokePrefab, firstOpenObject.gameObject.transform.position, firstOpenObject.gameObject.transform.rotation);
                                    var smoke2 = Instantiate(smokePrefab, secondOpenObject.gameObject.transform.position, secondOpenObject.gameObject.transform.rotation);
                                    ParticleSystem ps = smoke.GetComponent<ParticleSystem>();
                                    ParticleSystem ps1 = smoke2.GetComponent<ParticleSystem>();

                                    var main = ps.main;
                                    var main1 = ps1.main;

                                    StartCoroutine(WaitRotate(firstOpenObject));
                                    StartCoroutine(WaitRotate(secondOpenObject));
                                    openedCount = 0;
                                    firstOpenObject = null;
                                    secondOpenObject = null;

                                }
                            }
                        }

                    }
                }
            }
        }
 

        private IEnumerator WaitRotate(GameObject hit)
        {
            yield return new WaitForSeconds(0.7f);
            hit.transform.DORotate(new Vector3(0, 0, 0), 0.5f);
            control = true;
            hit.transform.gameObject.GetComponent<Collider>().enabled = true;

        }
        private IEnumerator DestroyWalls()
        {
            yield return new WaitForSeconds(0.4f);
            Destroy(firstOpenObject);
            Destroy(secondOpenObject);
            openedCount = 0;
            firstOpenObject = null;
            secondOpenObject = null;
            control = true;
        }

    IEnumerator EndGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

} 

