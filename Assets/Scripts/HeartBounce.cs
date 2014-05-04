using UnityEngine;
using System.Collections;

public class HeartBounce : MonoBehaviour {
    public GUIText hitCount;
    public int numHits = 0;
    public bool hasLost = false;

    int bestScore = 0;
    int lastBest = 0;

    bool velocityWasStored = false;
    Vector3 storedVelocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        string str = "";
        if (!hasLost)
        {
            str = numHits.ToString();
        }
        else
        {
            str += "Hits:" + numHits.ToString() + "\nYour best:" + bestScore;
            if(bestScore>lastBest)
            {
                str += "\nNEW RECORD";
            }
        }
        hitCount.text=str;
        if (transform.position.y < -3)
        {
            if (!hasLost)
            {
                hasLost = true;
                lastBest = bestScore;
                if (numHits > bestScore)
                {
                    bestScore = numHits;
                }
            }
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag.CompareTo("tray") == 0)
        {
            Debug.Log("hit");
            if (!velocityWasStored)
            {
                storedVelocity = rigidbody.velocity;
                velocityWasStored = true;
            }
            if (rigidbody.velocity.y > 1)
            {
                numHits++;
            }
            rigidbody.velocity = storedVelocity;
        }
    }

    void OnGUI()
    {
        if (hasLost)
        {
            float buttonW = 100.0f;
            float buttonH = 50.0f;

            float halfScreenW = (float)(Screen.width / 2);
            float halfButtonW = buttonW / 2;

            if (GUI.Button(new Rect(halfScreenW - halfButtonW, Screen.height * 0.8f, buttonW, buttonH), "Play Again")) 
            {
                numHits = 0;
                hasLost = false;
                transform.position = new Vector3(0.5f, 2.0f, -0.05f);
                rigidbody.velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
