using FileService.Entities;

namespace FileService.Service.Interfaces;

public interface IFileService
{
    Task<Guid> UploadFileAsync(IFormFile file, CancellationToken token);

    Task<GetFileResult> GetFileAsync(Guid uuid, CancellationToken token);

    Task<GetFileResult> UpdateFileAsync(IFormFile file, CancellationToken token);

    Task DeleteFileAsync(Guid uuid, CancellationToken token);
}