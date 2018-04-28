using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleBehaviour : MonoBehaviour {

	public int pointValue;
    //needs to be in gameobject powerUp.
    public bool item;
    public string boost;
    int powerUpTime = 3;
    public TongueBehaviour powerUpTB;

    public int Eat()
    {
        if (item == true)
        {
            PickUp();
						return 0;
        } else
        {
            return ConsumeAnt();
        }
    }

	public int ConsumeAnt() {
		Debug.Log("You ate: " + name + ", worth " + pointValue + " points");
		Destroy(this.gameObject);

		return pointValue;
	}

  public void PickUp()

	  {
        if("speed" == boost)
        {
            Invoke("speedUp", 1.0f);

        }else if ("slow" == boost)
        {
            Invoke("slowDown", 1.0f);
        }


				this.gameObject.SetActive(false);
    }

    public void speedUp()
    {
        if (powerUpTime > 0)
        {
            powerUpTB.moveSpeed *= 2;
            --powerUpTime;
        }
        else if (powerUpTime == 0)
        {
            powerUpTB.moveSpeed = 0.02f;
            powerUpTime = 3;
        }
    }

    public void slowDown()
    {
        if (powerUpTime > 0)
        {
            powerUpTB.moveSpeed /= 2;
            --powerUpTime;
        }
        else if (powerUpTime == 0)
        {
            powerUpTB.moveSpeed = 0.02f;
            powerUpTime = 3;
        }
    }
}
