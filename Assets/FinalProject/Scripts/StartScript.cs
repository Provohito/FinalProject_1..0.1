using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    [SerializeField]
    private Scrollbar scrollbar;

    private void Start()
    {
        StartCoroutine(FirstLoad());
    }

    IEnumerator FirstLoad()
    {

        yield return new WaitForSeconds(3f);
        for (float ft = scrollbar.size; ft <= 1; ft += 0.0025f)
        {
            scrollbar.size += ft;
            yield return new WaitForSeconds(.05f);
            if (scrollbar.size == 1)
            {
                Debug.Log("Win");
                StopAllCoroutines();
            }
        }
    }

}
