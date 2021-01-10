using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DCAM
{
    class CreateOriginalWaves
    {
        public Tuple<float[], float[]> CreateWaves(float[] frequency, float[] amplitude, float samplingFrequency, float biacDC, int theNumberOfSampling)
        {
            //サンプリング周期
            float timeCircle = 1 / samplingFrequency;

            float[] wave = new float[theNumberOfSampling];
            float[] time = new float[theNumberOfSampling];

            for (int i = 0; i < frequency.Length; i++)
            {
                for (int j = 0; j < theNumberOfSampling; j++)
                {
                    wave[j] += amplitude[i] * (float)Math.Sin(2 * Math.PI * frequency[i] * j * timeCircle);
                    if (i == 0) time[j] = timeCircle * j;
                    if (i == 0) wave[j] += biacDC;
                }
            }
            return new Tuple<float[], float[]>(time, wave);
        }

    }
}
