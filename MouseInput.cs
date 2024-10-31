using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CustomEngine
{
    public class MouseInput
    {
        private readonly Vector2d prevPos, currPos;
        private readonly OpenTK.Mathematics.Vector2 disVec;

        private bool inWindow = false, leftButtonPress = false, rightButtonPress = false;

        public MouseInput()
        {
            prevPos = new Vector2d(-1, 1);
            currPos = new Vector2d(0, 0);
            disVec = new OpenTK.Mathematics.Vector2();
        }

        public void init()
        {
            
        }
    }
}
