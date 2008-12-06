/*
 * Created by: 
 * Created: zaterdag 6 december 2008 : Sinterklaas!
 */

namespace Utilities.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object value)
        {
            return null == value;
        }
    }
}