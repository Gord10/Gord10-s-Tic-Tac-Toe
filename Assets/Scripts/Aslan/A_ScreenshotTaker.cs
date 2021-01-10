using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

namespace Aslan
{
    public class A_ScreenshotTaker : MonoBehaviour
    {

        private static A_ScreenshotTaker _instance;
        static int screenshotID = 0;
        public int supersize = 0;
        public KeyCode keyCode = KeyCode.Q;

        public static A_ScreenshotTaker instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<A_ScreenshotTaker>();

                    //Tell unity not to destroy this object when loading a new scene!
                    DontDestroyOnLoad(_instance.gameObject);
                }

                return _instance;
            }
        }
        // Use this for initialization

        public static void TakeScreenshot()
        {
            int multiplier = 1;
            if(_instance.supersize > 1)
            {
                multiplier = _instance.supersize;
            }

            string sSceneName = SceneManager.GetActiveScene().name;

            if(!Directory.Exists("Screenshots"))
            {
                Directory.CreateDirectory("Screenshots");
            }

            string sFileName = "Screenshots//" + sSceneName + "_" + (Screen.width * multiplier).ToString() + "x" + (Screen.height * multiplier).ToString() + "_" + screenshotID.ToString() + ".png";
            ScreenCapture.CaptureScreenshot(sFileName, _instance.supersize);
            print(sFileName);
            screenshotID++;
        }

        // Update is called once per frame
        void Update()
        {
#if UNITY_EDITOR

            if (Input.GetKeyDown(keyCode))
            {
                TakeScreenshot();
            }
#endif
        }

        void Awake()
        {
            if (_instance == null)
            {
                //If I am the first instance, make me the Singleton
                _instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                //If a Singleton already exists and you find
                //another reference in scene, destroy it!
                if (this != _instance)
                    Destroy(this.gameObject);
            }
        }
    }

}