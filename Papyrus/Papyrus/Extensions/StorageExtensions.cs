﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace Papyrus
{
    internal static class StorageExtensions
    {
        internal static async Task<StorageFile> GetFileFromPathAsync(this StorageFolder folder, string path)
        {
            path = path.Replace('\\', '/');
            var pathParts = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < pathParts.Length - 1; i++)
                folder = await folder.GetFolderAsync(pathParts[i]);

            IStorageItem file;

			if (pathParts.Last().Contains("#"))
			{
				file = await folder.TryGetItemAsync(pathParts.Last().Split('#').FirstOrDefault());

				if (file == null)
					file = await folder.TryGetItemAsync(pathParts.Last());

				if (file == null)
					Debug.WriteLine($"Failed to find file at location {path}");
			}

			else
			{
				file = await folder.TryGetItemAsync(pathParts.Last());

				if (file == null)
					file = await folder.TryGetItemAsync(pathParts.Last());

				if (file == null)
					Debug.WriteLine($"Failed to find file at location {path}");
			}

            return file as StorageFile;
        }
    }
}
