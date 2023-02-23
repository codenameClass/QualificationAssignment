using DataAccessFile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccessFile.Repositories
{
    public class BaseFileRepository<T> : BaseRepository<T>
    {
        public BaseFileRepository() {}

        /*
        private async Task LoadFileData()
        {
            if (File.Exists(_filePath))
            {
                using FileStream stream = new(_filePath, FileMode.Open);
                data = await JsonSerializer.DeserializeAsync<Dictionary<Guid, T>>(stream);
            }
        }

        public async Task SaveFileDataAsync()
        {
            try
            {
                string json = JsonSerializer.Serialize(data);
                await File.WriteAllTextAsync(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There as an error saving file: {ex.Message}");
            }
        }
        */
    }
}
