/// Wrapper for NIST Statistical Test Suite Library 'nist.dll'
/// The NIST Statistical Test Suite is a great tool, and I found the code to be very impressive and well written, (and the math!). A huge thank you to the authors..
/// The original console suite is available on the NIST website: http://csrc.nist.gov/groups/ST/toolkit/rng/documentation_software.html
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace VTDev.Tools.STS
{
    #region Enums
    /// <summary>
    /// The available range of Test types.
    /// Used to set the Test 'ParametersKey' property.
    /// </summary>
    public enum Tests
    {
        ApproximateEntropy, 
        BlockFrequency, 
        CumulativeSums, 
        FFT, 
        Frequency, 
        LinearComplexity, 
        LongestRun, 
        NonOverlappingTemplate, 
        OverlappingTemplate, 
        RandomExcursions, 
        RandomExcursionsVariant, 
        Rank, 
        Runs, 
        Serial, 
        Universal,
    }
    #endregion

    public static class NistSTS
    {
        #region Default Constants
        private const string RESULTS_NAME = "results.txt";
        private const string LINEAR_RESULT = "N/A";
        private const string RANGED_RESULT = "OUT OF RANGE";
        private const long MAX_FILESIZE = 102400000;
        private const long MIN_FILESIZE = 1024;
        private const double ALPHA = 0.01;      //p_value < ALPHA ? "FAILURE" : "SUCCESS"
        private const int APPROXIMATE_M = 10;   //10 
        private const int COMPLEXITY_M = 512;   //500
        private const int FREQUENCY_M = 128;    //128
        private const int NONOVERLAPPING_M = 9; //9
        private const int OVERLAPPING_M = 9;    //9
        private const int SERIAL_M = 16;        //16
        #endregion

        #region Api
        [DllImport("nist.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NistLoadFile([MarshalAs(UnmanagedType.LPStr)]String lpFileName, int Size);
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistFrequency();
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistBlockFrequency(int M);
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistCumulativeSums();
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistRuns();
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistLongestRunOfOnes();
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistRank();
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistDiscreteFourierTransform();
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistNonOverlappingTemplateMatchings(int M);
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistOverlappingTemplateMatchings(int M);
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistUniversal();
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistApproximateEntropy(int M);
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistRandomExcursions();
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistRandomExcursionsVariant();
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistLinearComplexity(int M);
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double NistSerial(int M);
        [DllImport("nist.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int NistCleanup();
        #endregion

        #region Progress
        public static event Action<int, string> ProgressChanged;
        private static void OnProgressChanged(int value, string message)
        {
            var progress = ProgressChanged;
            if (progress != null)
                progress(value, message);
        }
        #endregion

        #region Fields
        /// <summary>
        /// List of available test names.
        /// </summary>
        public readonly static string[] TestNames = new string[] { 
            "ApproximateEntropy", 
            "BlockFrequency", 
            "CumulativeSums", 
            "FFT", 
            "Frequency", 
            "LinearComplexity", 
            "LongestRun", 
            "NonOverlappingTemplate", 
            "OverlappingTemplate", 
            "RandomExcursions", 
            "RandomExcursionsVariant", 
            "Rank", 
            "Runs", 
            "Serial", 
            "Universal",
            };
        /// <summary>
        /// Default state for the Run() method. Use the Parameters property to add or remove tests.
        /// </summary>
        private static readonly Dictionary<Tests, bool> TestParams = new Dictionary<Tests, bool>() {  
            {Tests.ApproximateEntropy, true},
            {Tests.BlockFrequency, true},
            {Tests.CumulativeSums, true},
            {Tests.FFT, true},
            {Tests.Frequency, true},
            {Tests.LinearComplexity, true},
            {Tests.LongestRun, true},
            {Tests.NonOverlappingTemplate, true},
            {Tests.OverlappingTemplate, true},
            {Tests.RandomExcursions, true},
            {Tests.RandomExcursionsVariant, true},
            {Tests.Rank, true},
            {Tests.Runs, true},
            {Tests.Serial, true},
            {Tests.Universal, true},
        };
        #endregion 

        #region Constructor
        /// <summary>
        /// Initilizes default property values.
        /// </summary>
        static NistSTS()
        {
            // set default tests (all)
            ParametersKey = TestParams;
            // property defults
            ApproximateEntropy_M = APPROXIMATE_M;
            BlockFrequency_M = FREQUENCY_M;
            LinearComplexity_M = COMPLEXITY_M;
            NonOverlappingTemplate_M = NONOVERLAPPING_M;
            OverlappingTemplate_M = OVERLAPPING_M;
            Serial_M = SERIAL_M;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Block size for ApproximateEntropy test
        /// </summary>
        public static int ApproximateEntropy_M { get; set; }
        /// <summary>
        /// Block size for BlockFrequency test
        /// </summary>
        public static int BlockFrequency_M { get; set; }
        /// <summary>
        /// Block size for LinearComplexity test
        /// </summary>
        public static int LinearComplexity_M { get; set; }
        /// <summary>
        /// Template indice for non overlapping test (stored in templates folder)
        /// </summary>
        public static int NonOverlappingTemplate_M { get; set; }
        /// <summary>
        /// Sample size for OverlappingTemplate test
        /// </summary>
        public static int OverlappingTemplate_M { get; set; }
        /// <summary>
        /// Block size for Serial test
        /// </summary>
        public static int Serial_M { get; set; }
        /// <summary>
        /// Select or deselect a test with this property: true/false. The key value is a member of 'Tests'.
        /// Usage: ParametersKey[Tests.ApproximateEntropy] = false;
        /// </summary>
        public static Dictionary<Tests, bool> ParametersKey { get; set; }
        #endregion

        #region Nist Analysis
        /// <summary>
        /// Calculate the averages, and return values in a dictionary
        /// </summary>
        /// <param name="TestName">Grouping of p-values</param>
        /// <param name="PValues">Test name</param>
        /// <returns>Dictionary with keys: Name, High, Low, Average [key/value]</returns>
        public static Dictionary<string, string> Average(string TestName, double[] PValues)
        {
            // create the results dictionary
            Dictionary<string, string> testResults = new Dictionary<string, string>() {
                {"Name", ""},
                {"Low", ""},
                {"High", ""},
                {"Average", ""},
            };

            int len = PValues.Length;
            double high = 0;
            double low = 10.0;
            double sum = 0;

            for (int i = 0; i < len; i++)
            {   // skip error returns
                if (!double.IsNaN(PValues[i]) && PValues[i] != -1 && PValues[i] != 0)
                {
                    if (PValues[i] > high)
                        high = PValues[i];
                    if (PValues[i] < low)
                        low = PValues[i];
                    sum += PValues[i];
                }
            }
            
            testResults["Name"] = TestName;
            testResults["Low"] = low.ToString();
            testResults["High"] = high.ToString();
            testResults["Average"] = (sum / len).ToString();

            return testResults;
        }

        /// <summary>
        /// Get test results from a Nist STS run
        /// </summary>
        /// <param name="FilePath">Full path to random data file</param>
        /// <returns>Results dictionary [key: Tests.(testname) - value: p-value,score]</returns>
        public static Dictionary<string, string> Run(string FilePath)
        {
            // not found!
            if (!File.Exists(FilePath))
                throw new Exception("File not found! Check the path.");
            long fileLength = Utilities.GetFileSize(FilePath);
            // exceeds reasonable size!
            if (fileLength > MAX_FILESIZE)
                throw new Exception("File is too large! File must be smaller then " + MAX_FILESIZE.ToString() + " bytes.");
            // less then smallest sample size!
            if (fileLength < MIN_FILESIZE)
                throw new Exception("File is too small! File must be larger then " + MIN_FILESIZE.ToString() + " bytes.");

            double pValue = 0.0;

            // get the number of tests
            int testCount = 0;
            foreach (var test in TestParams)
                testCount += test.Value == true ? 1 : 0;

            // create the results dictionary
            Dictionary<string, string> testResults = new Dictionary<string, string>();

            try
            {
                // need the null char
                StringBuilder file = new StringBuilder(FilePath, FilePath.Length);
                
                // initialize the library state by loading the file
                int ret = NistLoadFile(file.ToString(), (int)fileLength);
                // 1 = success, -1 = failed: bad file or path permissions
                if (ret == -1)
                {
                    OnProgressChanged(0, "Test Failed!");
                    NistCleanup();
                    throw new Exception("Could not load the file! Check your permissions for this directory.");
                }
                // run the tests..
                if (ParametersKey[Tests.ApproximateEntropy])
                {
                    try
                    {
                        pValue = NistApproximateEntropy(ApproximateEntropy_M);
                    }
                    catch 
                    {
                        pValue = -1;
                    }
                    testResults.Add("ApproximateEntropy", pValue.ToString() + "," + State(ref pValue));
                    OnProgressChanged(1, "Approximate Entropy Completed..");
                }
                if (ParametersKey[Tests.BlockFrequency])
                {
                    try
                    {
                        pValue = NistBlockFrequency(BlockFrequency_M);
                    }
                    catch 
                    {
                        pValue = -1;
                    }
                    testResults.Add("BlockFrequency", pValue.ToString() + "," + State(ref pValue));
                    OnProgressChanged(1, "Block Frequency Completed..");
                }
                if (ParametersKey[Tests.CumulativeSums])
                {
                    try 
                    {
                        pValue = NistCumulativeSums();
                    }
                    catch 
                    {
                        pValue = -1;
                    }
                    testResults.Add("CumulativeSums", pValue.ToString() + "," + State(ref pValue));
                    OnProgressChanged(1, "Cumulative Sums Completed..");
                }
                if (ParametersKey[Tests.FFT])
                {
                    if (fileLength > 1024 * 1000 * 10)
                    {
                        testResults.Add("FFT", "0.0" + "," + "TOO LARGE");
                        OnProgressChanged(1, "FFT Completed..");
                    }
                    else
                    {
                        try
                        {
                            pValue = NistDiscreteFourierTransform();
                        }
                        catch
                        {
                            pValue = -1;
                        }
                        testResults.Add("FFT", pValue.ToString() + "," + State(ref pValue));
                        OnProgressChanged(1, "FFT Completed..");
                    }
                }
                if (ParametersKey[Tests.Frequency])
                {
                    try
                    {
                        pValue = NistFrequency();
                    }
                    catch 
                    {
                        pValue = -1;
                    }
                    testResults.Add("Frequency", pValue.ToString() + "," + State(ref pValue));
                    OnProgressChanged(1, "Frequency Completed..");
                }
                if (ParametersKey[Tests.LinearComplexity])
                {
                    try
                    {
                        pValue = NistLinearComplexity(LinearComplexity_M);
                    }
                    catch 
                    {
                        pValue = -1;
                    }
                    testResults.Add("LinearComplexity", pValue.ToString() + "," + LINEAR_RESULT);
                    OnProgressChanged(1, "Linear Complexity Completed..");
                }
                if (ParametersKey[Tests.LongestRun])
                {
                    try
                    {
                        pValue = NistLongestRunOfOnes();
                    }
                    catch 
                    {
                        pValue = -1;
                    }
                    testResults.Add("LongestRun", pValue.ToString() + "," + State(ref pValue));
                    OnProgressChanged(1, "Longest Run Of Ones Completed..");
                }
                if (ParametersKey[Tests.NonOverlappingTemplate])
                {
                    try
                    {
                        pValue = NistNonOverlappingTemplateMatchings(NonOverlappingTemplate_M);
                    }
                    catch 
                    {
                        pValue = -1;
                    }
                    testResults.Add("NonOverlappingTemplate", pValue.ToString() + "," + State(ref pValue));
                    OnProgressChanged(1, "Non Overlapping Template Completed..");
                }
                if (ParametersKey[Tests.OverlappingTemplate])
                {
                    try
                    {
                        pValue = NistOverlappingTemplateMatchings(OverlappingTemplate_M);
                    }
                    catch 
                    {
                        pValue = -1;
                    }
                    testResults.Add("OverlappingTemplate", pValue.ToString() + "," + State(ref pValue));
                    OnProgressChanged(1, "Overlapping Template Completed..");
                }
                if (ParametersKey[Tests.RandomExcursions])
                {
                    try
                    {
                        pValue = NistRandomExcursions();
                    }
                    catch 
                    {
                        pValue = -1;
                    }
                    testResults.Add("RandomExcursions", pValue.ToString() + "," + State(ref pValue));
                    OnProgressChanged(1, "Random Excursions Completed..");
                }
                if (ParametersKey[Tests.RandomExcursionsVariant])
                {
                    try
                    {
                        pValue = NistRandomExcursionsVariant();
                    }
                    catch 
                    {
                        pValue = -1;
                    }
                    testResults.Add("RandomExcursionsVariant", pValue.ToString() + "," + State(ref pValue));
                    OnProgressChanged(1, "Random Excursions Variant Completed..");
                }
                if (ParametersKey[Tests.Rank])
                {
                    try
                    {
                        pValue = NistRank();
                    }
                    catch 
                    {
                        pValue = -1;
                    }
                    testResults.Add("Rank", pValue.ToString() + "," + State(ref pValue));
                    OnProgressChanged(1, "Rank Completed..");
                }
                if (ParametersKey[Tests.Runs])
                {
                    try
                    {
                        pValue = NistRuns();
                    }
                    catch 
                    {
                        pValue = -1;
                    }
                    testResults.Add("Runs", pValue.ToString() + "," + State(ref pValue));
                    OnProgressChanged(1, "Runs Completed..");
                }
                if (ParametersKey[Tests.Serial])
                {
                    try
                    {
                        pValue = NistSerial(Serial_M);
                    }
                    catch
                    {
                        pValue = -1;
                    }
                    testResults.Add("Serial", pValue.ToString() + "," + State(ref pValue));
                    OnProgressChanged(1, "Serial Completed..");
                }
                if (ParametersKey[Tests.Universal])
                {
                    try
                    {
                        pValue = NistUniversal();
                    }
                    catch
                    {
                        pValue = -1;
                    }
                    testResults.Add("Universal", pValue.ToString() + "," + State(ref pValue));
                    OnProgressChanged(1, "Universal Completed..");
                }

                // always call cleanup when tests are done
                NistCleanup();

                // return results
                return testResults;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Helpers
        private static string State(ref double PValue)
        {
            // not enough cycles, not enough data, or block alignment wrong.
            if (PValue == -1 || double.IsNaN(PValue))
            {
                PValue = 0;
                return RANGED_RESULT;
            }

            return PValue < ALPHA ? "FAIL" : "PASS";
        }
        #endregion

        #region Test
        private static void TestNistImplemention()
        {
            // values tested against debug of console version using same random file
            // g=good, b=bad
            double p = 0;
            string fname = @"c:\tests\random.bin";

            int ret = NistLoadFile(fname, 100000);

            if (ret != -1)
            {
                p = NistFrequency(); //076144893868935981 g
                p = NistBlockFrequency(FREQUENCY_M); //027394732429695723 g
                p = NistCumulativeSums(); //077440119116130557 g
                p = NistRuns(); //094430373116480792 g
                p = NistLongestRunOfOnes(); //09307620058921845 g
                p = NistRank(); //053165988692173938 g
                p = NistDiscreteFourierTransform(); //018191684493667287 g
                p = NistNonOverlappingTemplateMatchings(OVERLAPPING_M); //mean sum of values, but aligns 031843444930672676 g
                p = NistOverlappingTemplateMatchings(OVERLAPPING_M); //031843444930672676 g
                p = NistUniversal(); //0 fail on both(data failed test), but internal aligns g
                p = NistApproximateEntropy(APPROXIMATE_M); //033462188816412319 g
                p = NistRandomExcursions(); //-9.2559631349317831e+061 g
                p = NistRandomExcursionsVariant(); //-9.2559631349317831e+061 g
                p = NistLinearComplexity(COMPLEXITY_M); //039270975717538864 g
                p = NistSerial(SERIAL_M); //012535646014613261 g
            }

            NistCleanup();
        }
        #endregion
    }
}
