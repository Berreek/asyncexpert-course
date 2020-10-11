using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TaskCompletionSourceExercises.Core
{
    public class AsyncTools
    {
        public static Task<string> RunProgramAsync(string path, string args = "")
        {
            var process = new Process
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo(path)
                {
                    RedirectStandardOutput = true, RedirectStandardError = true, Arguments = args
                }
            };

            var tcs = new TaskCompletionSource<string>();
            process.Exited += async (sender, eventArgs) =>
            {
                var senderProcess = sender as Process;
                var error = await senderProcess?.StandardError?.ReadToEndAsync();
                if (!string.IsNullOrEmpty(error))
                {
                    tcs.SetException(new Exception(error));
                }
                
                tcs.SetResult(await senderProcess?.StandardOutput?.ReadToEndAsync());
                senderProcess?.Dispose();
            };
            process.Start();
            
            return tcs.Task;
        }
    }
}
