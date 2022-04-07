using IdiotBenchmark.API.PerformanceTest;

const string strCmdText = "/C k6 run .\\smoke-test.js";
// const string strCmdText = "/C k6 run .\\load-test.js";
// const string strCmdText = "/C k6 run .\\soak-test.js";
// const string strCmdText = "/C k6 run .\\stress-test.js";

// System.Diagnostics.Process process = new();
// System.Diagnostics.ProcessStartInfo startInfo = new();
// startInfo.FileName = "cmd.exe";
// startInfo.Arguments = strCmdText;
// process.StartInfo = startInfo;
// process.Start();
// process.WaitForExit();

HttpTest.Run();