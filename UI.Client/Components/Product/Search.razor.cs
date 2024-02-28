using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace UI.Client.Components.Product
{
    public partial class Search
    {
        [Inject]
        private IJSRuntime jsS { get;set; }
        private string path = "C:/audio/";

        private bool _isRecording = false;
        private List<byte[]> _audioChunks = new List<byte[]>();

        [JSInvokable]
        public async Task ReceiveAudioChunk(byte[] chunk)
        {
            _audioChunks.Add(chunk);
            _isRecording = true; // Update recording state for UI
        }

        public async Task StartRecording()
        {
            _audioChunks.Clear(); // Clear previous recording

            await jsS.InvokeAsync<object>("startRecording");
        }

        public async Task StopAndSaveRecording()
        {
            await jsS.InvokeAsync<object>("stopRecording"); // Stop recording on client-side

            if (_audioChunks.Count > 0)
            {
                var fileName = $"{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.webm"; // Use UTC for better consistency
                var filePath = Path.Combine(path, "recordings", fileName);

                // Ensure recordings folder exists
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    foreach (var chunk in _audioChunks)
                    {
                        await fileStream.WriteAsync(chunk, 0, chunk.Length);
                    }
                }

                _audioChunks.Clear(); // Clear list for next recording
                _isRecording = false; // Update recording state for UI
            }
            else
            {
                // Handle the case where no audio was recorded
                Console.WriteLine("No audio recorded.");
            }
        }
    }
}
