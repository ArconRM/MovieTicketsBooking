using AutoMapper;
using Common.DTO;
using Common.DTO.Files;
using FileService.Entities;

namespace FileService.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<FileRecord, FileRecordDTO>().ReverseMap();
    }
}