using Core.Interfaces;
using FileService.Entities;
using FileService.Repository.Interfaces;
using FileService.Service.Interfaces;

namespace FileService.Service;

public class FileService : IFileService
{
    private readonly string _storagePath = "Files";

    private readonly IRepository<FileRecord> _repository;

    public FileService(IRepository<FileRecord> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> UploadFileAsync(IFormFile file, CancellationToken token)
    {
        var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(_storagePath, uniqueFileName);
        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream, token);

        FileRecord fileRecord = new()
        {
            ContentType = file.ContentType,
            PhysFileName = file.FileName,
            StoredFileName = uniqueFileName,
            Size = file.Length,
            UploadedAt = DateTime.UtcNow
        };

        FileRecord savedRecord = await _repository.CreateAsync(fileRecord, token);
        return savedRecord.UUID;
    }

    public async Task<GetFileResult> GetFileAsync(Guid uuid, CancellationToken token)
    {
        FileRecord savedRecord = await _repository.GetAsync(uuid, token);
        if (savedRecord is null)
            throw new FileNotFoundException();

        var filePath = Path.Combine(_storagePath, savedRecord.StoredFileName);
        FileStream stream = new(filePath, FileMode.Open);
        GetFileResult result = new()
        {
            FileName = savedRecord.StoredFileName,
            ContentType = savedRecord.ContentType,
            Data = stream
        };
        return result;
    }

    public Task<GetFileResult> UpdateFileAsync(IFormFile file, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteFileAsync(Guid uuid, CancellationToken token)
    {
        FileRecord savedRecord = await _repository.GetAsync(uuid, token);
        if (savedRecord is null)
            throw new FileNotFoundException();

        var filePath = Path.Combine(_storagePath, savedRecord.StoredFileName);
        File.Delete(filePath);
        await _repository.DeleteAsync(savedRecord.UUID, token);
    }
}