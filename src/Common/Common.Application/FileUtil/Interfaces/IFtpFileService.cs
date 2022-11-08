using Microsoft.AspNetCore.Http;

namespace Common.Application.FileUtil.Interfaces;

public interface IFtpFileService
{
    /// <summary>
    /// Save File With Origin FileName
    /// </summary>
    /// <param name="file"></param>
    /// <param name="directoryPath"></param>
    /// <returns></returns>
    Task SaveFile(IFormFile file, string directoryPath);

    /// <summary>
    /// Saves the file with a unique name and returns the file name
    /// </summary>
    /// <param name="file"></param>
    /// <param name="directoryPath"></param>
    /// <returns></returns>
    Task<string> SaveFileAndGenerateName(IFormFile file, string directoryPath);
    Task SaveFile(Stream stream, string directoryPath,string fileName);
    Task DeleteFile(string path, string fileName);
    Task DeleteFile(string filePath);
    Task DeleteDirectory(string directoryPath);
}