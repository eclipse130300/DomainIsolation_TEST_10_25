using Unity.Plastic.Newtonsoft.Json;

namespace Core
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public abstract class HttpRequestBase<TResponse>
    {
        /// <summary>Request URL (relative or absolute).</summary>
        public abstract string Url { get; }

        /// <summary>HTTP method type.</summary>
        public abstract HttpMethodType Type { get; }

        /// <summary>Optional JSON body.</summary>
        public virtual string Body => null;

        /// <summary>Optional custom headers.</summary>
        public virtual Dictionary<string, string> Headers { get; } = new();
        
        public virtual async Task<TResponse> SendAsyncMock()
        {
            await Task.Delay(1000); // Simulate network delay
            UnityEngine.Debug.Log($"[HttpRequestBase] Mock request to {Url} with method {Type} and body {Body}");
            return default;
        }

        /// <summary>Sends the request asynchronously.</summary>
        public virtual async Task<TResponse> SendAsyncReal()
        {
            using var request = new UnityEngine.Networking.UnityWebRequest(Url, Type.ToString());
            request.downloadHandler = new UnityEngine.Networking.DownloadHandlerBuffer();

            if (!string.IsNullOrEmpty(Body))
            {
                var bodyRaw = System.Text.Encoding.UTF8.GetBytes(Body);
                request.uploadHandler = new UnityEngine.Networking.UploadHandlerRaw(bodyRaw);
                request.SetRequestHeader("Content-Type", "application/json");
            }

            foreach (var kv in Headers)
                request.SetRequestHeader(kv.Key, kv.Value);

            var operation = request.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            // Check for network errors
            if (request.result != UnityEngine.Networking.UnityWebRequest.Result.Success)
            {
                UnityEngine.Debug.LogError($"[HttpRequestBase] Request to {Url} failed: {request.error}");
                return default;
            }

            // Deserialize JSON response
            string responseString = request.downloadHandler.text;
            return DeserializeResponse(responseString);
        }

        /// <summary>Deserializes JSON response to TResponse.</summary>
        protected virtual TResponse DeserializeResponse(string responseString)
        {
            if (string.IsNullOrEmpty(responseString))
                return default;

            try
            {
                return JsonConvert.DeserializeObject<TResponse>(responseString);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError($"[HttpRequestBase] Failed to deserialize response from {Url}: {ex}");
                return default;
            }
        }
    }

}

