using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEngine
{
    public class Settings
    {
        public const float Z_NEAR = 0.01f;
        public const float Z_FAR = 1000f;


        public static float FOV_RAW = 60;
        public static float FOV = MathHelper.DegreesToRadians(FOV_RAW);
        
        public static float MOUSE_SENSITIVITY = 0.4f;
        public static float CAM_STEP = 0.01f;
    }
}
