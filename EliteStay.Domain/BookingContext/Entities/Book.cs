using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Shared.Entities;
using FluentValidator.Validation;

namespace Elitestay.Domain.BookingContext.Entities
{
  public class Book : Entity
  {
    public Book(User user, Room room, DateTime startDate, DateTime endDate, decimal dailyPrice)
    {
      this.user = user;
      this.room = room;
      this.startDate = startDate;
      this.endDate = endDate;
      this.dailyPrice = dailyPrice;

      if (!room.IsAvailable(startDate, endDate))
        AddNotification("Room", "Quarto não está disponível");

      if (startDate >= endDate)
        AddNotification("EndDate", "Data de saída invalida");

      if (startDate < DateTime.Now)
        AddNotification("StartDate", "Data de entrada invalida");

      room.Book(startDate, endDate);
      status = EBookStatus.Booked;
    }

    public User user { get; private set; }
    public Room room { get; private set; }
    public DateTime startDate { get; private set; }
    public DateTime endDate { get; private set; }
    public decimal? totalPrice { get; private set; }// quando finalizar deve retornar total do preço
    public decimal dailyPrice { get; private set; }
    public EBookStatus status { get; private set; }
    public void CheckOut()
    {
      if (status == EBookStatus.Booked)
        AddNotification("Status", "Reserva ainda não foi paga!");

      status = EBookStatus.Finished;
    }
    public decimal Pay()
    {
      totalPrice = (endDate - startDate).Days * dailyPrice;
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