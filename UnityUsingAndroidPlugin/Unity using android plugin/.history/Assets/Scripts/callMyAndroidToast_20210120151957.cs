using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callMyAndroidToast : MonoBehaviour
{

    //method that calls our native plugin.
    public void CallNativePlugin() {


        // Retrieve the UnityPlayer class.
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        // Retrieve the UnityPlayerActivity object ( a.k.a. the current context )
        AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("getApplicationContext");
        // Retrieve the "Bridge" from our native plugin.
        // ! Notice we define the complete package name.              
        AndroidJavaObject bridge = new AndroidJavaObject("com.sugoijapaneseschool.androidmoduleforunity.Bridge");

        // Setup the parameters we want to send to our native plugin.              
        object[] parameters = new object[2];
        parameters[0] = unityActivity;
        parameters[1] = "This is an call to native android!";

        // Call PrintString in bridge, with our parameters.
        bridge.Call("PrintString", parameters);
    }


	void OnGUI()
	{
		if (GUI.Button(new Rect(0
		                        , 0
		                        , 160
		                        , 130)
		               , "버튼"))
		{

            CallNativePlugin();
		}
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
