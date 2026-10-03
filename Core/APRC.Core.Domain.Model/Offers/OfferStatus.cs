namespace APRC.Core.Domain.Model.Offers;

/// <summary>
/// Статус оферты. Набор флагов: допускаются комбинации, например Public | Actual.
/// В БД хранится как int (EF сохраняет enum с базовым типом ushort столбцом int).
/// </summary>

[Flags]
public enum OfferStatus : ushort
{
    None = 0,               // статус не установлен
    Public = 1,             // публичное предложение
    Personal = 2,           // персональное предложение
    Updated = 4,            // изменено
    Actual = 8,             // актуально
    Counterproposal = 16,   // встречное предложение
    Refused = 32,           // отказано банком
    Rejected = 64,          // отклонено заёмщиком
    Archive = 128           // архивировано
}
