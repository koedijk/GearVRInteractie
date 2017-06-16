using UnityEngine;

public class GazeRaycast : MonoBehaviour {

    public RaycastHit Hit;
    public Ray Ray;
    private int _layer_mask;
    // Use this for initialization
    void Awake ()
    {
        _layer_mask = LayerMask.GetMask("Buttons");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(Ray, out Hit, _layer_mask))
        {
        }
    }
}
