using UnityEngine;
using UnityEngine.SceneManagement; //You need to add this line manually. Without it SceneManager scripts won't work.
using System.Collections;

public class reloadcurrent : MonoBehaviour {
	
	// Update is called once per frame

	void Update () {
		//When you press the R key... This could be anyhting else though. I'm just including that so you can see it in action in your scenes. 
		if (Input.GetKeyDown("space")) {
            Invoke("MyFunction", 3);
			
		}
	}
    void MyFunction()
    {
       //We declare a variable to store our currentScene's name. We get this through the SceneManager class's GetActiveScene method. 
			string currentScene = SceneManager.GetActiveScene ().name; 
			Debug.Log (currentScene); 
			//Here we are asking the SceneManager to load the desired scene. In this instance we're providing it our variable 'currentScene'
			SceneManager.LoadScene(currentScene);
    }
}