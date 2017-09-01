using System.Collections.Generic;
using System.Drawing;

namespace ColorService
{
    public interface IColorOperator
    {
        /// <summary>
        /// Gets discreet colors from a bitmap
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        List<Color> GetDiscreetColorList(Bitmap bitmap);

        /// <summary>
        /// Replaces color from originalColor to originalColor for a given bitmap
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="givenColor"></param>
        /// <param name="replacementColor"></param>
        void ExceptGivenColorFillImageWIthReplacementColor(Bitmap bitmap, Color givenColor, Color replacementColor);

        /// <summary>
        /// Replaces color from originalColor to originalColor for a given bitmap in unsafe manner, but faster
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="originalColor"></param>
        /// <param name="replacementColor"></param>
        void ReplaceColorUnsafe(Bitmap bitmap, byte[] originalColor, byte[] replacementColor);


        void ReplaceColor(Bitmap bitmap, Color originalColor, Color replacementColor);

        List<Point> GetRectangleEdgePointsWithGivenColorOnBitMap(Bitmap bitmap, Color fetchColor);
    }
}