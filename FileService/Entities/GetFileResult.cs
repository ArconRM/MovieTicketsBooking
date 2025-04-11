namespace FileService.Entities;

public class GetFileResult
{
    public string FileName { get; set; }

    public string ContentType { get; set; }

    public Stream Data { get; set; }
}