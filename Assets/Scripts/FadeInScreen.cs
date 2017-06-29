using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScreen : MonoBehaviour
{
    private Renderer _ren;

    [SerializeField, Range(0, 1)] private float alpha;
    private Color _col;

    private new Renderer renderer;

    private Material materialBackup;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
	    if (renderer == null)
	        renderer = GetComponent<Renderer>();
	    if (materialBackup == null || !renderer.material.name.Contains("(Instance)"))
	    {
	        materialBackup = renderer.material;
	        renderer.material = new Material(materialBackup);
	        renderer.material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
	    }
	    if (alpha != renderer.material.color.a)
	    {
	        _col = renderer.material.color;
	        _col.a = alpha;
	        renderer.material.color = _col;
	    }

    }
}
