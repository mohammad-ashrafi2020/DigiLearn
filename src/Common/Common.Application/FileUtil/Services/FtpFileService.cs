using System.Net;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Common.Application.FileUtil.Services;

public class FtpFileService : IFtpFileService
{
    //Fake Server
    private string _ftpServer = "ftp://130.185.79.155/public_html";
    private NetworkCredential CreateNetworkCredential()
    {
        return new NetworkCredential("pz16162", "G9xna4oN");
    }

    public async Task SaveFile(IFormFile file, string directoryPath)
    {
        var ftpAddress = _ftpServer;
        string currentDir = ftpAddress;

        string[] subDirs = directoryPath.RemoveWWWroot().Split('/');

        foreach (var subDir in subDirs)
        {
            currentDir = currentDir + "/" + subDir;
            await CreateDirectory(currentDir);
        }

        long length = file.Length;
        if (length < 0)
            throw new Exception();

        await using var stream = file.OpenReadStream();

        //Read File
        byte[] bytes = new byte[length];
        await stream.ReadAsync(bytes, 0, (int)file.Length);
        //Save File
        WebClient request = new WebClient();
        request.Credentials = CreateNetworkCredential();
        var path = currentDir + "/" + file.Name;
        await request.UploadDataTaskAsync(new Uri(path), bytes);
    }

    public async Task<string> SaveFileAndGenerateName(IFormFile file, string directoryPath)
    {
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var ftpAddress = _ftpServer;
        string currentDir = ftpAddress;

        string[] subDirs = directoryPath.RemoveWWWroot().Split('/');

        foreach (var subDir in subDirs)
        {
            currentDir = currentDir + "/" + subDir;
            await CreateDirectory(currentDir);
        }

        long length = file.Length;
        if (length < 0)
            throw new Exception();

        await using var stream = file.OpenReadStream();

        //Read File
        byte[] bytes = new byte[length];
        await stream.ReadAsync(bytes, 0, (int)file.Length);
        //Save File
        WebClient request = new WebClient();
        request.Credentials = CreateNetworkCredential();
        var path = currentDir + "/" + fileName;
        await request.UploadDataTaskAsync(new Uri(path), bytes);
        return fileName;
    }

    public async Task SaveFile(Stream stream, string directoryPath, string fileName)
    {
        var ftpAddress = _ftpServer;
        string currentDir = ftpAddress;

        string[] subDirs = directoryPath.RemoveWWWroot().Split('/');

        foreach (var subDir in subDirs)
        {
            currentDir = currentDir + "/" + subDir;
            await CreateDirectory(currentDir);
        }

        long length = stream.Length;
        if (length < 0)
            throw new Exception();


        //Read File
        byte[] bytes = new byte[length];
        await stream.ReadAsync(bytes, 0, (int)stream.Length);
        //Save File
        WebClient request = new WebClient();
        request.Credentials = CreateNetworkCredential();
        var path = currentDir + "/" + fileName;
        await request.UploadDataTaskAsync(new Uri(path), bytes);
    }

    public async Task DeleteFile(string path, string fileName)
    {
        string filePath = $"{_ftpServer}{path.RemoveWWWroot()}/{fileName}";


        var request = (FtpWebRequest)FtpWebRequest.Create(new Uri(filePath.RemoveWWWroot()));
        request.Method = WebRequestMethods.Ftp.DeleteFile;
        request.Credentials = CreateNetworkCredential();
        var response = await request.GetResponseAsync();
        response.Close();
    }

    public async Task DeleteFile(string filePath)
    {
        var request = (FtpWebRequest)FtpWebRequest.Create(new Uri($"{_ftpServer}{filePath.RemoveWWWroot()}"));
        request.Method = WebRequestMethods.Ftp.DeleteFile;
        request.Credentials = CreateNetworkCredential();
        var response = await request.GetResponseAsync();
        response.Close();
    }

    public async Task DeleteDirectory(string directoryPath)
    {
        string filePath = $"{_ftpServer}{directoryPath.RemoveWWWroot()}";
        var request = (FtpWebRequest)FtpWebRequest.Create(new Uri(filePath));
        request.Method = WebRequestMethods.Ftp.RemoveDirectory;
        request.Credentials = CreateNetworkCredential();
        var response = await request.GetResponseAsync();
        response.Close();
    }

    private async Task CreateDirectory(string directoryPath)
    {
        try
        {
            var reqFTP = (FtpWebRequest)FtpWebRequest.Create(directoryPath);
            reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
            reqFTP.UseBinary = true;
            reqFTP.Credentials = CreateNetworkCredential();
            FtpWebResponse response = (FtpWebResponse)await reqFTP.GetResponseAsync();
            var ftpStream = response.GetResponseStream();
            ftpStream.Close();
            response.Close();
        }
        catch (Exception ex)
        {
            //directory already exist I know that is weak but there is no way to check if a folder exist on ftp...
        }

    }


}

static class FtpTextHelper
{
    public static string RemoveWWWroot(this string text)
    {
        return text.Replace("wwwroot", "");
    }
}