using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            if(gameObject.GetComponent<Image>().color == collision.gameObject.GetComponent<Image>().color)
            {
                //Landed on correct color
                UIManager.Instance.UpdateScore(1);
                AudioManager.Instance.PlaySoundEffect(AudioIDs.POSITIVE);
                StartCorrectRemoveAnimation();
            }
            else if(collision.gameObject.GetComponent<Image>().color == Color.black)
            {
                //Landed on black
                StartNeutralRemoveAnimation();
            }
            else
            {
                //Landed on wrong color
                UIManager.Instance.UpdateScore(-1);
                AudioManager.Instance.PlaySoundEffect(AudioIDs.NEGATIVE);
                StartIncorrectRemoveAnimation();
            }
        }
    }

    void StartCorrectRemoveAnimation()
    {
        ResourcesManager.Instance.RemoveResourceInstance(gameObject);
    }

    void StartNeutralRemoveAnimation()
    {
        ResourcesManager.Instance.RemoveResourceInstance(gameObject);
    }

    void StartIncorrectRemoveAnimation()
    {
        ResourcesManager.Instance.RemoveResourceInstance(gameObject);
    }


}
