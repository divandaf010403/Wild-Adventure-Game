using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pergerakan : MonoBehaviour
{
    int[] posX = new int[] { 0, -1900, -3800, -5700, -7600 };
	int idx = 0;

    public Object[] obj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (idx < posX.Length - 1)
            {
                idx++;
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (idx > 0)
            {
                idx--;
            }
        }
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(posX[idx], transform.localPosition.y), 1000 * Time.deltaTime);
    }
}
