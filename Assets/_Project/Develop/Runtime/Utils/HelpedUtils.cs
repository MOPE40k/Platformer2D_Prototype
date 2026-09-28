namespace PlatformerDemo.Assets._Project.Develop.Runtime.Utils
{
    public class HelpedUtils
    {
        public static float StrictSign(float f)
        {
            if (f > 0f)
                return 1f;

            if (f < 0f)
                return -1f;

            return 0f;
        }
    }
}