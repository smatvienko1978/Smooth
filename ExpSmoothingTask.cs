using System.Collections.Generic;

namespace yield
{
    public static class ExpSmoothingTask
    {
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
        {
            var isFirstItem = true;
            double previousItem = 0;
            foreach (var e in data)
            {
                var item = new DataPoint(e);

                if (isFirstItem)
                {
                    isFirstItem = false;
                    previousItem = e.OriginalY;
                }
                else
                {
                    previousItem = alpha * e.OriginalY + (1 - alpha) * previousItem;
                }
               
                yield return item.WithExpSmoothedY(previousItem);
            }
        }
    }
}