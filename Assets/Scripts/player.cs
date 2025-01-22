using System.Collections;

using UnityEngine;
using UnityEngine.UI; 

public class player : MonoBehaviour
{
public int force =5;
    private int score = 0;
    public Text text;
private Rigidbody rd;
    public GameObject winText;
    public GameObject loseText;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rd.AddForce(new Vector3(h, 0, v) * force);
    }
        void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "pickup")
            {
            score++;
            text.text=score.ToString();
          
            if(score==17)
            {
                winText.SetActive(true);
            }
                Destroy(collider.gameObject);
            }
        if (collider.tag == "unpickup")
        {
            score--;
            text.text = score.ToString();

            if (score <0)
            {
                loseText.SetActive(true);
            }
            Destroy(collider.gameObject);
        }
    }
}

