using System.Text;

namespace QGate.Core.Texts
{
    public static class StringBuilderExtension
    {
        public static StringBuilder AppendGap(this StringBuilder stringBuilder)
        {
            return stringBuilder.Append(StringExtensions.Gap);
        }
    }
}
