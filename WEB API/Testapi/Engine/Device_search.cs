using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cudafy;
using Cudafy.Host;
using Cudafy.Translator;
using Mono.Cecil;
using ICSharpCode.ILSpy;
using ICSharpCode.Decompiler;
using System.Diagnostics;
using System.Reflection;



namespace Testapi.Engine
{
    class Device_search
    {
        //public static GPGPU gpu = CudafyHost.GetDevice(CudafyModes.Target, 0);
        //public static CudafyModule Cudafiee(ePlatform platform, eArchitecture arch, params Type[] types)
        //{
        //    return CudafyTranslator.Cudafy(platform, arch, null, true, types);
        //}
        //public static CudafyModule Cudafiee()
        //{
        //    StackTrace stackTrace = new StackTrace();
        //    Type type = stackTrace.GetFrame(1).GetMethod().ReflectedType;
        //    CudafyModule km = CudafyModule.TryDeserialize(type.Name);
        //    if (km == null || !km.TryVerifyChecksums())
        //    {
        //        km = Cudafiee(ePlatform.Auto, eArchitecture.Unknown, type);
        //        km.Name = type.Name;
        //        km.TrySerialize();
        //    }
        //    return km;
        //}


        //CudafyModule km = CudafyTranslator.Cudafy();
        //GPGPU gpu = CudafyHost.GetDevice(eGPUType.Cuda);
        //eArchitecture arch = gpu.GetArchitecture();
        //gpu.LoadModule(km);
        

        public const int N = 1024;
        public const int size = 14524302;


        [Cudafy]
        public static void Dot(GThread thread, int[,] table1, int[] output_table, char[] matched_result, char[] input, int[] size1)
        {
            int cacheIndex = thread.threadIdx.x;
            int tid = thread.threadIdx.x + thread.blockIdx.x * thread.blockDim.x;
            int pos = tid;
            int state = 0;
            int start;
            char ch;
            int size2 = size1[0];

            while (pos < size2)
            {
                thread.SyncThreads();
                start = pos;
                state = 0;
                while ((state != -1) && (pos < size2))
                {
                    ch = input[pos];
                    thread.SyncThreads();
                    int nextState = table1[state, (int)(ch) - (int)('A')];
                    pos = pos + 1;
                    if (nextState != -1)
                    {
                        int matchVec = output_table[nextState];
                        if (matchVec > 0)
                        {
                            matched_result[start] = (char)matchVec;

                        }

                        thread.SyncThreads();
                    }

                    state = nextState;
                }
                pos = start + N * thread.gridDim.x;
            }
        }


        public static char[] Execute(String[] keys, string I, int n)
        {
            GPGPU gpu = CudafyHost.GetDevice(CudafyModes.Target, 0);
            eArchitecture arch = gpu.GetArchitecture();
            CudafyModule km = CudafyTranslator.Cudafy(arch);

            gpu.LoadModule(km);

            Stopwatch xxxx = new Stopwatch();
            xxxx.Start();
            StringSearch abb = new StringSearch(keys);
            string alphabet = "ABCDEFGHI*KLMN*PQRST*VWXYZ";
            int alpha = alphabet.Length;

            int[,] table1 = new int[StringSearch.nodeCount, alpha];
            for (int i = 0; i < StringSearch.nodeCount; i++)
                for (int j = 0; j < alpha; j++)
                {
                    table1[i, j] = -1;
                }

            abb.build_table1(table1, abb._root);
            char[] input = I.ToCharArray();
            int length = I.Length;
            I = "";
            int[] output_table = new int[StringSearch.nodeCount];
            abb.build_tableO(output_table, abb._root);
            abb = new StringSearch();
            char[] matched_result = new char[length];
            xxxx.Stop();
            
            //CudafyModule km = CudafyModule.TryDeserialize();
            //if (km == null || !km.TryVerifyChecksums())
            //{
            //    km = CudafyTranslator.Cudafy();
            //    km.Serialize();
            //    gpu.LoadModule(km);
            //}
           
            gpu.SetCurrentContext();
            int[] tempas = new int[StringSearch.nodeCount];
            int[,] tempbab = new int[StringSearch.nodeCount, alpha];
            int[,] table1_d = gpu.Allocate<int>(tempbab);
            int[] output_table_d = gpu.Allocate<int>(tempas);
            char[] matched_result_d = gpu.Allocate<char>(length);
            char[] input_d = gpu.Allocate<char>(length);
            int[] input_length_d = gpu.Allocate<int>(1);
            int[] input_length = { length };
            gpu.CopyToDevice(table1, table1_d);
            gpu.CopyToDevice(output_table, output_table_d);
            gpu.CopyToDevice(matched_result, matched_result_d);
            gpu.CopyToDevice(input, input_d);
            gpu.CopyToDevice(input_length, input_length_d);
            int block = (int)Math.Ceiling((double)length / N);
            gpu.Launch(block, N).Dot(table1_d, output_table_d, matched_result_d, input_d, input_length_d);
            gpu.CopyFromDevice(matched_result_d, matched_result);
            gpu.FreeAll();
            return matched_result;

        }

        


        ////////////////////////////////////////////TUNER////////////////////////////////////////////////////////
      
        /*public static void making_combs(double[] a, double[] b, int[] c, int numA, double molWeight, double molTolerance)
        {
            try
            {
                
                CudafyModule km = CudafyModule.TryDeserialize();
                if (km == null || !km.TryVerifyChecksums())
                {
                    km = CudafyTranslator.Cudafy();
                    km.Serialize();
                    gpu.LoadModule(km);
                }
                
                gpu.SetCurrentContext();

                

                Stopwatch ss = new Stopwatch();
                Stopwatch ss1 = new Stopwatch();
                Stopwatch dd = new Stopwatch();
                Stopwatch gg = new Stopwatch();
                int[] it = { numA };
                int power = (int)Math.Log(numA * numA, 2) + 1;
                int num = (int)Math.Pow(2, power);
                int[] it1 = { num };
                int[] sqr = { numA * numA };
                double[] tola = { molTolerance };
                double[] mola = { molWeight };
                int[] dev_c = gpu.Allocate<int>(c);
                double[] dev_b = gpu.Allocate<double>(b);
                int[] numOfEle = gpu.CopyToDevice(it);
                int[] iter1 = gpu.CopyToDevice(it1);
                int[] iter2 = gpu.CopyToDevice(sqr);
                double[] tol = gpu.CopyToDevice(tola);
                double[] MW = gpu.CopyToDevice(mola);

                dim3 threads = new dim3(1, 1024);
                dim3 grid = new dim3(1, 1);

                double[] inputArr = gpu.CopyToDevice(a);

                ss.Reset();
                ss.Start();
                gpu.Launch(grid, threads).Make_comb_glob(inputArr, dev_b, dev_c, numOfEle, tol, MW);
                int[] dev_g = gpu.Allocate<int>(c);
                gpu.CopyFromDevice(dev_c, c);
                gpu.CopyFromDevice(dev_b, b);
                ss.Stop();
                dd.Reset();
                dd.Start();

                int[] xx = new int[numA * numA];
                int[] dev_e = gpu.Allocate<int>(xx);
                int[] intermed = { 0 };
                int[] dev_h = gpu.CopyToDevice<int>(intermed);
                gpu.Launch(1, 1024).prescan(dev_e, dev_c, iter1, dev_g, dev_h);
                gpu.CopyFromDevice(dev_e, xx);
                dd.Stop();

                gg.Reset();
                gg.Start();
                int[] probability = gpu.CopyToDevice<int>(c);
                int[] prescan = gpu.CopyToDevice<int>(xx);
                int size = xx[xx.Length - 1];
                size = xx.Max();
                double[] trimmed = new double[size];
                double[] input = gpu.CopyToDevice(b);
                double[] output = gpu.Allocate<double>(size);
                gpu.Launch((sqr[0] / 1024) + 1, (1024)).outputfunc(input, prescan, probability, output, iter2);
                gpu.CopyFromDevice(output, trimmed);
                Array.Sort(trimmed);
                gpu.FreeAll();
                int[] finsize = { trimmed.Length };
                int x = (int)((trimmed[trimmed.Length - 1] - trimmed[0]) * 10) + 1;
                double[] p = gpu.CopyToDevice<double>(trimmed);
                int[] r = gpu.CopyToDevice<int>(finsize);
                int[] q = gpu.Allocate<int>(x);
                int[] out1 = new int[x];

                dim3 blocking = new dim3(x / 1024 + 1, 1, 1);
                dim3 threading = new dim3(1024, 1, 1);
                gpu.Launch(blocking, threading).windowing(p, q, r);
                gpu.CopyFromDevice(q, out1);
                gg.Stop();
                gpu.FreeAll();
            }

            catch (Cudafy.CudafyLanguageException z1)
            {
                Console.WriteLine(z1.Message);
            }
            catch (Cudafy.CudafyCompileException z)
            {
                Console.WriteLine(z.Message);
            }
            catch (Cudafy.CudafyFatalException z)
            {
                Console.WriteLine(z.Message);
            }
        }


        

        [Cudafy]
        public static void Make_comb_glob(GThread thread, double[] input, double[] cd, int[] bd, int[] iter, double[] tol, double[] MW)
        {
            int tx = thread.blockDim.x * thread.blockIdx.x + thread.threadIdx.x;
            int ty = thread.blockDim.y * thread.blockIdx.y + thread.threadIdx.y;
            double temp;

            int x = tx;
            int y = ty;
            for (; x < iter[0]; x++)
            {
                y = ty;
                for (; y < iter[0]; )
                {
                    if (x < y)
                    {
                        temp = input[x] + input[y];
                        if ((temp > (MW[0] - tol[0])) && (temp < (MW[0] + tol[0])))
                        {
                            cd[x * iter[0] + y] = input[x] + input[y];
                            bd[x * iter[0] + y] = 1;
                        }


                    }

                    y = y + thread.blockDim.y;

                }
            }
        }

        [Cudafy]
        public static void prescan(GThread thread, int[] g_odata, int[] g_idata, int[] n, int[] devg, int[] store)
        {
            int thid = thread.threadIdx.x;
            int offset = 1;
            devg[thid] = 0;
            if (thid < n[0] / 2)
            {
                devg[2 * thid] = g_idata[2 * thid]; // load input into shared memory  
                devg[2 * thid + 1] = g_idata[2 * thid + 1];

                for (int d = n[0] >> 1; d > 0; d >>= 1)                    // build sum in place up the tree  
                {
                    thread.SyncThreads();
                    if (thid < d)
                    {
                        int ai = offset * (2 * thid + 1) - 1;
                        int bi = offset * (2 * thid + 2) - 1;
                        devg[bi] += devg[ai];
                    }
                    offset *= 2;
                }

                if (thid == 0)
                {
                    devg[n[0] - 1] = 0;
                } // clear the last element  
                for (int d = 1; d < n[0]; d *= 2) // traverse down tree & build scan  
                {
                    offset >>= 1;
                    thread.SyncThreads();
                    if (thid < d)
                    {
                        int ai = offset * (2 * thid + 1) - 1;
                        int bi = offset * (2 * thid + 2) - 1;
                        int t = devg[ai];
                        devg[ai] = devg[bi];
                        devg[bi] += t;
                    }
                }
                thread.SyncThreads();
                g_odata[2 * thid] = devg[2 * thid]; // write results to device memory  
                g_odata[2 * thid + 1] = devg[2 * thid + 1];
            }
        }

        [Cudafy]
        public static void outputfunc(GThread thread, double[] input, int[] prescan, int[] prob, double[] output, int[] n)
        {
            int thid = thread.blockDim.x * thread.blockIdx.x + thread.threadIdx.x;
            if (thid < n[0])
            {
                if (prob[thid] == 1)
                {
                    output[prescan[thid]] = input[thid];
                }
            }
        }

        [Cudafy]
        public static void windowing(GThread thread, double[] input, int[] output, int[] num)
        {
            int thid = thread.blockDim.x * thread.blockIdx.x + thread.threadIdx.x;
            double x = input[0] + (thid / 10);
            int y;
            int count = 0;
            for (y = 0; y < input.Length; y++)
            {
                if ((input[y] >= (input[0] + (thid / 10))) && (input[y] <= (input[0] + (thid / 10)) + 1))
                {
                    count++;
                }
                output[thid] = count;
            }

        }
        */
    }
}