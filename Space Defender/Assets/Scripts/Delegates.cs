namespace Assets.Scripts
{
    public delegate void VoidDelegate();

    public delegate void FloatDelegate(float val);

    public static class DelegateEx
    {
        public static void SafeCallDelegate(this VoidDelegate voidDelegate)
        {
            if (voidDelegate != null)
                voidDelegate();
        }

        public static void SafeCallDelegate(this FloatDelegate floatDelegate, float val)
        {
            if (floatDelegate != null)
                floatDelegate(val);
        }
    }
}