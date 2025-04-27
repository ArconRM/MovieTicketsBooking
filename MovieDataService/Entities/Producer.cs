using Core.Interfaces;

namespace MovieDataService.Entities;
//TODO: навигационные свойства добавить (с разными дто-шками)
//TODO!: для взаимодействия между сервисами grpc (1) + rabbitmq (потом) (не через eventmanager)
//TODO: пагинация на фильмы по жанру
//TODO: генерить пдфки билетов в отдельном сервисе
//TODO: файловый сервис на стримах (доделать)

public class Producer : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string FullName { get; set; }

    public DateTime DateBirth { get; set; }

    public string? Nationality { get; set; }

    public string? Description { get; set; }

    public Guid? AvatarUUID { get; set; }

    public List<Movie> Movies { get; set; }
}