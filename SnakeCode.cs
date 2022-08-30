using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeCode : MonoBehaviour
{
	private Vector2 direction = Vector2.right;
	private List<Transform> _segment  = new List<Transform>() ;
	public Transform SegPredfab;
	public int firstSize = 4 ;
	//public GameObject menue;



	
	
	
	void Start()
	{
		ResetSnake();
	}



    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKeyDown(KeyCode.W))
    	{
    		direction = Vector2.up;
    	}
    	else if(Input.GetKeyDown(KeyCode.S))
    	{
    		direction = Vector2.down;
    	}
    	else if(Input.GetKeyDown(KeyCode.D))
    	{
    		direction = Vector2.right;
    	}
    	else if(Input.GetKeyDown(KeyCode.A))
    	{
    		direction = Vector2.left;
    	}
    }
    
    private void FixedUpdate()
    {
    	for (int i = _segment.Count -1 ;  i >0 ; i--)
    	{
    		_segment[i].position = _segment[i-1].position;
    	}
    	this.transform.position = new Vector3(Mathf.Round(this.transform.position.x)+ direction.x ,Mathf.Round(this.transform.position.y)+direction.y  , 0.0f );
    }
    
    private void grow()
    {
    	Transform Newtail = Instantiate(this.SegPredfab);
    	Newtail.position = _segment[_segment.Count -1 ].position;
    	_segment.Add(Newtail);
    }
    private void ResetSnake()
    {
    	for (int i = 1 ; i < _segment.Count;i++)
    	{
    		Destroy(_segment[i].gameObject);
    	}
    	
    	_segment.Clear();
    	_segment.Add(this.transform);
    	
    	for(int i = 1 ; i < firstSize ; i++)
    	{
    		_segment.Add(Instantiate(this.SegPredfab));
    	}
    	this.transform.position = Vector3.zero;
    	
    }
    private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Food")
		{
			grow();
		}
		else if(other.tag == "Obstacle")
		{
			//menue.SetActive(true);
				ResetSnake();
			}
		}
    
    private void exit()
    {
    	Application.Quit();
    }
	
}
