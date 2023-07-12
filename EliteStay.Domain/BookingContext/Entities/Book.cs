using EliteStay.Shared.Entities;

namespace Elitestay.Domain.BookingContext.Entities
{
  public class Book : Entity
  {
    public DateTime startDate { get; private set; }
    public DateTime expectedEndDate { get; private set; }
    public decimal totalPrice { get; private set; }// quando finalizar deve retornar total do preço
    public decimal dailyPrice { get; private set; }
  }
}