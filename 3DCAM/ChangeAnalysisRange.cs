using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DCAM
{
    class ChangeAnalysisRange
    {
        public float[] DoChange(float[] originalData, int startPosition, int endPosition)
        {
            float[] changedData = new float[endPosition - startPosition];

            for (int i = startPosition; i < endPosition; i++)
            {
                changedData[i - startPosition] = originalData[i];
            }

            return changedData;
        }
    }
}
