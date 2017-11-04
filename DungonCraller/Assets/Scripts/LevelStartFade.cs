using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartFade : MonoBehaviour {
    [SerializeField]
    Image blockingOverlay;
    [SerializeField]
    float _removalLength = 4f;
    bool _removed = false;
    [SerializeField]
    float _smoothnessMiliseconds = 100f;

	// Use this for initialization
	void Awake ()
    {
        RoomSpawner.LevelGeneratedEvent.AddListener(RemoveOverlay);	
	}


    void RemoveOverlay()
    {
        if (!_removed)
            StartCoroutine (Remove ());

        _removed = true;
    }

    IEnumerator Remove ()
    {
        float startColor = blockingOverlay.color.a;
        float interval = 0.001f * _smoothnessMiliseconds;
        float block = interval / _removalLength;
        

        while (blockingOverlay.color.a > 0)
        {
            yield return new WaitForSeconds (interval);

            blockingOverlay.color = new Color(blockingOverlay.color.r, blockingOverlay.color.g, blockingOverlay.color.b, blockingOverlay.color.a - block);
        }

        blockingOverlay.gameObject.SetActive (false);
    }
}
