using ChromaSDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTBS.RazerContols
{
    public class Keyboard
    {
        private int _mResult = 0;

        public int GetInitResult()
        {
            return _mResult;
        }

        public void Start()
        {
            _mResult = ChromaAnimationAPI.Init();
            switch (_mResult)
            {
                case RazerErrors.RZRESULT_DLL_NOT_FOUND:
                    Console.Error.WriteLine("Chroma DLL is not found! {0}", RazerErrors.GetResultString(_mResult));
                    break;
                case RazerErrors.RZRESULT_DLL_INVALID_SIGNATURE:
                    Console.Error.WriteLine("Chroma DLL has an invalid signature! {0}", RazerErrors.GetResultString(_mResult));
                    break;
                case RazerErrors.RZRESULT_SUCCESS:
                    break;
                default:
                    Console.Error.WriteLine("Failed to initialize Chroma! {0}", RazerErrors.GetResultString(_mResult));
                    break;
            }
        }
        public void OnApplicationQuit()
        {
            ChromaAnimationAPI.Uninit();
        }



        public void Zwift(Color color, float duration)
        {
            // start with a blank animation
            string baseLayer = "Animations/Blank_Keyboard.chroma";
            // close the blank animation if it's already loaded, discarding any changes
            ChromaAnimationAPI.CloseAnimationName(baseLayer);
            // open the blank animation, passing a reference to the base animation when loading has completed
            ChromaAnimationAPI.GetAnimation(baseLayer);
            int frameCount = 20;
            // Start with blank frames set to 30FPS
            ChromaAnimationAPI.MakeBlankFramesName(baseLayer, frameCount, duration, 0);
           
            // set a background color
            //ChromaAnimationAPI.FillZeroColorAllFramesRGBName(baseLayer, color.R, color.G, color.B);
            // Fill all frames with black and white static
            //ChromaAnimationAPI.FillColor(6, 5, color.ToArgb());
            ChromaAnimationAPI.FillRandomColorsBlackAndWhiteAllFramesName(baseLayer);
            ChromaAnimationAPI.MultiplyIntensityAllFramesRGBName(baseLayer, color.R, color.G, color.B);
            // slow down the random frames so it can be seen
            ChromaAnimationAPI.DuplicateFramesName(baseLayer);
            // play the animation on the dynamic canvas
            ChromaAnimationAPI.PlayAnimationName(baseLayer, true);
            
        }

        public void Zwift3(Color color)
        {

            // start with a blank animation
            string baseLayer = "Animations/OutParticle1_Keyboard.chroma";
            // close the blank animation if it's already loaded, discarding any changes
            ChromaAnimationAPI.CloseAnimationName(baseLayer);
            // open the blank animation, passing a reference to the base animation when loading has completed
            ChromaAnimationAPI.GetAnimation(baseLayer);
            // turn grayscale particles to blue water
            ChromaAnimationAPI.MultiplyIntensityAllFramesRGBName(baseLayer, color.R, color.G, color.B);
            // play the animation on the dynamic canvas
            ChromaAnimationAPI.PlayAnimationName(baseLayer, true);
        }
    }
}
