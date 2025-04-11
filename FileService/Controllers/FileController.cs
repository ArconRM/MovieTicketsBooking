using AutoMapper;
using FileService.Entities;
using FileService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileService.Controllers;

[Route("api/[controller]")]
public class FileController : Controller
{
    private readonly ILogger<FileController> _logger;

    private readonly IMapper _mapper;

    private readonly IFileService _fileService;

    public FileController(ILogger<FileController> logger, IMapper mapper, IFileService fileService)
    {
        _logger = logger;
        _mapper = mapper;
        _fileService = fileService;
    }

    [HttpPost(nameof(UploadFile))]
    public async Task<IActionResult> UploadFile(IFormFile file, CancellationToken token)
    {
        try
        {
            Guid uuid = await _fileService.UploadFileAsync(file, token);
            return Ok(uuid);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpPost(nameof(GetFile))]
    public async Task<IActionResult> GetFile(Guid uuid, CancellationToken token)
    {
        try
        {
            GetFileResult fileResult = await _fileService.GetFileAsync(uuid, token);
            Console.WriteLine(fileResult.Data.CanRead);
            Console.WriteLine(fileResult.Data.CanSeek);
            return File(fileResult.Data, fileResult.ContentType, fileResult.FileName);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}