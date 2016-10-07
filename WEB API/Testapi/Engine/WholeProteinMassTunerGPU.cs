using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Cudafy;
using Cudafy.Host;
using Cudafy.Translator;

namespace Testapi.Engine
{
    public class WholeProteinMassTunerGPU
    {
        public const int N = 1024;

        public static void GPU_generator(List<double> peakList, List<double> intensities, ref double molWeight, double molTolerance)
        {
            int I_size = (int)molTolerance * 2 * 10;

            int[] array = new int[I_size];

            Stopwatch aaa = new Stopwatch();
            aaa.Start();
            GPGPU gpu = CudafyHost.GetDevice(CudafyModes.Target, 0);
            eArchitecture arch = gpu.GetArchitecture();
            CudafyModule km = CudafyTranslator.Cudafy(arch);

            gpu.LoadModule(km);

            double[,] output;

            int len1;

            peakList.Sort();

            double[] difference = new double[26];// Does not contain modifications !!!!!!!!!!!!!!!!!

            int length = peakList.Count * peakList.Count;
            len1 = peakList.Count;

            double[] peaks = peakList.ToArray(); // peaks

            int[] len = new int[1];
            len[0] = peakList.Count; // length of peaklist

            output = new double[peakList.Count, peakList.Count];

            double[] peaks_d = gpu.Allocate<double>(peaks);

            int[] len_d = gpu.Allocate<int>(len);

            double[,] output_d = gpu.Allocate<double>(output);

            gpu.CopyToDevice(peaks, peaks_d);

            gpu.CopyToDevice(len, len_d);
            gpu.CopyToDevice(output, output_d);

            int block = (int)Math.Ceiling((double)(length * 26 / N));

            gpu.Launch(block, N).TG(peaks_d, len_d, output_d);

            gpu.CopyFromDevice(output_d, output);

            gpu.FreeAll();

            int temp;

            double[] array2 = new double[I_size];

            double value = 0;
            int max = 0;

            for (int i = 0; i < peakList.Count; i++)
            {
                for (int j = i; j < peakList.Count; j++)
                {
                    temp = (int)(Math.Round((output[i, j] - (molWeight - molTolerance)), 2) * 10);
                    if (temp >= 0 && temp < array.Length)
                    {
                        add_val(temp, array, output[i, j], array2);
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    value = array2[i] / array[i];
                }
            }
            molWeight = value;

            string a = "";
        }

        public static void add_val(int index, int[] array, double val, double[] array2)
        {
            for (int i = index - 5; i <= index + 4; i++)
            {
                if (i >= 0 && i < array.Length)
                {
                    array[i]++;
                    array2[i] += val;
                }
            }
        }

        [Cudafy]
        public static void TG(GThread thread, double[] peaks, int[] len, double[,] output)
        {
            int tid = thread.threadIdx.x + thread.blockIdx.x * thread.blockDim.x;
            int s = tid % len[0];
            int e = s + (tid / (len[0] * 26)) + 1;
            int d = (tid / len[0]) % 26;

            if (e < len[0])
            {
                double dif = peaks[e] + peaks[s];
                output[s, e] = dif;
            }
        }
    }
}