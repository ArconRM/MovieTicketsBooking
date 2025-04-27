using Core.Interfaces;

namespace Common.DTO.Files;

public class FileRecordDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string ContentType { get; set; }

    /// <summary>
    /// Имя загруженного файла (физически)
    /// </summary>
    public string PhysFileName { get; set; }

    /// <summary>
    /// Виртуальное имя файла
    /// </summary>
    public string StoredFileName { get; set; }

    /// <summary>
    /// Объем файла в байтах
    /// </summary>
    public long Size { get; set; }

    /// <summary>
    /// Время загрузки
    /// </summary>
    public DateTime UploadedAt { get; set; }
}