using System;

namespace NewsChannel.Common
{
    public static class ObjectExtensions
    {
        public static void CheckArgumentIsNull(this object o, string name)
        {
            if (o == null)
                throw new ArgumentNullException(name);
        }
    }
}
