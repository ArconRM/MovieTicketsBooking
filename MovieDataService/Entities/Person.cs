using Core.Interfaces;

namespace MovieDataService.Entities;
//TODO: файловый сервис на стримах (доделать)
//TODO: как возвращать связанные сущности
//TODO!: для взаимодействия между сервисами grpc + rabbitmq (не через eventmanager)

public class Person : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string FullName { get; set; }

    public DateTime DateBirth { get; set; }

    public string? Nationality { get; set; }

    public string? Description { get; set; }

    public Guid? AvatarUUID { get; set; }
}