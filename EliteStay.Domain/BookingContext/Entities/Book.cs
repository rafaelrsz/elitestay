using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Shared.Entities;
using FluentValidator.Validation;

namespace EliteStay.Domain.BookingContext.Entities
{
  public class Book : Entity
  {
    public Book(User user, Room room, DateTime startDate, DateTime endDate)
    {
      this.user = user;
      this.room = room;
      this.startDate = startDate;
      this.endDate = endDate;
      this.status = EBookStatus.Booked;

      if (!room.IsAvailable(startDate, endDate))
        AddNotification("Room", "Quarto não está disponível");

      if (startDate.Date >= endDate.Date)
        AddNotification("EndDate", "Data de saída invalida");

      if (startDate.Date < DateTime.Now.Date)
        AddNotification("StartDate", "Data de entrada invalida");

      if (Notifications.Count == 0)
        room.Book(startDate, endDate);
    }

    public User user { get; private set; }
    public Room room { get; private set; }
    public DateTime startDate { get; private set; }
    public DateTime endDate { get; private set; }
    public decimal? totalPrice { get; private set; }// quando finalizar deve retornar total do preço
    public EBookStatus status { get; private set; }
    public void CheckOut()
    {
      if (status == EBookStatus.Booked)
        AddNotification("Status", "Reserva ainda não foi paga!");

      status = EBookStatus.Finished;
    }
    public decimal Pay()
    {
      totalPrice = (endDate - startDate).Days * room.dailyPrice;
      status = EBookStatus.Payed;

      return totalPrice.Value;
    }
    public void Cancel()
    {
      if (status != EBookStatus.Booked)
      {
        AddNotification("Status", "Não é possivel cancelar uma reserva já iniciada");
        return;
      }
      room.CancelBook(startDate, endDate);
      status = EBookStatus.Canceled;
    }
  }
}