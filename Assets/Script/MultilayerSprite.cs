using UnityEngine;

public class MultilayerSprite : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] float offset;
    SpriteRenderer rend, targetRend;

	void Start () {
        rend = GetComponent<SpriteRenderer>();
        targetRend = target.GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate () {
        if (target.position.y >= transform.position.y + offset)
            rend.sortingOrder = targetRend.sortingOrder + 1;
        else
            rend.sortingOrder = targetRend.sortingOrder - 1;
    }
}
