using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccessFile.Data
{
    public class DataContext
    {
        private readonly string _filePath;

        public DataContext(string filePath)
        {
            _filePath = filePath;
            LoadFileData().Wait();
        }

        public Dictionary<string, Person> People { get; set; } = new Dictionary<string, Person>();

        private async Task LoadFileData()
        {
            if (File.Exists(_filePath))
            {
                using FileStream stream = new(_filePath, FileMode.Open);
                People = await JsonSerializer.DeserializeAsync<Dictionary<string, Person>>(stream);
            }
        }
        
        public async Task<bool> SaveChangesAsync()
        {
            string json = JsonSerializer.Serialize(People, new JsonSerializerOptions { WriteIndented = true });

            using FileStream stream = new FileStream(_filePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
            await stream.WriteAsync(jsonBytes, 0, jsonBytes.Length);
            await stream.FlushAsync();

            return true;
        }
        

        /*
        public async Task<bool> SaveChangesAsync()
        {
            string json = JsonSerializer.Serialize(People, new JsonSerializerOptions { WriteIndented = true });

            using FileStream stream = new FileStream(_filePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
            await stream.WriteAsync(Encoding.UTF8.GetBytes(json), 0, json.Length);
            await stream.FlushAsync();

            return true;
        }
        */
    }

}
