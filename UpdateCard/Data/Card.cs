using System;
using System.Collections.Generic;

namespace UpdateCard.Data;

public partial class Card
{
    public int Id { get; set; }

    public string CarNumber { get; set; } = null!;

    public string CarBrand { get; set; } = null!;

    public string CarModel { get; set; } = null!;

    public int Balance { get; set; }

    public DateTime? LastEntered { get; set; }
}
