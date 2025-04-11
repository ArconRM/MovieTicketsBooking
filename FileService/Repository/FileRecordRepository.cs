using Core.BaseEntities;
using FileService.Entities;
using FileService.Repository.Interfaces;

namespace FileService.Repository;

public class FileRecordRepository : BaseRepository<FileRecord>, IFileRecordRepository
{
    private readonly FileContext _context;

    public FileRecordRepository(FileContext context) : base(context)
    {
        _context = context;
    }
}